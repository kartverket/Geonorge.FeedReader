using System.Linq;
using CodeHollow.FeedReader;
using FluentAssertions;
using Xunit;
using static CodeHollow.FeedReader.FeedReader;

namespace Geonorge.FeedReader.Tests
{
    public class GeonorgeFeedTest
    {
        [Fact]
        public void ShouldParseAreaCounty()
        {
            Feed feed = ReadFromFile("feeds/details.xml");
            GeonorgeFeedItem geonorgeFeedItem = feed.Items.Skip(2).First().GetGeonorgeFeedItem();
            geonorgeFeedItem.AreaCounty.Value.Should().Be("0101");
        }

        [Fact]
        public void ShouldParseAreaNation()
        {
            Feed feed = ReadFromFile("feeds/details.xml");
            GeonorgeFeedItem geonorgeFeedItem = feed.Items.First().GetGeonorgeFeedItem();
            geonorgeFeedItem.AreaNation.Value.Should().Be("0000");
        }

        [Fact]
        public void ShouldParseAreaState()
        {
            Feed feed = ReadFromFile("feeds/details.xml");
            GeonorgeFeedItem geonorgeFeedItem = feed.Items.Skip(1).First().GetGeonorgeFeedItem();
            geonorgeFeedItem.AreaState.Value.Should().Be("01");
        }

        [Fact]
        public void ShouldParseEpsg()
        {
            Feed feed = ReadFromFile("feeds/details.xml");
            GeonorgeFeedItem geonorgeFeedItem = feed.Items.First().GetGeonorgeFeedItem();
            geonorgeFeedItem.Epsg.Value.Should().Be("EPSG:25833");
        }

        [Fact]
        public void ShouldParseFormat()
        {
            Feed feed = ReadFromFile("feeds/details.xml");
            GeonorgeFeedItem geonorgeFeedItem = feed.Items.First().GetGeonorgeFeedItem();
            geonorgeFeedItem.Format.Value.Should().Be("GeoJSON");
        }

        [Fact]
        public void ShouldParseInspireFields()
        {
            Feed feed = ReadFromFile("feeds/root.xml");

            GeonorgeFeedItem geonorgeFeedItem = feed.Items.First().GetGeonorgeFeedItem();

            geonorgeFeedItem.InspireSpatialDatasetIdentifierCode.Should().Be("041f1e6e-bdbc-4091-b48f-8a5990f3cc5b");
            geonorgeFeedItem.InspireSpatialDatasetIdentifierNamespace.Should().Be("http://www.geonorge.no/");
        }
    }
}