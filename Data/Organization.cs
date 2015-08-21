namespace CrunchSharp.Data
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using CrunchBase;
    using Newtonsoft.Json.Linq;

    public class Organization : CrunchbaseEntityBase
    {
        public Organization()
        {
            FundingRounds = new Collection<FundingRound>();
            Products = new Collection<Product>();
            Acquisitions = new Collection<Acquisition>();
            Offices = new Collection<Address>();
        }

        [Key]
        [JsonPropertyName("uuid")]
        public string UUID { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("properties/permalink")]
        public string Permalink { get; set; }

        [JsonPropertyName("properties/name")]
        public string Name { get; set; }

        [JsonPropertyName("properties/description")]
        public string Description { get; set; }

        [JsonPropertyName("properties/short_description")]
        public string ShortDescription { get; set; }

        [JsonPropertyName("properties/homepage_url")]
        public string HomepageUrl { get; set; }

        [JsonPropertyName("properties/primary_role")]
        public string PrimaryRole { get; set; }

        [JsonPropertyName("properties/total_funding_usd")]
        public string TotalFundingUsd { get; set; }

        [JsonPropertyName("properties/number_of_investments")]
        public int NumberOfInvestments { get; set; }

        [JsonPropertyName("properties/number_of_employees_min")]
        public int NumberOfEmployeesMin { get; set; }

        [JsonPropertyName("properties/number_of_employees_max")]
        public int NumberOfEmployeesMax { get; set; }

        [JsonPropertyName("properties/founded_on")]
        public DateTime? FoundedOn { get; set; }

        [JsonPropertyName("properties/is_closed")]
        public bool IsClosed { get; set; }

        [JsonPropertyName("properties/closed_on")]
        public DateTime? ClosedOn { get; set; }

        public ICollection<Acquisition> Acquisitions { get; set; }

        public ICollection<FundingRound> FundingRounds { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<Address> Offices { get; set; }

        public string HeadquartersId { get; set; }

        public virtual Ipo Ipo { get; set; }

        public override void Load(JToken json)
        {
            base.Load(json);

            var relationships = json["relationships"];

            PopulateRelationshipList(relationships["funding_rounds"], FundingRounds);
            PopulateRelationshipList(relationships["products"], Products);
            PopulateRelationshipList(relationships["acquisitions"], Acquisitions);
            PopulateRelationshipList(relationships["offices"], Offices);
            

            Ipo ipoTmp;
            PopulateRelationship(relationships["ipo"], out ipoTmp);
            if (ipoTmp != null)
            {
                ipoTmp.Organization = this;
            }
            Ipo = ipoTmp;

            Address hqTmp;
            PopulateRelationship(relationships["headquarters"], out hqTmp);
            if (hqTmp != null)
            {
                hqTmp.Organization = this;
                HeadquartersId = hqTmp.UUID;
            }

            /*
            PopulateRelationshipList(relationships["competitors"]["items"].Children(), Competitors);
            PopulateRelationshipList(relationships["funding_rounds"]["items"].Children(), FundingRounds);
            PopulateRelationshipList(relationships["categories"]["items"].Children(), Categories);
            PopulateRelationshipList(relationships["founders"]["items"].Children(), Founders);
            */
        }
        private void PopulateRelationship<T>(JToken jToken, out T relationship) where T : CrunchbaseEntityBase
        {
            relationship = null;
            if (jToken != null)
            {
                var itemJson = jToken["item"];
                relationship = Activator.CreateInstance<T>();
                relationship.Load(itemJson);
            }
        }

        private void PopulateRelationshipList<T>(JToken relationship, ICollection<T> list) where T : CrunchbaseEntityBase
        {
            if (relationship != null)
            {
                foreach (JToken itemJson in relationship["items"].Children())
                {
                    var currentItem = Activator.CreateInstance<T>();
                    currentItem.Load(itemJson);
                    list.Add(currentItem);
                }
            }
        }
    }
}
