using System.Collections.Generic;

namespace ArtisticPastelPainter
{
    public interface IRegionMatcher
    {
        IEnumerable<StringRegion> Match(string value);
    }
}
