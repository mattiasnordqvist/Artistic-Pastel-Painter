using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ArtisticPastelPainter
{
    public class ArtisticPainter
    {
        private List<IArtisticBrush> _brushes = new List<IArtisticBrush>();
        public void Unleash(ArtisticString s)
        {
            foreach (var brush in _brushes)
            {
                brush.Unleash(s);
            }
        }

        public ArtisticPainter BeCreativeWith(IArtisticBrush rule)
        {
            _brushes.Add(rule);
            return this;
        }

        private static List<(string s, bool isMatch)> Split(string input, string regex)
        {

            var values = new List<(string, bool)>();
            int pos = 0;
            foreach (Match m in Regex.Matches(input, regex))
            {
                var v = input.Substring(pos, m.Index - pos);
                if (!string.IsNullOrEmpty(v))
                {
                    values.Add((input.Substring(pos, m.Index - pos), false));
                }
                values.Add((m.Value, true));
                pos = m.Index + m.Length;
            }
            var vEnd = input.Substring(pos);
            if (!string.IsNullOrEmpty(vEnd))
            {
                values.Add((vEnd, false));
            }
            return values;
        }
    }
}
