namespace CrunchBase
{
    using CrunchSharp;
    using CrunchSharp.Data;
    using System.ComponentModel.DataAnnotations;

    public class Product : CrunchbaseEntityBase
    {
        [Key]
        [JsonPropertyName("uuid")]
        public string UUID { get; set; }

        [JsonPropertyName("properties/type")]
        public string Type { get; set; }

        [JsonPropertyName("properties/permalink")]
        public string Permalink { get; set; }

        [JsonPropertyName("properties/name")]
        public string Name { get; set; }

        [JsonPropertyName("properties/short_description")]
        public string ShortDescription { get; set; }

        [JsonPropertyName("properties/homepage_url")]
        public string HomepageUrl { get; set; }

        [JsonPropertyName("properties/lifecycle_stage")]
        public string LifecycleStage { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
