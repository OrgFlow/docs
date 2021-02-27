using Microsoft.DocAsCode.Dfm;
using System.Collections.Generic;
using System.Composition;

namespace Plugins.Renderers
{
	[Export(typeof(IDfmCustomizedRendererPartProvider))]
	public class LeapRendererPartProvider : IDfmCustomizedRendererPartProvider
	{
		public IEnumerable<IDfmCustomizedRendererPart> CreateParts(IReadOnlyDictionary<string, object> parameters)
		{
			yield return new LeapTabGroupRendererPart();
		}
	}
}