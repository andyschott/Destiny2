using Newtonsoft.Json;

namespace Destiny2.Definitions
{
    public class DestinyClassDefinition : AbstractDefinition
    {
        [JsonProperty(PropertyName = "classType")]
        public DestinyClass ClassType { get; set; }
    }
}