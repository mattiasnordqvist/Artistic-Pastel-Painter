using System.Collections.Generic;
using System.Linq;

namespace ArtisticPastelPainter
{
    public static class CompressExtensions
    {
        public static IEnumerable<T> Flatten<T>(this IEnumerable<(T value, int from, int to)> @this, int length)
        {
            return Enumerable.Range(0, length)
                .Select(i => @this.Last(c => c.from <= i && c.to >= i).value);
        }
        public static IEnumerable<(T value, int count)> Compress<T>(this IEnumerable<T> @this)
        {
            int count = 0;
            T last = default(T);
            foreach (var t in @this)
            {
                if (count == 0)
                {
                    count++;
                    last = t;
                }
                else if (t.Equals(last))
                {
                    count++;
                    last = t;
                }
                else
                {
                    yield return (last, count);
                    count = 1;
                    last = t;
                }
            }
            yield return (last, count);
        }
    }
}
