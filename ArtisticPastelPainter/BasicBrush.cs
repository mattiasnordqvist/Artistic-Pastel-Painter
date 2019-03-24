using System.Drawing;

namespace ArtisticPastelPainter
{
    public class BasicBrush : IArtisticBrush
    {
        public BasicBrush(Color foreground, Color? background = null)
        {
            Color = (background, foreground);
        }

        public BasicBrush(Color? foreground = null, Color? background = null)
        {
            Color = (background, foreground);
        }

        public (Color? background, Color? foreground) Color { get; private set; }

        public void Unleash(ArtisticString coloredString)
        {
            coloredString.PaintYourself(0, coloredString.Value.Length, Color);
        }
    }
}
