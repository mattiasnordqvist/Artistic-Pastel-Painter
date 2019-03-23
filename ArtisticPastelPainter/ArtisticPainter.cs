using System.Collections.Generic;

namespace ArtisticPastelPainter
{
    public class ArtisticPainter
    {
        private List<IArtisticBrush> _brushes = new List<IArtisticBrush>();
        public string Unleash(ArtisticString s)
        {
            foreach (var brush in _brushes)
            {
                brush.Unleash(s);
            }
            return s;
        }

        public ArtisticPainter BeCreativeWith(IArtisticBrush rule)
        {
            _brushes.Add(rule);
            return this;
        }
    }
}
