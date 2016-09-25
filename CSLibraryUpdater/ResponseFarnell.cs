using Newtonsoft.Json;
using System.Collections.Generic;

namespace CSLibraryUpdater
{
    public class ResponseFarnell
    {
        [JsonProperty("premierFarnellPartNumberReturn")]
        public PremierFarnellPartNumberReturn premierFarnellPartNumberReturn { get; set; }
    }

    public class PremierFarnellPartNumberReturn
    {
        [JsonProperty("numberOfResults")]
        public int numberOfResults { get; set; }
        [JsonProperty("products")]
        public List<Products> products { get; set; }
    }

    public class Products
    {
        [JsonProperty("sku")]
        public string sku { get; set; }
        [JsonProperty("displayName")]
        public string displayName { get; set; }
        [JsonProperty("productStatus")]
        public string productStatus { get; set; }
        [JsonProperty("rohsStatusCode")]
        public string rohsStatusCode { get; set; }
        [JsonProperty("packSize")]
        public string packSize { get; set; }
        [JsonProperty("unitOfMeasure")]
        public string unitOfMeasure { get; set; }
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("inv")]
        public string inv { get; set; }
        [JsonProperty("vendorId")]
        public string vendorId { get; set; }
        [JsonProperty("vendorName")]
        public string vendorName { get; set; }
        [JsonProperty("brandName")]
        public string brandName { get; set; }
        [JsonProperty("translatedManufacturerPartNumber")]
        public string translatedManufacturerPartNumber { get; set; }
        [JsonProperty("translatedMinimumOrderQuality")]
        public string translatedMinimumOrderQuality { get; set; }
        [JsonProperty("datasheets")]
        public List<FarnellDatasheet> datasheets { get; set; }
        [JsonProperty("attributes")]
        public List<FarnellAttribute> attributes { get; set; }
    }

    public class FarnellDatasheet
    {
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
    }

    public class FarnellAttribute
    {
        [JsonProperty("attributeLabel")]
        public string attributeLabel { get; set; }
        [JsonProperty("attributeUnit")]
        public string attributeUnit { get; set; }
        [JsonProperty("attributeValue")]
        public string attributeValue { get; set; }
    }

}
