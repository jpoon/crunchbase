namespace CrunchBase
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using CrunchSharp;
    using CrunchSharp.Data;

	public class Ipo : CrunchbaseEntityBase
	{
        [Key, ForeignKey("Organization")]
        public string Organization_UUID { get; set; }

        [JsonPropertyName("type")]
		public string Type { get; set; }

        [JsonPropertyName("properties/went_public_on")]
		public DateTime? WentPublicOn { get; set; }

        [JsonPropertyName("properties/stock_symbol")]
		public string StockSymbol { get; set; }

        [JsonPropertyName("properties/stock_exchange_symbol")]
		public string StockExchangeSymbol { get; set; }

        [JsonPropertyName("properties/stock_share_price")]
		public double OpeningSharePrice { get; set; }

        [JsonPropertyName("properties/stock_share_price_currency_code")]
		public string OpeningSharePriceCurrencyCode { get; set; }

        [JsonPropertyName("properties/stock_share_price_usd")]
		public double OpeningSharePriceUsd { get; set; }

        [JsonPropertyName("properties/opening_valuation")]
		public double OpeningValuation { get; set; }

        [JsonPropertyName("properties/opening_valuation_currency_code")]
		public string OpeningValuationCurrencyCode { get; set; }

        [JsonPropertyName("properties/opening_valuation_usd")]
		public double OpeningValuationUsd { get; set; }

        [JsonPropertyName("properties/money_raised")]
		public double MoneyRaised { get; set; }

        [JsonPropertyName("properties/money_raised_currency_code")]
		public string MoneyRaisedCurrencyCode { get; set; }

        [JsonPropertyName("properties/money_raised_usd")]
		public double MoneyRaisedUsd { get; set; }

        public virtual Organization Organization { get; set; }
	}
}
