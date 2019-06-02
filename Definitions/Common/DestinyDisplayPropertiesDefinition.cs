using Newtonsoft.Json;

namespace Destiny2.Definitions.Common
{
    public class DestinyDisplayPropertiesDefinition
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "hasIcon")]
        public bool HasIcon { get; set; }
    }
}