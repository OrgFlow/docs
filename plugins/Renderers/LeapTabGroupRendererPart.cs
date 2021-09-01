using System.Linq;
using Microsoft.DocAsCode.Dfm;
using Microsoft.DocAsCode.MarkdownLite;

namespace Plugins.Renderers
{
	public class LeapTabGroupRendererPart : DfmCustomizedRendererPartBase<IMarkdownRenderer, DfmTabGroupBlockToken, MarkdownBlockContext>
	{
		public override string Name => "LeapTabGroupRendererPart";

		public override bool Match(IMarkdownRenderer renderer, DfmTabGroupBlockToken token, MarkdownBlockContext context)
		{
			return true;
		}

		public override StringBuffer Render(IMarkdownRenderer renderer, DfmTabGroupBlockToken token, MarkdownBlockContext context)
		{
			var sb = StringBuffer.Empty;
			var visibleItems = token.Items.Where(x => x.Visible).ToArray();
			var activeItem = token.Items[token.ActiveTabIndex];

			sb += $"<div class=\"tab-group\">";

			sb += $"<ul class=\"nav\" role=\"tablist\">";

			foreach (var item in visibleItems)
			{
				var activeClass = item == activeItem ? "active" : "";
				sb += $"<li class=\"nav-item\" role=\"presentation\">";
				sb += $"<a class=\"nav-link btn btn-light {activeClass}\" id=\"{item.Id}-tab\" data-toggle=\"tab\" href=\"#{item.Id}\" role=\"tab\" aria-controls=\"{item.Id}\" aria-selected=\"true\">";

				sb += $"<img class=\"icon bg-primary\" src=\"/assets/img/icons/custom/{item.Id}.svg\" alt=\"{item.Id} icon\" data-inject-svg />";

				foreach (var titleContent in item.Title.Content.Tokens)
				{
					sb += renderer.Render(titleContent);
				}

				sb += $"</a>";
				sb += $"</li>";
			}

			sb += $"</ul>";

			sb += $"<div class=\"tab-content\">";

			foreach (var item in visibleItems)
			{
				var activeClass = item == activeItem ? "active" : "";
				sb += $"<div class=\"tab-pane {activeClass}\" id=\"{item.Id}\" role=\"tabpanel\" aria-labelledby=\"{item.Id}-tab\">";

				foreach (var content in item.Content.Content)
				{
					sb += renderer.Render(content);
				}

				sb += $"</div>";
			}

			sb += "</div>";

			sb += "</div>";

			return sb;
		}
	}
}
