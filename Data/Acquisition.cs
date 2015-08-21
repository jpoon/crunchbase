namespace CrunchSharp.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

	public class Acquisition : CrunchbaseEntityBase
	{
        [Key]
        [JsonPropertyName("uuid")]
        public string UUID { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("properties/price")]
		public double Price { get; set; }

        [JsonPropertyName("properties/price_currency_code")]
		public string PriceCurrencyCode { get; set; }

        [JsonPropertyName("properties/price_usd")]
		public double PriceUsd { get; set; }

        [JsonPropertyName("properties/payment_type")]
		public string PaymentType { get; set; }

        [JsonPropertyName("properties/acquisition_type")]
        public string AcquisitionType { get; set; }

        [JsonPropertyName("properties/acquisition_status")]
        public string AcquisitionStatus { get; set; }

        [JsonPropertyName("properties/disposition_of_acquired")]
        public string DispositionOfAcquired { get; set; }

        [JsonPropertyName("properties/announced_on")]
        public DateTime? AnnouncedOn { get; set; }

        [JsonPropertyName("properties/completed_on")]
		public DateTime? CompletedOn { get; set; }

        public virtual Organization Organization { get; set; }

        /*
        public virtual Organization Acquirer { get; set; }

		public virtual Organization Acquiree { get; set; }*/
	}
}
