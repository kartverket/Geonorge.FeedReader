using CodeHollow.FeedReader;

namespace Geonorge.FeedReader
{
    public static class GeonorgeFeedExtensions
    {
        /// <summary>
        ///     Returns the Geonorge version of an atom feed item
        /// </summary>
        /// <param name="item">the atom feed item</param>
        /// <returns>GeonorgeFeedItem which contains Genorge specific properties</returns>
        public static GeonorgeFeedItem GetGeonorgeFeedItem(this FeedItem item)
        {
            return new GeonorgeFeedItem(item.SpecificItem.Element);
        }
    }
}