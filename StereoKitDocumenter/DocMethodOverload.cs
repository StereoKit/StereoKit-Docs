using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StereoKitDocumenter
{
	struct GenericStructT { }
	class GenericClassT { }

	class DocMethodOverload
	{
		public DocMethod      rootMethod;
		public string         signature;
		public string         summary;
		public string         returns;
		public List<DocParam> parameters = new List<DocParam>();

		MethodBase methodInfo;

		public bool IsStatic => methodInfo.IsStatic;

		// Link-free C# signature, e.g. "static Material Copy(string assetId)".
		// Shared by ToString() (site pages) and DocAI (AI-friendly docs) so the
		// two outputs can't drift apart.
		public string Signature => BuildSignature(rootMethod.ShowName);

		// Class-qualified variant for grep-friendly AI docs, e.g.
		// "static Material Material.Copy(string assetId)". Constructors stay as
		// just the class name (e.g. "void Material(Shader shader)").
		public string QualifiedSignature => BuildSignature(rootMethod.name == "#ctor"
			? rootMethod.parent.Name
			: $"{rootMethod.parent.Name}.{rootMethod.ShowName}");

		string BuildSignature(string methodDisplayName)
		{
			MethodBase          m          = methodInfo;
			Type                returnType = m is MethodInfo ? ((MethodInfo)m).ReturnType : typeof(void);
			List<ParameterInfo> param      = m == null ? new List<ParameterInfo>() : new List<ParameterInfo>(m.GetParameters());
			string              paramList  = string.Join(", ", param.Select(a => $"{StringHelper.TypeName(a.ParameterType.Name, false)} {a.Name}"));
			return (m.IsStatic ? "static " : "") + $"{StringHelper.TypeName(returnType.Name, false)} {methodDisplayName}({paramList})";
		}

		public DocMethodOverload(DocMethod aRootMethod, string aSignature)
		{
			rootMethod = aRootMethod;
			signature  = aSignature;
			methodInfo = GetMethodInfo(signature, rootMethod);
		}

		public override string ToString()
		{
			MethodBase m = methodInfo;
			Type   returnType = m is MethodInfo ? ((MethodInfo)m).ReturnType : typeof(void);
			string returnName = m is MethodInfo ? StringHelper.TypeName(returnType.Name) : "";
			List<ParameterInfo> param = m == null ? new List<ParameterInfo>() : new List<ParameterInfo>(m.GetParameters());

			string signature = Signature;

			string paramText = "";
			if (parameters.Count > 0 || returnType != typeof(void))
			{
				paramText += "\n|  |  |\n|--|--|\n";
				for (int i = 0; i < parameters.Count; i++)
				{
					ParameterInfo p = param.Find(a => a.Name == parameters[i].name);
					if (p == null)
					{
						if (!Program.options.Lenient)
							throw new Exception($"Can't find document parameter {parameters[i].name} in {rootMethod.name}");
						Console.WriteLine($"[warning] Can't find document parameter {parameters[i].name} in {rootMethod.name}");
						continue;
					}
					paramText += $"|{StringHelper.TypeName(p.ParameterType.Name)} {parameters[i].name}|{StringHelper.CleanForTable(parameters[i].summary)}|\n";
				}

				if (returnType != typeof(void)) {
					if (string.IsNullOrEmpty( returns )) {
						if (!Program.options.Lenient)
							throw new Exception("Missing doc tag for the return value of " + rootMethod.Name);
						Console.WriteLine($"[warning] Missing doc tag for the return value of {rootMethod.Name}");
					} else {
						paramText += $"|RETURNS: {returnName}|{StringHelper.CleanForTable(returns)}|\n";
					}
				}
			}

			return $@"<div class='signature' markdown='1'>
```csharp
{signature}
```
{summary}
</div>
{paramText}
";
		}

		private static Type GetParentType(DocMethod rootMethod)
			=> rootMethod.parent.ClassType;

		private static MethodBase GetMethodInfo(string signature, DocMethod rootMethod)
		{
			Type[] paramTypes = string.IsNullOrEmpty(signature) ? new Type[]{ } : StringHelper.SeparateGroupedString(',',signature)
				.Select(a => {
					string cleanName = a.Replace("@", "");
					bool   nullable  = a.Contains("System.Nullable");
					bool   action    = a.Contains("System.Action{");
					bool   array     = a.Contains("[]");
					int    arrayDepth = 0;
					bool   generic   = a.Contains("`");
					if (nullable)
					{
						int length = "System.Nullable{".Length;
						cleanName = cleanName.Substring(length, cleanName.Length-length-1);
					}
					if (action)
					{
						int length = "System.Action{".Length;
						cleanName = cleanName.Substring(length, cleanName.Length - length - 1);
					}
					if (array)
					{
						// Jagged arrays (T[], T[][], ...) carry one "[]" per dimension;
						// count them and strip them all to get the base type name.
						arrayDepth = (cleanName.Length - cleanName.Replace("[]", "").Length) / 2;
						cleanName  = cleanName.Replace("[]", "");
					}

					int commas = cleanName.Count(c => c == ',');
					Type t = null;
					if (t == null && action && commas == 0)
						t = typeof(Action<>).MakeGenericType(Type.GetType(cleanName));
					if (t == null && action && commas == 1)
						t = typeof(Action<,>).MakeGenericType(cleanName.Split(',').Select(n => InferType(n)).ToArray());
					if (t == null && action && commas == 2)
						t = typeof(Action<,,>).MakeGenericType(cleanName.Split(',').Select(n => InferType(n)).ToArray());
					if (t == null) 
						t = Type.GetType(cleanName);
					if (t == null)
						t = Type.GetType(cleanName + ", StereoKit");
					if (t == null)
						t = Type.GetType(cleanName + ", " + typeof(System.Numerics.Vector3).Assembly.FullName);
					if (t != null && nullable)
						t = typeof(Nullable<>).MakeGenericType(t);
					if (t != null && array)
						for (int d = 0; d < arrayDepth; d++)
							t = t.MakeArrayType();
					if (t != null && a.Contains("@"))
						t = t.MakeByRefType();
					if (t == null && generic)
						t = typeof(object);

					if (t == null)
						throw new Exception($"Can't find {rootMethod.Name}'s parameter type: {a}!");
					return t;
				})
				.ToArray();

			// Scrape out generics tags, don't quite know how to use them yet.
			string methodName = rootMethod.name;
			if (methodName.Contains('`'))
				methodName = methodName.Substring(0, methodName.IndexOf('`'));

			Type       parent = GetParentType(rootMethod);
			MethodBase result;
			if (methodName == "#ctor")
				result = parent.GetConstructor(paramTypes);
			else
			{
				// GetMethod matches on parameter types only, so conversion operators
				// that share a parameter type but differ by return type (e.g. multiple
				// op_Implicit) throw AmbiguousMatchException. Fall back to the first
				// exact parameter-type match.
				try { result = parent.GetMethod(methodName, paramTypes); }
				catch (AmbiguousMatchException)
				{
					result = parent.GetMethods().FirstOrDefault(m =>
						m.Name == methodName &&
						m.GetParameters().Select(p => p.ParameterType).SequenceEqual(paramTypes));
				}
			}

			// If it's generic, but there's no overloads, we can just return
			// the only method present
			if (result == null && methodName != "#ctor" && paramTypes.Contains(typeof(object)) && parent.GetMethods().Where(m=>m.Name==methodName).Count() == 1)
				result = parent.GetMethod(methodName);

            // If it is generic, and there is overloads, try to infer the method by iterating over all the methods.
            if (result == null && methodName != "#ctor" && paramTypes.Contains(typeof(object)) && parent.GetMethods().Where(m => m.Name == methodName).Count() > 1)
			{
				bool isGenericMethodName = rootMethod.name.Contains("`");
				foreach (MethodInfo m in parent.GetMethods())
				{
					if (m.Name == methodName)
					{
						// Check if match for myMethod<T>
						if ((isGenericMethodName && m.GetGenericArguments().Length > 0) || (!isGenericMethodName && m.GetGenericArguments().Length == 0))
						{
							// Check if match for Params
							if (paramTypes.Length == m.GetParameters().Length)
							{
								result = m;
							}
						}
					}
				}
            }

			// Constructors on a generic type (e.g. ComputeBuffer<T>) have `0[]-style
			// parameters that collapse to System.Object above, so GetConstructor can't
			// match them. Mirror the generic-method fallback and infer by param count.
			if (result == null && methodName == "#ctor" && paramTypes.Contains(typeof(object)))
			{
				foreach (ConstructorInfo c in parent.GetConstructors())
					if (paramTypes.Length == c.GetParameters().Length)
						result = c;
			}

			if (result == null)
				throw new Exception("Can't find info for method " + rootMethod.name);
			return result;
		}

		private static Type InferType(String typeName)
		{
			Type t = Type.GetType(typeName);
			if (t == null)
				t = Type.GetType(typeName + ", StereoKit");
			return t;
		}
	}
}
