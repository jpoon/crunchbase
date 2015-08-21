namespace CrunchSharp.Data
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public abstract class CrunchbaseEntityBase
    {
        [JsonPropertyName("properties/created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("properties/updated_at")]
        public string UpdatedAt { get; set; }

        public virtual void Load(JToken json)
        {
            var propertyInfoArray = this.GetType().GetProperties();
            foreach (var prop in propertyInfoArray)
            {
                var attr = prop.GetCustomAttributes(true).Where(c => c.GetType() == typeof(JsonPropertyName)).Cast<JsonPropertyName>().FirstOrDefault();

                if (attr != null)
                {
                    var jsonPropertyName = attr.Name;
                    var keys = jsonPropertyName.Split('/');

                    var value = json;
                    foreach (var key in keys)
                    {
                        value = value[key];
                        if (value == null)
                        {
                            break;
                        }
                    }

                    if (value != null && !String.IsNullOrEmpty(value.ToString()))
                    {
                        prop.SetValue(this, Convert.ChangeType(value, prop.PropertyType));
                    }
                }
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this); 
        }
    }
}
