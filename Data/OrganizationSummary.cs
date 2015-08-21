namespace CrunchSharp.Data
{
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;

    public class OrganizationSummary : CrunchbaseEntityBase
    {
        [JsonPropertyName("uuid")]
        public string UUID { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("properties/permalink")]
        public string Permalink { get; set; }

        [JsonPropertyName("properties/api_path")]
        public string ApiPath { get; set; }

        [JsonPropertyName("properties/primary_role")]
        public string PrimaryRole { get; set; }

        [JsonPropertyName("properties/name")]
        public string Name { get; set; }

        public static List<OrganizationSummary> Load(JArray jsonArray)
        {
            var organizationSummaryList = new List<OrganizationSummary>();

            foreach (var json in jsonArray)
            {
                var organizationSummary = new OrganizationSummary();
                organizationSummary.Load(json);

               organizationSummaryList.Add(organizationSummary); 
            }

            return organizationSummaryList;
        }
    }
}
