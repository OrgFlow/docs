using Microsoft.DocAsCode.Dfm;
using Microsoft.DocAsCode.MarkdownLite;
using System.Collections.Generic;
using System.Composition;

namespace Plugins.Renderers
{
	public class CustomBlockCodeRendererPart : DfmCustomizedRendererPartBase<IMarkdownRenderer, MarkdownCodeBlockToken, MarkdownBlockContext>
	{
		public override string Name => "MyFirstCustomRendererPart";

		public override bool Match(IMarkdownRenderer renderer, MarkdownCodeBlockToken token, MarkdownBlockContext context)
		{
			return true;
		}

		public override StringBuffer Render(IMarkdownRenderer renderer, MarkdownCodeBlockToken token, MarkdownBlockContext context)
		{
			StringBuffer result = "<pre><code class=\"";
			result += renderer.Options.LangPrefix;
			result += "csharp";
			result += "\">";
			result += "show me the codez";
			result += "\n</code></pre>";
			return result;
		}
	}
	public class LeapTabGroupRendererPart : DfmCustomizedRendererPartBase<IMarkdownRenderer, DfmTabGroupBlockToken, MarkdownBlockContext>
	{
		public override string Name => "LeapTabRendererPart";

		public override bool Match(IMarkdownRenderer renderer, DfmTabGroupBlockToken token, MarkdownBlockContext context)
		{
			return true;
		}

		public override StringBuffer Render(IMarkdownRenderer renderer, DfmTabGroupBlockToken token, MarkdownBlockContext context)
		{
			return "This is the tab group block";
		}
	}
	public class LeapDfmTabTitleBlockTokenRendererPart : DfmCustomizedRendererPartBase<IMarkdownRenderer, DfmTabTitleBlockToken, MarkdownBlockContext>
	{
		public override string Name => "LeapTabRendererPartDfmTabTitleBlockToken";

		public override bool Match(IMarkdownRenderer renderer, DfmTabTitleBlockToken token, MarkdownBlockContext context)
		{
			return true;
		}

		public override StringBuffer Render(IMarkdownRenderer renderer, DfmTabTitleBlockToken token, MarkdownBlockContext context)
		{
			return "This is the DfmTabTitleBlockToken";
		}
	}
	public class LeapTabDfmTabItemBlockTokenRendererPart : DfmCustomizedRendererPartBase<IMarkdownRenderer, DfmTabItemBlockToken, MarkdownBlockContext>
	{
		public override string Name => "LeapTabRendererPartDfmTabItemBlockToken";

		public override bool Match(IMarkdownRenderer renderer, DfmTabItemBlockToken token, MarkdownBlockContext context)
		{
			return true;
		}

		public override StringBuffer Render(IMarkdownRenderer renderer, DfmTabItemBlockToken token, MarkdownBlockContext context)
		{
			return "This is the DfmTabItemBlockToken";
		}
	}
	public class LeapDfmTabContentBlockTokenTokenRendererPart : DfmCustomizedRendererPartBase<IMarkdownRenderer, DfmTabContentBlockToken, MarkdownBlockContext>
	{
		public override string Name => "LeapTabRendererDfmTabContentBlockToken";

		public override bool Match(IMarkdownRenderer renderer, DfmTabContentBlockToken token, MarkdownBlockContext context)
		{
			return true;
		}

		public override StringBuffer Render(IMarkdownRenderer renderer, DfmTabContentBlockToken token, MarkdownBlockContext context)
		{
			return "This is the DfmTabContentBlockToken";
		}
	}

	[Export(typeof(IDfmCustomizedRendererPartProvider))]
	public class CustomBlockCodeRendererPartProvider : IDfmCustomizedRendererPartProvider
	{
		public IEnumerable<IDfmCustomizedRendererPart> CreateParts(IReadOnlyDictionary<string, object> parameters)
		{
			yield return new CustomBlockCodeRendererPart();
			yield return new LeapTabGroupRendererPart();
			yield return new LeapDfmTabTitleBlockTokenRendererPart();
			yield return new LeapTabDfmTabItemBlockTokenRendererPart();
			yield return new LeapDfmTabContentBlockTokenTokenRendererPart();
		}
	}
}
