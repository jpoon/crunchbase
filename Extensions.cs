namespace CrunchBase
{
    using System;
    using Newtonsoft.Json.Linq;

    public static class Extensions
    {
        public static DateTime FromUnixTime(this long parent)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(parent);
        }

        public static long ToUnixTime(this DateTime parent)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((parent - epoch).TotalSeconds);
        }

        public static bool ToBool(this JToken parent)
        {
            return Boolean.Parse(parent.ToString());
        }
    }
}
