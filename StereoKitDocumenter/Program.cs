using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace StereoKitDocumenter
{
	class Program
	{
		public class CLIOptions
		{
			[Option('x', "xml", Required = false, HelpText = "Path to your DLL's commentdoc xml file.")]
			public string XmlDocs { get; set; } = "../../../../repos/StereoKit/bin/netstandard2.0/StereoKit.xml";

			[Option('l', "library", Required = false, HelpText = "Path to your DLL.")]
#if DEBUG
			public string Library { get; set; } = "../../../../repos/StereoKit/bin/netstandard2.0/StereoKit.dll";
#else
			public string Library { get; set; } = "../../../../repos/StereoKit/bin/netstandard2.0/StereoKit.dll";
#endif

			string pagesOut = "../../../../docs/Pages/";
			[Option('o', "out", Required = false, HelpText = "Generated markdown output folder.")]
			public string PagesOut { get => pagesOut; set { pagesOut = value.Replace('\\','/'); if (!pagesOut.EndsWith("/")) pagesOut += "/"; } }
			
			[Option('s', "samples", Required = false, HelpText = "A folder that is searched recursively for .cs files with :CodeSample: or :CodeDoc: tags.")]
			public string SamplesProj { get; set; } = "../../../../repos/StereoKit/Examples/StereoKitTest/";
		}
		public static CLIOptions options;

		public static string[]        namespaces = new string[] { };
		public static List<DocClass>  classes = new List<DocClass>();
		public static List<DocMethod> methods = new List<DocMethod>();
		public static List<DocField>  fields  = new List<DocField>();
		public static List<IDocItem>  items   = new List<IDocItem>();
		public static List<DocInheritMethod> inheritMethods = new List<DocInheritMethod>();
		public static List<DocInheritField>  inheritFields  = new List<DocInheritField >();

		public static DocClass GetClass(string nameSpace, string name) {
			DocClass result = classes.Find((a) => a.nameSpace == nameSpace && a.name == name);
			if (result == null)
				throw new Exception($"Couldn't find a class with docs by name of '{name}'. Are you missing a <Summary> for this class?");
			return result;
		}
		public static bool TryGetClass(string name, out DocClass result)
		{
			result = classes.Find((a) => a.name == name);
			return result != null;
		}
		public static string GetNamespace(string name)
		{
			for (int i = 0; i < namespaces.Length; i++)
			{
				if (name.StartsWith(namespaces[i]))
					return namespaces[i];
			}
			int index = name.IndexOf('.');
			if (index != -1)
				return name[..index];
			return "";
		}

		static void Main(string[] args)
		{
			Parser                   parser = new Parser(s=>s.HelpWriter = null);
			ParserResult<CLIOptions> result = parser.ParseArguments<CLIOptions>(args);
			void DisplayHelp<T>(ParserResult<T> r, IEnumerable<Error> errs) {
				var helpText = errs.IsVersion()
					? HelpText.AutoBuild(r)
					: HelpText.AutoBuild(r, h => {
						h.AdditionalNewLineAfterOption = false; 
						h.Heading   = "A tool for building markdown documentation with samples from xml and source code! Designed for StereoKit.";
						h.Copyright = "";
					return h;
				}, e => e);
				Console.WriteLine(helpText);
				Environment.Exit(1);
			}
			result
				.WithParsed   (o => options = o)
				.WithNotParsed(e => DisplayHelp(result, e));

			if (!string.IsNullOrEmpty(options.Library)) {
				namespaces = Assembly
					.LoadFrom(Path.GetFullPath(options.Library))
					.GetTypes()
					.Select  (t => t.Namespace)
					.Distinct()
					.OrderByDescending(s=>s.Length)
					.ToArray ();
			}

			int tests = 0;//RunSKTests();
			if (tests != 0)
				Environment.Exit(tests);

			Console.WriteLine("Building doc pages...");
			ScrapeData();
			WriteDocsToFile();
			Console.WriteLine("Done!");
		}

		private static void WriteDocsToFile()
		{
			for (int i = 0; i < items.Count; i++)
			{
				Directory.CreateDirectory(Path.GetDirectoryName(items[i].FileName));
				StreamWriter writer = new StreamWriter(items[i].FileName);
				writer.Write(items[i].ToString());
				writer.Close();
			}

			classes.Sort((a, b) => a.name.CompareTo(b.name));
			{
				StreamWriter writer = new StreamWriter(options.PagesOut + "data.js");
				writer.Write(WriteIndex());
				writer.Close();
			}
		}

		private static void ScrapeData()
		{
			XmlReader reader = XmlReader.Create(options.XmlDocs);
			while (reader.ReadToFollowing("member"))
			{
				string    name      = reader.GetAttribute("name");
				XmlReader member    = reader.ReadSubtree();
				string    type      = name[0].ToString();
				string    signature = name.Substring(2);

				if (type == "T")
				{
					ReadClass(signature, reader.ReadSubtree());
				}
				else if (type == "M")
				{
					ReadMethod(signature, reader.ReadSubtree());
				}
				else if (type == "F" || type == "P")
				{
					ReadField(signature, reader.ReadSubtree());
				}
			}

			// Check inheritdoc references, and update their values
			inheritFields .ForEach(f=>f.Resolve(fields));
			inheritMethods.ForEach(f=>f.Resolve(methods));

			DocExampleFinder.FindExamples(options.SamplesProj);
		}

		private static int RunSKTests()
		{
			var testInfo = new System.Diagnostics.ProcessStartInfo();
			testInfo.FileName         = "cmd.exe";
			testInfo.Arguments        = "/C StereoKitTest.exe -test";
			testInfo.UseShellExecute  = false;
			#if DEBUG
			testInfo.WorkingDirectory = "../../../../../bin/x64_Debug/StereoKitTest/";
			#else
			testInfo.WorkingDirectory = "../../../../../bin/x64_Release/StereoKitTest/";
			#endif
			var process = System.Diagnostics.Process.Start(testInfo);
			process.WaitForExit();
			Console.WriteLine("Ran StereoKit tests! Result: " + process.ExitCode);

			return process.ExitCode;
		}

		static void ParseTypeSig(string signature, out string nameSpace, out string typeName)
		{
			nameSpace = GetNamespace(signature);
			typeName  = signature[(nameSpace.Length > 0 ? nameSpace.Length + 1 : 0)..];
		}
		static void ParseMemberSig(string signature, out string nameSpace, out string className, out string member)
		{
			nameSpace = GetNamespace(signature);
			int last  = signature.LastIndexOf('.');
			member    = signature[(last+1)..];
			className = signature[(nameSpace.Length > 0 ? nameSpace.Length + 1 : 0)..last];
		}

		static void ReadClass(string signature, XmlReader reader)
		{
			DocClass result = new DocClass();

			// Get names
			ParseTypeSig(signature, out string nameSpace, out string className);
			result.name      = className;
			result.nameSpace = nameSpace;


			// Read properties
			while (reader.Read())
			{
				switch (reader.Name.ToLower())
				{
					case "summary": result.summary = StringHelper.CleanMultiLine(reader.ReadElementContentAsString().Trim()); break;
				}
			}

			classes.Add(result);
			items  .Add(result);
		}

		static void ReadField(string signature, XmlReader reader)
		{
			// Get names
			ParseMemberSig(signature, out string nameSpace, out string className, out string memberName);

			DocField result = new DocField(GetClass(nameSpace, className), memberName);

			// Read properties
			while (reader.Read())
			{
				switch (reader.Name.ToLower())
				{
					case "summary": result.summary = StringHelper.XmlReaderToString(reader); break;
					case "remarks": result.remarks = StringHelper.XmlReaderToString(reader); break;
					case "inheritdoc": {
						string reference = reader.GetAttribute("cref").Trim();
						int    start     = reference.IndexOf('.');
						start = start == -1 ? 0 : start+1;
						result.summary = $"See `{reference.Substring(start)}`";
						inheritFields.Add(new DocInheritField(result, reader.GetAttribute("cref")));
					} break;
				}
			}

			fields.Add(result);
			items .Add(result);
		}

		static void ReadMethod(string signature, XmlReader reader)
		{
			// Get names
			int    split     = signature.IndexOf('(');
			string sigType   = split==-1?signature:signature[..split];
			string sigParams = split==-1?"":signature[(split+1)..signature.IndexOf(')')];

			ParseMemberSig(sigType, out string namespaceSig, out string className, out string methodName);

			if (methodName == "Finalize") // Skip deconstructors!
				return;

			DocMethod method = methods.Find(a => a.name == methodName && a.parent.name == className);
			if (method == null)
			{
				method = new DocMethod(GetClass(namespaceSig, className), methodName);
				methods.Add(method);
				items.Add(method);
			}

			DocMethodOverload variant = method.AddOverload(sigParams);

			// Read properties
			while (reader.Read())
			{
				switch(reader.Name.ToLower())
				{
					case "summary": variant.summary = StringHelper.CleanMultiLine(reader.ReadElementContentAsString().Trim()); break;
					case "returns": variant.returns = StringHelper.CleanMultiLine(reader.ReadElementContentAsString().Trim()); break;
					case "param": {
						DocParam p = new DocParam();
						p.name    = reader.GetAttribute("name");
						p.summary = reader.ReadElementContentAsString().Trim();
						variant.parameters.Add(p);
					} break;
					case "inheritdoc": {
						inheritMethods.Add(new DocInheritMethod(variant, reader.GetAttribute("cref")));
					} break;
				}
			}
		}

		static string WriteIndex()
		{
			DocIndexFolder root = new DocIndexFolder("Pages", true);

			foreach (string space in namespaces)
			{
				int used = classes.FindIndex(c=>c.nameSpace == space);
				if (used == -1) continue;

				DocIndexFolder spaceFolder = new DocIndexFolder(space, true);
				root.folders.Add(spaceFolder);

				foreach (DocClass currClass in classes)
				{
					if (currClass.nameSpace != space) continue;

					DocIndexFolder classFolder = new DocIndexFolder(currClass.Name, true);
					spaceFolder.folders.Add(classFolder);

					// Enums don't need child items, it's a little much.
					if (currClass.IsEnum) continue;

					foreach (DocField  f in currClass.fields)  classFolder.folders.Add(new DocIndexFolder(f.name,     true));
					foreach (DocMethod m in currClass.methods) classFolder.folders.Add(new DocIndexFolder(m.ShowName, true));
				}
			}

			DocExampleFinder.examples.Sort((a,b)=>a.info.CompareTo(b.info));
			for (int e = 0; e < DocExampleFinder.examples.Count; e++)
			{
				DocExample ex = DocExampleFinder.examples[e];
				if (ex.type == ExampleType.Document)
				{
					DocIndexFolder folder = null;
					if (ex.category.ToLower() == "root")
						folder = root;
					else
						folder = root.folders.Find((a) => a.name == ex.category);
					if (folder == null)
					{
						folder = new DocIndexFolder(ex.category, false, ex.SortIndex);
						root.folders.Add(folder);
					}
					folder.folders.Add(new DocIndexFolder( ex.Name, false, ex.SortIndex));
				}
			}

			// Sort all the folders!
			foreach(var f in root.folders)
			{
				if (f.alphaSort) f.folders.Sort((a, b) => string.Compare(a.name, b.name));
				else             f.folders.Sort((a, b) => a.order - b.order);
			}
			root.folders.Sort((a,b)=>string.Compare(a.name,b.name));

			return root.ToString();
		}
	}
}
