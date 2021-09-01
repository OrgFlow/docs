using System;
using Microsoft.DocAsCode.Dfm;
using Microsoft.DocAsCode.MarkdownLite;

namespace Plugins.Renderers
{
	public class TermynalCodeRendererPart : DfmCustomizedRendererPartBase<IMarkdownRenderer, MarkdownCodeBlockToken, MarkdownBlockContext>
	{
		public override string Name => "TermynalCodeRendererPart";

		public override bool Match(IMarkdownRenderer renderer, MarkdownCodeBlockToken token, MarkdownBlockContext context)
		{
			return token.Lang?.ToLowerInvariant() == "termynal";
		}

		public override StringBuffer Render(IMarkdownRenderer renderer, MarkdownCodeBlockToken token, MarkdownBlockContext context)
		{
			StringBuffer result = "<div class=\"termynal\" data-termynal data-ty-typeDelay=\"20\" data-ty-lineDelay=\"200\">";

			var lines = token.Code.Split(new[] { "\n" }, StringSplitOptions.None);
			for (var i = 0; i < lines.Length; i++ )
			{
				var line = lines[i];
				if (line.Length == 0)
				{
					result += "<span data-ty></span>";
					continue;
				}

				switch (line[0])
				{
					case '$':
						result += $"<span data-ty=\"input\">{line.Remove(0, 1).Replace(" ", "&nbsp;")}</span>";
						continue;
					case '%':
						result += $"<span data-ty=\"progress\"></span>";
						continue;
					case '?':
						var response = "";
						if (i + 1 < lines.Length)
						{
							var nextLine = lines[i + 1];

							if (nextLine.Length > 0 && nextLine[0] == '=')
							{
								response = nextLine.Remove(0, 1);
								i++;
							}
						}

						result += $"<span data-ty=\"input\" data-ty-prompt=\"{line.Remove(0, 1).Replace(" ", "&nbsp;")}\">{response}</span>";
						continue;
					default:
						if (line[0] == '\\')
						{
							line = line.Remove(0, 1);
						}

						result += $"<span data-ty>{line.Replace(" ", "&nbsp;")}</span>";

						break;
				}
			}

			result += "</div>";

			return result;
		}
	}
}
