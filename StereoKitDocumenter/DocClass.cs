using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StereoKitDocumenter
{
	class DocClass : IDocItem
	{
		public string nameSpace;
		public string name;
		public string summary;
		public List<DocMethod>  methods  = new List<DocMethod>();
		public List<DocField>   fields   = new List<DocField>();
		public List<DocExample> examples = new List<DocExample>();

		public string Name      { get {
				int generic = name.IndexOf('`');
				 return generic != -1 
					? name.Substring(0, generic)
					: name; } }
		public string FileName  => $"{Program.options.PagesOut}{nameSpace}/{Name}.md";
		public string UrlName   => $"{{{{site.url}}}}/Pages/{nameSpace}/{Name}.html";
		public Type   ClassType => Type.GetType($"{nameSpace}.{name.Replace('.', '+')}, StereoKit");
		public bool   IsEnum    => ClassType.IsEnum;

		public void AddExample(DocExample aExample) => examples.Add(aExample);

		private string ToStringBase(Func<DocField, string> fieldToString, Func<DocField, string> enumToString, Func<DocMethod, string> methodToString, bool addExamples)
		{
			Type t = ClassType;
			methods.Sort((a,b)=>a.name.CompareTo(b.name));
			fields .Sort((a,b)=>a.name.CompareTo(b.name));
			List<DocMethod> methodsStatic   = methods.FindAll(a =>  a.IsStatic && !a.isOp);
			List<DocMethod> methodsInstance = methods.FindAll(a => !a.IsStatic && !a.isOp);
			List<DocMethod> methodsOperator = methods.FindAll(a =>  a.isOp);
			List<DocField>  fieldsStatic    = fields.FindAll(a =>  a.GetStatic(t));
			List<DocField>  fieldsInstance  = fields.FindAll(a => !a.GetStatic(t));

			string classDescription = "";
			if      (t.IsEnum)      classDescription = "enum";
			else if (t.IsClass)     classDescription = "class";
			else if (t.IsValueType) classDescription = "struct";
			if (t.IsAbstract && t.IsSealed) classDescription = "static " + classDescription;

			string memberText = methodsInstance.Count == 0 ? 
				"" : "\n\n## Instance Methods\n\n|  |  |\n|--|--|\n";
			memberText += string.Join("\n", methodsInstance
				.Select(methodToString));

			string fieldText = fieldsInstance.Count == 0 ? 
				"" : "\n\n## Instance Fields and Properties\n\n|  |  |\n|--|--|\n";
			fieldText += string.Join("\n", fieldsInstance
				.Select(fieldToString));

			string memberTextStatic = methodsStatic.Count == 0 ?
				"" : "\n\n## Static Methods\n\n|  |  |\n|--|--|\n";
			memberTextStatic += string.Join("\n", methodsStatic
				.Select(methodToString));

			string memberTextOps = methodsOperator.Count == 0 ?
				"" : "\n\n## Operators\n\n|  |  |\n|--|--|\n";
			memberTextOps += string.Join("\n", methodsOperator
				.Select(methodToString));

			string fieldTextStatic;
			if (t.IsEnum) {
				fieldTextStatic = fieldsStatic.Count == 0 ?
					"" : "\n\n## Enum Values\n\n|  |  |\n|--|--|\n";
				fieldTextStatic += string.Join("\n", fieldsStatic
					.Select(enumToString));
			} else {
				fieldTextStatic = fieldsStatic.Count == 0 ?
					"" : "\n\n## Static Fields and Properties\n\n|  |  |\n|--|--|\n";
				fieldTextStatic += string.Join("\n", fieldsStatic
					.Select(fieldToString));
			}

			string exampleText = "";
			if (examples.Count > 0 && addExamples == true)
			{
				exampleText = "\n\n## Examples\n\n";
				for (int i = 0; i < examples.Count; i++) {
					exampleText += examples[i].data;
				}
				exampleText = exampleText.TrimEnd() + "\n";
			}

			return $@"
# {classDescription} {Name}

{summary}{fieldText}{memberText}{fieldTextStatic}{memberTextStatic}{memberTextOps}{exampleText}";
		}

		public override string ToString()
		{
			Type t = ClassType;
			Func<DocField,  string> fieldToString  = (f) => { return $"|{StringHelper.TypeName(f.GetFieldType(t).Name, LinkType.MDWeb)} [{f.name}]({f.UrlName})|{StringHelper.CleanForTable(f.summary)}|"; };
			Func<DocField,  string> enumToString   = (e) => { return $"|{e.name}|{StringHelper.CleanForTable(e.summary)}|"; };
			Func<DocMethod, string> methodToString = (m) => { return $"|[{m.ShowName}]({m.UrlName})|{StringHelper.CleanForTable(m.overloads[0].summary)}|"; };

			return $@"---
layout: default
title: {Name}
description: {StringHelper.CleanForDescription(summary)}
---
{ToStringBase(fieldToString, enumToString, methodToString, true)}";
		}

		public string ToStringSinglePage(bool links)
		{
			Type t = ClassType;

			string classDescription = "";
			if      (t.IsEnum)      classDescription = "enum";
			else if (t.IsClass)     classDescription = "class";
			else if (t.IsValueType) classDescription = "struct";
			if (t.IsAbstract && t.IsSealed) classDescription = "static " + classDescription;
			return $@"# {classDescription} {Name}

{summary}

";

			Func<DocField,  string> fieldToString  = (f) => { return $"|{StringHelper.TypeName(f.GetFieldType(t).Name, LinkType.MDSingle)} [{f.name}]({StringHelper.MarkdownLink(f.Name)})|{StringHelper.CleanForTable(f.summary)}|"; };
			Func<DocField,  string> enumToString   = (e) => { return $"|{e.name}|{StringHelper.CleanForTable(e.summary)}|"; };
			Func<DocMethod, string> methodToString = (m) => { return $"|[{m.ShowName}]({StringHelper.MarkdownLink(m.Name)})|{StringHelper.CleanForTable(m.overloads[0].summary)}|"; };
			if (!links)
			{
				fieldToString  = (f) => { return $"|{StringHelper.TypeName(f.GetFieldType(t).Name, LinkType.None)} {f.name}|{StringHelper.CleanForTable(f.summary)}|"; };
				enumToString   = (e) => { return $"|{e.name}|{StringHelper.CleanForTable(e.summary)}|"; };
				methodToString = (m) => { return $"|{m.ShowName}|{StringHelper.CleanForTable(m.overloads[0].summary)}|"; };
			}

			return ToStringBase(fieldToString, enumToString, methodToString, false);
		}
	}
}
