using System.Drawing;

namespace ArtisticPastelPainter
{
    public class ArtisticRegexBrush : ArtisticBrush
    {

        public ArtisticRegexBrush(string regex, Color foreground, Color? background = null) : base(new RegexRegionMatcher(regex))
        {
            Color = (background, foreground);
        }

        public ArtisticRegexBrush(string regex, Color? foreground = null, Color? background = null) : base(new RegexRegionMatcher(regex))
        {
            Color = (background, foreground);
        }

        public (Color? background, Color? foreground) Color { get; private set; }

        protected override void Unleash(ArtisticString coloredString, int index, int length)
        {
            coloredString.PaintYourself(index, length, Color);
        }
    }
}
