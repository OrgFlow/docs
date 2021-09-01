using System;
using Microsoft.DocAsCode.Dfm;
using Microsoft.DocAsCode.MarkdownLite;

namespace Plugins.Renderers
{
	public class LeapNoteRendererPart : DfmCustomizedRendererPartBase<IMarkdownRenderer, DfmNoteBlockSplitToken, MarkdownBlockContext>
	{
		public override string Name => "LeapNoteRendererPart";

		public override bool Match(IMarkdownRenderer renderer, DfmNoteBlockSplitToken token, MarkdownBlockContext context)
		{
			return true;
		}

		public override StringBuffer Render(IMarkdownRenderer renderer, DfmNoteBlockSplitToken token, MarkdownBlockContext context)
		{
			var noteType = ((DfmNoteBlockToken)token.Token).NoteType.ToLowerInvariant();

			var alertClass = noteType switch
			{
				"note" => "info",
				"tip" => "success",
				"warning" => "warning",
				"important" => "danger",
				"caution" => "danger",
				_ => "secondary"
			};

			var sb = StringBuffer.Empty;

			sb += $"<div class=\"alert alert-{alertClass}\">";

			sb += $"<div class=\"d-flex align-items-center\">";
			sb += $"<img class=\"note-icon icon icon-md bg-{alertClass} mr-1\" src=\"/assets/img/icons/note/{noteType}.svg\" alt=\"{noteType} icon\" data-inject-svg />";
			sb += $"<h5 class=\"alert-heading text-capitalize my-0\">{noteType}</h5>";
			sb += "</div>";

            foreach (var item in token.InnerTokens)
            {
                sb += renderer.Render(item);
            }

			sb += "</div>";

			return sb;
		}
	}
}
