using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Geonorge.FeedReader
{
    public class GeonorgeFeedItem
    {
        private const string InspireNamespace = "inspire_dls";
        public string InspireSpatialDatasetIdentifierCode { get; }
        public string InspireSpatialDatasetIdentifierNamespace { get; }
        public CodeListItem Epsg { get; }
        public CodeListItem Format { get; }
        public CodeListItem AreaNation { get; }
        public CodeListItem AreaCounty { get; }
        public CodeListItem AreaState { get; }

        public GeonorgeFeedItem(XElement element)
        {
            InspireSpatialDatasetIdentifierCode = element.GetValue(InspireNamespace, "spatial_dataset_identifier_code");
            InspireSpatialDatasetIdentifierNamespace =
                element.GetValue(InspireNamespace, "spatial_dataset_identifier_namespace");

            var codeListItems = new List<CodeListItem>();
            foreach (XElement categoryItem in element.GetElements("category"))
                codeListItems.Add(new CodeListItem
                {
                    Value = categoryItem.GetAttributeValue("term"),
                    Label = categoryItem.GetAttributeValue("label"),
                    Scheme = categoryItem.GetAttributeValue("scheme")
                });

            Epsg = codeListItems.FirstOrDefault(c => c.Scheme == "http://www.opengis.net/def/crs/");
            Format = codeListItems.FirstOrDefault(c =>
                c.Scheme == "https://register.geonorge.no/metadata-kodelister/vektorformater/");

            AreaNation = codeListItems.FirstOrDefault(c =>
                c.Scheme == "https://register.geonorge.no/sosi-kodelister/nasjonsnummer-alle/");

            AreaState = codeListItems.FirstOrDefault(c =>
                c.Scheme == "https://register.geonorge.no/sosi-kodelister/fylkesnummer-alle/");

            AreaCounty = codeListItems.FirstOrDefault(c =>
                c.Scheme == "https://register.geonorge.no/sosi-kodelister/kommunenummer-alle");
        }
    }
}