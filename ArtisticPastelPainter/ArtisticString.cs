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
        private List<((Color? background, Color? foreground) with, int from, int to)> colors = new List<((Color? background, Color? foreground) with, int from, int to)>();
        public ArtisticString(string value, Color baseColor)
        {
            Value = value;
            PaintYourself(baseColor, 0, value.Length);
        }

        public void PaintYourself(Color with, int index, int length)
        {
            colors.Add(((background: null, foreground: with), index, index + length - 1));
        }

        public void PaintYourself((Color background, Color foreground) with, int index, int length)
        {
            colors.Add((with, index, index + length - 1));
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
            var colors = this.colors.Flatten(Value.Length, Merge).Compress();
            if (colors.Sum(x => x.count) != Value.Length)
            {
                throw new Exception();
            }
            var i = 0;
            var sb = new StringBuilder();
            foreach (var c in colors)
            {
                var s = Value.Substring(i, c.count);
                if (c.value.foreground.HasValue)
                {
                    s = s.Pastel(c.value.foreground.Value);
                }
                if (c.value.background.HasValue)
                {
                    s = s.PastelBg(c.value.background.Value);
                }
                sb.Append(s);
                i += c.count;
            }
            return sb.ToString();
        }

        private (Color? background, Color? foreground) Merge(IEnumerable<(Color? background, Color? foreground)> arg)
        {
            return arg.Skip(1).Aggregate(arg.First(), (x, n) =>  
            (
                x.background = n.background ?? x.background,
                x.foreground = n.foreground ?? x.foreground
            ));
        }
    }
}
