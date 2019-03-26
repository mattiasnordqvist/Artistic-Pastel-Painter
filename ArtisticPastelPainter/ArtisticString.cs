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
        private List<(Paint with, int from, int to)> colors = new List<(Paint with, int from, int to)>();
        public ArtisticString(string value, Color baseColor)
        {
            Value = value;
            PaintYourself(0, value.Length, baseColor);
        }

        public ArtisticString(string value, IArtisticBrush baseBrush)
        {
            Value = value;
            PaintYourself(baseBrush);
        }

        public void PaintYourself(int index, int length, Color foreground)
        {
            PaintYourself(index, length, new Paint { foreground = foreground });
        }

        public void PaintYourself(int index, int length, Color? foreground = null, Color? background = null, bool? underline = null)
        {
            PaintYourself(index, length, new Paint { foreground = foreground, background = background, underline = underline });
        }

        public void PaintYourself(int index, int length, (Color? background, Color? foreground, bool? underline) with)
        {
            PaintYourself(index, length, new Paint { background = with.background, foreground = with.foreground, underline = with.underline });
        }

        public void PaintYourself(int index, int length, Paint with)
        {
            colors.Add((with, index, index + length - 1));
        }

        public void PaintYourself(IArtisticBrush artisticRegexBrush)
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
                if (c.value.underline.HasValue && c.value.underline.Value)
                {
                    s = $"\x1B[4m{s}\x1B[24m";
                }
                sb.Append(s);
                i += c.count;
            }
            return sb.ToString();
        }

        private Paint Merge(IEnumerable<Paint> arg)
        {
            if (!arg.Any())
            {
                return new Paint(null, null, false);
            }

            return arg.Skip(1).Aggregate(arg.First(), (x, n) =>  
            new Paint { 
                background = n.background ?? x.background,
                foreground = n.foreground ?? x.foreground,
                underline = n.underline ?? x.underline
            });
        }
    }
}
