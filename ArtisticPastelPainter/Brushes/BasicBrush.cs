using System.Drawing;

namespace ArtisticPastelPainter
{
    public class BasicBrush : IArtisticBrush
    {
        public BasicBrush(Color foreground, Color? background = null, bool? underline = null)
        {
            Paint = new Paint(background, foreground, underline);
        }

        public BasicBrush(Color? foreground = null, Color? background = null, bool? underline = null)
        {
            Paint = new Paint(background, foreground, underline);
        }

        public Paint Paint { get; private set; }

        public void Unleash(ArtisticString coloredString)
        {
            coloredString.PaintYourself(0, coloredString.Value.Length, Paint);
        }
    }
}
