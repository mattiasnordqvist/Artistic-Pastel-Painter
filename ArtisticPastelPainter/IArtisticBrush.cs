using System.Drawing;

namespace ArtisticPastelPainter
{
    public interface IArtisticBrush
    {
        Color Color { get; }

        void Unleash(ArtisticString coloredString);
    }
}
