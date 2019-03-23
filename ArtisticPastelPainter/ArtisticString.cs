using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Pastel;

namespace ArtisticPastelPainter
{
    public class ArtisticString
    {
        public string Value { get; private set; }
        private List<(Color with, int from, int to)> colors = new List<(Color with, int from, int to)>();
        public ArtisticString(string value, Color baseColor)
        {
            Value = value;
            PaintYourself(baseColor, 0, value.Length);
        }

        public void PaintYourself(Color with, int from, int to)
        {
            colors.Add((with, from, to));
        }

        public void PaintYourself(ArtisticRegexBrush artisticRegexBrush)
        {
            artisticRegexBrush.Unleash(this);
        }

        public static implicit operator string(ArtisticString artisticString)
        {
            return artisticString.ToString();
        }

        public static implicit operator ArtisticString(string @string)
        {
            return new ArtisticString(@string, Color.White);
        }

        public override string ToString()
        {
            var colors = this.colors.Flatten(Value.Length).Compress();
            if (colors.Sum(x => x.count) != Value.Length)
            {
                throw new Exception();
            }
            var i = 0;
            var sb = new StringBuilder();
            foreach (var c in colors)
            {
                sb.Append(Value.Substring(i, c.count).Pastel(c.value));
                i += c.count;
            }
            return sb.ToString();
        }
    }
}
