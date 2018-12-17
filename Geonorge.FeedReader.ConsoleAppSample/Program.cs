using System;
using System.Threading.Tasks;
using CodeHollow.FeedReader;

namespace Geonorge.FeedReader.ConsoleAppSample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string url = "https://nedlasting.geonorge.no/geonorge/Tjenestefeed.xml";
            Feed feed = await CodeHollow.FeedReader.FeedReader.ReadAsync(url);
            foreach (FeedItem item in feed.Items)
            {
                GeonorgeFeedItem geonorgeFeedItem = item.GetGeonorgeFeedItem();

                Console.WriteLine(item.Title + " - " + item.Link + " - " + geonorgeFeedItem.Epsg.Value);
            }
        }
    }
}