using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ArtisticPastelPainter
{
    public class RegexRegionMatcher : IRegionMatcher
    {
        private readonly string regex;

        public RegexRegionMatcher(string regex)
        {
            this.regex = regex;

        }

        public IEnumerable<StringRegion> Match(string value)
        {
            return Regex.Matches(value, regex)
                .OfType<Match>()
                .Select(x => new StringRegion(x.Index, x.Length));
        }
    }
}
