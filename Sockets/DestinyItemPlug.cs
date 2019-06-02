using Newtonsoft.Json;

namespace Destiny2.Sockets
{
    public class DestinyItemPlug
    {
        [JsonProperty(PropertyName = "plugItemHash")]
        public uint PlugItemHash { get; set; }
        // plugObjectives
        [JsonProperty(PropertyName = "canInsert")]
        public bool CanInsert { get; set; }
        [JsonProperty(PropertyName = "enabled")]
        public bool Enabled { get; set; }
        // insertFailIndexes
        // enableFailIndexes
    }
}