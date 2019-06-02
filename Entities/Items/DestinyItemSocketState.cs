using System.Collections.Generic;
using Destiny2.Sockets;
using Newtonsoft.Json;

namespace Destiny2.Entities.Items
{
    public class DestinyItemSocketState
    {
        [JsonProperty(PropertyName = "plugHash")]
        public uint PlugHash { get; set; }
        [JsonProperty(PropertyName = "isEnabled")]
        public bool IsEnabled { get; set; }
        [JsonProperty(PropertyName = "isVisible")]
        public bool IsVisible { get; set; }
        // enableFailIndexes
        // reusablePlugHashes
        // plugObjectives
        [JsonProperty(PropertyName = "reusablePlugs")]
        public IEnumerable<DestinyItemPlug> ReusablePlugs { get; set; }
    }
}