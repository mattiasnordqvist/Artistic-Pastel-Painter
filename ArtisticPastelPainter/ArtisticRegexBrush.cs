using System.Drawing;
using System.Text.RegularExpressions;

namespace ArtisticPastelPainter
{
    public class ArtisticRegexBrush : IArtisticBrush
    {
        private readonly string _regex;

        public ArtisticRegexBrush(string regex, Color color)
        {
            _regex = regex;
            Color = color;
        }

        public Color Color { get; private set; }

        public void Unleash(ArtisticString coloredString)
        {
            var matches = Regex.Matches(coloredString.Value, _regex);
            foreach (Match match in matches)
            {
                coloredString.PaintYourself(Color, match.Index, match.Index + match.Length - 1);
            }
        }
    }
}
