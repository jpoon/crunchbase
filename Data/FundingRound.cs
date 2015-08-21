namespace CrunchBase
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using CrunchSharp;
    using CrunchSharp.Data;

    public class FundingRound : CrunchbaseEntityBase
    {
        [Key]
        [JsonPropertyName("uuid")]
        public string UUID { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("properties/funding_type")]
        public string FundingType { get; set; }

        [JsonPropertyName("properties/series")]
        public string Series { get; set; }

        [JsonPropertyName("properties/announced_on")]
        public DateTime AnnouncedOn { get; set; }

        [JsonPropertyName("properties/money_raised")]
        public double MoneyRaised { get; set; }

        [JsonPropertyName("properties/money_raised_currency_code")]
        public string MoneyRaisedCurrencyCode { get; set; }

        [JsonPropertyName("properties/money_raised_usd")]
        public double MoneyRaisedUsd { get; set; }

        [JsonPropertyName("properties/target_money_raised")]
        public double TargetMoneyRaised { get; set; }

        [JsonPropertyName("properties/target_money_currency_code")]
        public string TargetMoneyRaisedCurrencyCode { get; set; }

        [JsonPropertyName("properties/target_money_usd")]
        public double TargetMoneyRaisedUsd { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
