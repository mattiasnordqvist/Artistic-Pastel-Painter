using System.Collections.Generic;

namespace ArtisticPastelPainter
{
    public class MatchAll : IRegionMatcher
    {
        public IEnumerable<StringRegion> Match(string value)
        {
            yield return new StringRegion(0, value.Length);
        }
    }
}
