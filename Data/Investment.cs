namespace CrunchBase
{
    using System;

    public class Investment
    {
        public string Type { get; set; }

        public string MoneyInvestedCurrencyCode { get; set; }

        public double MoneyInvested { get; set; }
        public double MoneyInvestedUSD { get; set; }
    }
}
