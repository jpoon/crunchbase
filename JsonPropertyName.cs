namespace CrunchSharp
{
    using System;

    public class JsonPropertyName : Attribute
    {
        public string Name { get; private set; }

        public JsonPropertyName(string name)
        {
            this.Name = name;
        }
    }
}
