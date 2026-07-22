using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace StereoKitDocumenter
{
	static class StringHelper
	{
		public static string CleanForDescription(string text)
		{
			// Meta descriptions are plain text, so strip markdown links down
			// to just their display text.
			text = System.Text.RegularExpressions.Regex.Replace(text, @"\[([^\]]*)\]\([^\)]*\)", "$1");
			return text.Replace('\n', ' ')
						.Replace('\r', ' ')
						.Replace(':', '.')
						.Replace("`", "");
		}

		public static string XmlReaderToString(XmlReader reader)
		{
			string contents = "";
			XmlReader r = reader.ReadSubtree();
			while (r.Read())
			{
				// Note that this only ever reads r.Value, and never uses the
				// ReadContent functions! Those advance the reader themselves,
				// and interact badly with the loop's own Read.
				switch (r.NodeType)
				{
					case XmlNodeType.Element:
						if (r.Name == "see" || r.Name == "seealso")
						{
							string cref     = r.GetAttribute("cref");
							string langword = r.GetAttribute("langword");
							if      (cref     != null) contents += CrefLink(cref);
							else if (langword != null) contents += $"`{langword}`";
						}
						break;
					case XmlNodeType.Text:
					case XmlNodeType.Whitespace:
					case XmlNodeType.SignificantWhitespace:
					case XmlNodeType.CDATA:
						contents += r.Value;
						break;
				}
			}
			contents = contents.Trim();
			return CleanMultiLine(contents);
		}

		// Turns a doc-comment cref like
		// "M:StereoKit.Backend.Vulkan.QueueLock(StereoKit.BackendVulkanQueue)"
		// into a linked "[`Backend.Vulkan.QueueLock`]({{site.url}}/Pages/...)".
		// Doc pages follow a fixed layout, so URLs come straight from the cref:
		// types are Pages/{namespace}/{Type}.html, and members (including enum
		// values) are Pages/{namespace}/{Type}/{Member}.html.
		static string CrefLink(string cref)
		{
			char kind = '\0';
			if (cref.Length > 2 && cref[1] == ':') { kind = cref[0]; cref = cref.Substring(2); }
			int paren = cref.IndexOf('(');
			if (paren != -1)
				cref = cref.Substring(0, paren);

			string nameSpace = Program.GetNamespace(cref);
			string name      = nameSpace.Length > 0 && cref.Length > nameSpace.Length
				? cref.Substring(nameSpace.Length + 1)
				: cref;
			int generic = name.IndexOf('`');
			if (generic != -1)
				name = name.Substring(0, generic);

			// Constructors link to their type's page.
			if (name.EndsWith(".#ctor")) { name = name.Substring(0, name.Length - ".#ctor".Length); kind = 'T'; }

			int lastDot = name.LastIndexOf('.');
			if (nameSpace.Length == 0)
				return $"`{name}`";
			string url = kind == 'T' || lastDot == -1
				? $"{{{{site.url}}}}/Pages/{nameSpace}/{name}.html"
				: $"{{{{site.url}}}}/Pages/{nameSpace}/{name.Substring(0, lastDot)}/{name.Substring(lastDot + 1)}.html";
			return $"[`{name}`]({url})";
		}

		public static string CleanForTable(string text)
		{
			return text.Replace('\n', ' ')
						.Replace('\r', ' ');
		}

		public static string CleanMultiLine(string text)
		{
			return string.Join("\n", text
				.Split('\n')
				.Select(a=>a.Trim())
				.ToArray());
		}

		public static string TypeName(string type, bool embedLink = true)
		{
			switch(type)
			{
				case "Single" : return "float";
				case "Double" : return "double";
				case "Int32"  : return "int";
				case "UInt32" : return "uint";
				case "String" : return "string";
				case "Boolean": return "bool";
				case "Void"   : return "void";
				default: {
					return embedLink && Program.TryGetClass(type, out DocClass typeDoc)
						? $"[{type}]({typeDoc.UrlName})"
						: type;
				}
			}
		}

		public static List<string> SeparateGroupedString(char separator, string str)
		{
			List<string> result = new List<string>();
			string curr = "";

			int bracketCt = 0;
			int parenCt = 0;
			int braceCt = 0;
			for (int i = 0; i < str.Length; i++)
			{
				if      (str[i] == '{') braceCt++;
				else if (str[i] == '[') bracketCt++;
				else if (str[i] == '(') parenCt++;
				else if (str[i] == '}') braceCt--;
				else if (str[i] == ']') bracketCt--;
				else if (str[i] == ')') parenCt--;
				if (braceCt == 0 && parenCt == 0 && bracketCt == 0 && str[i] == separator) { 
					result.Add(curr);
					curr = "";
				}
				else curr += str[i];
			}
			result.Add( curr );
			return result;
		}
	}
}
