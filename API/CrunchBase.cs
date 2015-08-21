namespace CrunchSharp.API
{
    using CrunchSharp.Data;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class CrunchBase
    {
        private static string ApiURL = "https://api.crunchbase.com/v/3/";
        private static string OrganizationsURL = ApiURL + "organizations/";
        private static string OrganizationURL = ApiURL + "organization/";
        private static string PeopleURL = ApiURL + "people";
        private static string PersonURL = ApiURL + "person/";
        private static string ProductsURL = ApiURL + "products";
        private static string ProductURL = ApiURL + "product/";
        private static string FundingRoundURL = ApiURL + "funding-round/";
        private static string AcquisitionURL = ApiURL + "acquisition/";
        private static string IpoURL = ApiURL + "ipo/";

        private readonly string _apiKey;

        public CrunchBase(string apiKey)
        {
            this._apiKey = apiKey;
        }

        public async Task<Tuple<List<OrganizationSummary>, JToken>> GetOrganizationsAsync(string url = null)
        {
            url = url ?? OrganizationsURL;
            var json = await CallApiAsync(url);
            var items = (JArray)json.SelectToken("items");
            var paging = json.SelectToken("paging");

            var organizations = OrganizationSummary.Load(items);
            return Tuple.Create(organizations, paging);
        }

        public async Task<Organization> GetOrganizationAsync(string permalink)
        {
            var organization = new Organization();
            var json = await CallApiAsync(OrganizationsURL + permalink);
            organization.Load(json);
            return organization;
        }

        private async Task<JToken> CallApiAsync(string baseUrl, Dictionary<string, string> parameters = null)
        {
            var finalUrl = baseUrl + "?user_key=" + _apiKey;

            if (parameters != null)
                finalUrl += "&" + string.Join("&", parameters.Select(p => p.Key + "=" + p.Value));

            var json = await HttpGetAsync(finalUrl);
            return json.SelectToken("data");
        }

        private async Task<JObject> HttpGetAsync(string url)
        {
             var httpClient = new HttpClient();
             var response = await httpClient.GetAsync(url);
 
            response.EnsureSuccessStatusCode();
 
            string content = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => JObject.Parse(content));
        }
    }
}
