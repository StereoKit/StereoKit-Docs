using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StereoKitDocumenter
{
	// Emits an AI-friendly, token-efficient version of the docs alongside the
	// human-facing Jekyll site. Reuses the same in-memory model the rest of the
	// documenter builds (Program.classes / DocExampleFinder.examples), but strips
	// the HTML wrappers, empty-header tables, Liquid links, and front-matter that
	// make the site pages poor input for coding agents.
	//
	// The format is tuned for grep-style lookup: every member line is
	// self-contained and class-qualified (e.g. "Backend.D3D11.D3DContext"), so a
	// single matching line carries enough context to be useful on its own.
	//
	// Output (into the site root so they're served at https://stereokit.net/<file>):
	//   StereoKit-docs-API.md       - condensed API (signatures + summaries + params)
	//   StereoKit-docs-reference.md - conceptual guides + runnable code samples
	//   llms.txt                    - thin discovery pointer (llms.txt convention)
	static class DocAI
	{
		const string Site    = "https://stereokit.net";
		const string Summary = "StereoKit is a lightweight, low-dependency C# library for XR apps and games built on OpenXR.";

		const string ApiFile       = "StereoKit-docs-API.md";
		const string ReferenceFile = "StereoKit-docs-reference.md";
		const string LlmsFile      = "llms.txt";

		public static void Write(string aiOutDir)
		{
			if (!aiOutDir.EndsWith("/") && !aiOutDir.EndsWith("\\"))
				aiOutDir += "/";
			Directory.CreateDirectory(aiOutDir);

			Console.WriteLine("Building AI-friendly docs...");
			File.WriteAllText(aiOutDir + ApiFile,       WriteApiDoc());
			File.WriteAllText(aiOutDir + ReferenceFile, WriteReferenceDoc());
			File.WriteAllText(aiOutDir + LlmsFile,      WriteLlms());
		}

		// Self-describing header placed atop every .md file, so that if one is
		// copied into a project or read on its own, the agent still knows the
		// rest of the set exists and what each file holds.
		static string Header(string role, string selfFile)
		{
			string Bullet(string file, string desc) =>
				file == selfFile ? $"- **{file}** — {desc} (this file)" : $"- {file} — {desc}";

			return
$@"# StereoKit — {role}

{Summary}
This file is part of a 2-file AI-friendly documentation set:
{Bullet(ApiFile,       "condensed API reference for every type — signatures, summaries, parameters")}
{Bullet(ReferenceFile, "conceptual guides and runnable C# code examples, one section per API member")}
Source: {Site}  (generated from StereoKit's XML doc comments)
";
		}

		// Authored sample/guide prose embeds Jekyll Liquid for the live site
		// (image and cross-doc links). Resolve those to absolute URLs so the
		// AI docs stand alone. Values mirror docs/_config.yml (url, screen_url).
		static string Resolve(string data)
		{
			if (string.IsNullOrEmpty(data)) return data;
			return data
				.Replace("{{site.screen_url}}", $"{Site}/img/screenshots")
				.Replace("{{site.url}}",        Site);
		}

		// Collapse a (possibly multi-line) doc summary to a single trimmed line.
		static string OneLine(string text)
		{
			if (string.IsNullOrEmpty(text)) return "";
			return string.Join(" ", text
				.Replace("\r", " ")
				.Split('\n')
				.Select(l => l.Trim())
				.Where(l => l.Length > 0));
		}

		static IEnumerable<DocClass> SortedClasses() =>
			Program.classes.OrderBy(c => c.nameSpace).ThenBy(c => c.Name);

		static List<DocExample> Guides() => DocExampleFinder.examples
			.Where(e => e.type == ExampleType.Document)
			.OrderBy(e => e.category)
			.ThenBy(e => e.SortIndex)
			.ToList();

		// ---- StereoKit-docs-API.md ---------------------------------------------

		static string WriteApiDoc()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(Header("API Reference", ApiFile));

			foreach (DocClass c in SortedClasses())
				sb.Append(ReferenceForClass(c));

			return sb.ToString();
		}

		static string ReferenceForClass(DocClass c)
		{
			Type          t  = c.ClassType;
			StringBuilder sb = new StringBuilder();

			string kind = c.IsEnum ? "enum"
				: t.IsInterface ? "interface"
				: typeof(Delegate).IsAssignableFrom(t) ? "delegate"
				: t.IsValueType ? "struct"
				: (t.IsAbstract && t.IsSealed) ? "static class"
				: "class";

			sb.Append($"\n## {kind} {c.Name}\n");
			string summary = OneLine(c.summary);
			if (summary.Length > 0) sb.Append($"\n{summary}\n");

			List<DocField> fields = c.fields.OrderBy(f => f.name).ToList();

			if (c.IsEnum)
			{
				sb.Append('\n');
				foreach (DocField f in fields)
					sb.Append(MemberLine($"{c.Name}.{f.name}", f.summary));
				return sb.ToString();
			}

			// Static fields/properties are always shown; instance members only
			// when public (mirrors the filtering in DocClass.ToString). Instance
			// first, then static, alphabetical within each — the `static` keyword
			// on the line itself distinguishes them, so no sub-headers needed.
			List<DocField> shown = fields
				.Where(f => f.GetStatic(t) || IsPublic(t, f))
				.OrderBy(f => f.GetStatic(t) ? 1 : 0)
				.ThenBy(f => f.name)
				.ToList();
			if (shown.Count > 0) sb.Append('\n');
			foreach (DocField f in shown)
			{
				Type   ft   = f.GetFieldType(t);
				string type = ft != null ? StringHelper.TypeName(ft.Name, false) : "";
				string head = ((f.GetStatic(t) ? "static " : "") + $"{type} {c.Name}.{f.name}").Trim();
				sb.Append(MemberLine(head, f.summary));
			}

			foreach (DocMethod m in c.methods.OrderBy(m => m.name))
				sb.Append(MethodBullets(c, m));

			return sb.ToString();
		}

		static string MemberLine(string head, string summary)
		{
			string s = OneLine(summary);
			return s.Length > 0 ? $"- `{head}` — {s}\n" : $"- `{head}`\n";
		}

		static string MethodBullets(DocClass c, DocMethod m)
		{
			StringBuilder sb = new StringBuilder();
			foreach (DocMethodOverload o in m.overloads)
			{
				string s = OneLine(o.summary);
				sb.Append(s.Length > 0 ? $"- `{o.QualifiedSignature}` — {s}\n" : $"- `{o.QualifiedSignature}`\n");
				foreach (DocParam p in o.parameters)
					sb.Append($"  - `{p.name}` — {OneLine(p.summary)}\n");
				if (!string.IsNullOrEmpty(o.returns))
					sb.Append($"  - returns — {OneLine(o.returns)}\n");
			}
			if (m.examples.Count > 0)
				sb.Append($"  - Example: see `{c.Name}.{m.ShowName}` in {ReferenceFile}\n");
			return sb.ToString();
		}

		static bool IsPublic(Type t, DocField f)
		{
			TypeInfo  ti = t.GetTypeInfo();
			FieldInfo fi = ti.GetDeclaredField(f.name);
			if (fi != null) return fi.IsPublic;
			PropertyInfo pi = ti.GetDeclaredProperty(f.name);
			return pi != null && pi.DeclaringType.IsPublic;
		}

		// ---- StereoKit-docs-reference.md ---------------------------------------

		// Conceptual guides followed by every :CodeSample:. Each sample is emitted
		// under a greppable "Class.Member" heading. A sample can be attached to
		// several members; we emit its code exactly once and cross-reference the
		// rest (the `seen` set keys on the sample's object identity).
		static string WriteReferenceDoc()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(Header("Guides & Examples", ReferenceFile));

			List<DocExample> guides = Guides();
			if (guides.Count > 0)
			{
				sb.Append("\n# Guides\n");
				foreach (DocExample g in guides)
					sb.Append($"\n## {g.info}\n\n{Resolve(g.data.Trim())}\n");
			}

			sb.Append("\n# Examples\n");
			Dictionary<DocExample, string> seen = new Dictionary<DocExample, string>();
			foreach (DocClass c in SortedClasses())
			{
				foreach (DocField f in c.fields.OrderBy(f => f.name))
					AppendExamples(sb, seen, $"{c.Name}.{f.name}", f.examples);
				foreach (DocMethod m in c.methods.OrderBy(m => m.name))
					AppendExamples(sb, seen, $"{c.Name}.{m.ShowName}", m.examples);
				AppendExamples(sb, seen, c.Name, c.examples);
			}
			return sb.ToString();
		}

		static void AppendExamples(StringBuilder sb, Dictionary<DocExample, string> seen, string heading, List<DocExample> examples)
		{
			foreach (DocExample ex in examples)
			{
				if (seen.TryGetValue(ex, out string firstHeading))
				{
					sb.Append($"\n## {heading}\n\nSee `{firstHeading}`\n");
				}
				else
				{
					seen[ex] = heading;
					sb.Append($"\n## {heading}\n\n{Resolve(ex.data.Trim())}\n");
				}
			}
		}

		// ---- llms.txt ----------------------------------------------------------

		static string WriteLlms()
		{
			return
$@"# StereoKit

> {Summary}

## Docs

- [API reference]({Site}/{ApiFile}): every type, with class-qualified signatures, summaries, and parameters.
- [Guides & examples]({Site}/{ReferenceFile}): conceptual guides and runnable C# samples, one section per API member.

## Optional

- [Website]({Site}): full human-facing documentation, guides, and screenshots.
";
		}
	}
}
