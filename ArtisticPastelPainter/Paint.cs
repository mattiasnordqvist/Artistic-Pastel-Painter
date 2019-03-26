using System.Drawing;

namespace ArtisticPastelPainter
{
    public struct Paint
    {
        public Color? background;
        public Color? foreground;
        public bool? underline;

        public Paint(Color? background, Color? foreground, bool? underline) : this()
        {
            this.background = background;
            this.foreground = foreground;
            this.underline = underline;
        }
    }
}
