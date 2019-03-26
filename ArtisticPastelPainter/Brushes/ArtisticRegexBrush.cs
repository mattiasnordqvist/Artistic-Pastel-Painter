using System.Drawing;

namespace ArtisticPastelPainter
{
    public class ArtisticRegexBrush : ArtisticBrush
    {

        public ArtisticRegexBrush(string regex, Color foreground, Color? background = null, bool? underline = null) : base(new RegexRegionMatcher(regex))
        {
            Paint = new Paint(background, foreground, underline);
        }

        public ArtisticRegexBrush(string regex, Color? foreground = null, Color? background = null, bool? underline = null) 
            : base(new RegexRegionMatcher(regex))
        {
            Paint = new Paint(background, foreground, underline);
        }

        public ArtisticRegexBrush(string regex, Paint paint) : base(new RegexRegionMatcher(regex))
        {
            Paint = paint;
        }

        public Paint Paint { get; private set; }

        protected override void Unleash(ArtisticString coloredString, int index, int length)
        {
            coloredString.PaintYourself(index, length, Paint);
        }
    }
}
