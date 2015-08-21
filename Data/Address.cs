namespace CrunchSharp.Data
{
    using System.ComponentModel.DataAnnotations;

    public class Address : CrunchbaseEntityBase
    {
        [Key]
        [JsonPropertyName("uuid")]
        public string UUID { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("properties/type")]
        public string Name { get; set; }

        [JsonPropertyName("properties/street_1")]
        public string Address1 { get; set; }

        [JsonPropertyName("properties/street_2")]
        public string Address2 { get; set; }

        [JsonPropertyName("properties/postal_code")]
        public string PostalCode { get; set; }

        [JsonPropertyName("properties/city")]
        public string City { get; set; }

        [JsonPropertyName("properties/city_web_path")]
        public string CityPath { get; set; }

        [JsonPropertyName("properties/region")]
        public string Region { get; set; }

        [JsonPropertyName("properties/region_code2")]
        public string RegionCode { get; set; }

        [JsonPropertyName("properties/region_web_path")]
        public string RegionPath { get; set; }

        [JsonPropertyName("properties/country")]
        public string Country { get; set; }

        [JsonPropertyName("properties/country_code2")]
        public string CountryCode { get; set; }

        [JsonPropertyName("properties/country_code3")]
        public string CountryPath { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
