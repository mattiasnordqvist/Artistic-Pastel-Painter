using System.Collections.Generic;
using System.Drawing;

namespace ArtisticPastelPainter
{
    public class RainbowBrush : ArtisticBrush
    {
        private int? _fixedRainbowSize;
        private int? _nrOfRainbows;

        public RainbowBrush() : base(new MatchAll()) { }
        public static RainbowBrush FixedRainbowSize(int fixedRainbowSize)
        {
            return new RainbowBrush { _fixedRainbowSize = fixedRainbowSize };
        }

        public static RainbowBrush FixedNrOfRainbows(int nrOfRainbows)
        {
            return new RainbowBrush { _nrOfRainbows = nrOfRainbows };
        }


        public new IRegionMatcher Matcher
        {
            set { base.Matcher = value; }
            get { return base.Matcher; }
        }

        protected override void Unleash(ArtisticString coloredString, int index, int length)
        {
            var rainbowSize = _fixedRainbowSize ?? (_nrOfRainbows.HasValue ? (length / _nrOfRainbows) : length);
            var rainbow = new Rainbow(rainbowSize.Value).Colors.GetEnumerator();
            for (int i = index; i < index+length; i++)
            {
                rainbow.MoveNext();
                coloredString.PaintYourself(i, 1, rainbow.Current);
            }
        }

        private class Rainbow
        {
            private readonly int nrOfColors;

            public Rainbow(int nrOfColors)
            {
                this.nrOfColors = nrOfColors;
            }
            public IEnumerable<Color> Colors
            {
                get
                {
                    while (true)
                    {
                        int step = 0;
                        while (step < nrOfColors)
                        {
                            yield return GetRainbowColor(nrOfColors, step);
                            step++;
                        }
                    }
                }
            }

            private static Color GetRainbowColor(int numOfSteps, int step)
            {
                var r = 0.0;
                var g = 0.0;
                var b = 0.0;
                var h = (double)step / numOfSteps;
                var i = (int)(h * 6);
                var f = h * 6.0 - i;
                var q = 1 - f;

                switch (i % 6)
                {
                    case 0:
                        r = 1;
                        g = f;
                        b = 0;
                        break;
                    case 1:
                        r = q;
                        g = 1;
                        b = 0;
                        break;
                    case 2:
                        r = 0;
                        g = 1;
                        b = f;
                        break;
                    case 3:
                        r = 0;
                        g = q;
                        b = 1;
                        break;
                    case 4:
                        r = f;
                        g = 0;
                        b = 1;
                        break;
                    case 5:
                        r = 1;
                        g = 0;
                        b = q;
                        break;
                }
                return Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
            }
        }
    }
}
