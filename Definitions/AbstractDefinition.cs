using Destiny2.Definitions.Common;
using Newtonsoft.Json;

namespace Destiny2.Definitions
{
    public class AbstractDefinition
    {
        [JsonProperty(PropertyName = "displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

        [JsonProperty(PropertyName = "hash")]
        public uint Hash { get; set; }

        [JsonProperty(PropertyName = "redacted")]
        public bool IsRedacted { get; set; }

        public override string ToString()
        {
            return DisplayProperties.Name;
        }
    }
}