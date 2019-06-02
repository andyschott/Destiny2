using Newtonsoft.Json;

namespace Destiny2
{
    public class DestinyStat
    {
        [JsonProperty(PropertyName = "statHash")]
        public uint StatHash { get; set; }
        [JsonProperty(PropertyName = "value")]
        public int Value { get; set; }
        [JsonProperty(PropertyName = "maximumValue")]
        public int MaximumValue { get; set; }
    }
}