namespace ArtisticPastelPainter
{
    public abstract class ArtisticBrush : IArtisticBrush
    {
        protected IRegionMatcher Matcher { get; set; }

        public ArtisticBrush(IRegionMatcher matcher)
        {
            Matcher = matcher;
        }
        public void Unleash(ArtisticString coloredString)
        {
            foreach (StringRegion region in Matcher.Match(coloredString.Value))
            {
                Unleash(coloredString, region.Index, region.Length);
            }
        }

        protected abstract void Unleash(ArtisticString coloredString, int index, int length);
    }
}
