using System.Drawing;
using System.Text.RegularExpressions;

namespace ArtisticPastelPainter
{
    public class ArtisticRegexBrush : IArtisticBrush
    {
        private readonly string _regex;

        public ArtisticRegexBrush(string regex, Color foreground, Color? background = null)
        {
            _regex = regex;
            Color = (background, foreground);
        }

        public ArtisticRegexBrush(string regex, Color? foreground = null, Color? background = null)
        {
            _regex = regex;
            Color = (background, foreground);
        }

        public (Color? background, Color? foreground) Color { get; private set; }

        public void Unleash(ArtisticString coloredString)
        {
            var matches = Regex.Matches(coloredString.Value, _regex);
            foreach (Match match in matches)
            {
                coloredString.PaintYourself(match.Index, match.Length, Color);
            }
        }
    }
}
