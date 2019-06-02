using System.Collections.Generic;
using Newtonsoft.Json;

namespace Destiny2.Definitions
{
    public class DestinyItemStatBlockDefinition
    {
        // disablePrimaryStatDisplay
        // statGroupHash
        [JsonProperty(PropertyName = "stats")]
        public IDictionary<uint, DestinyInventoryItemStatDefinition> Stats { get; set; }
        // hasDisplayableStats
        [JsonProperty(PropertyName = "primaryBaseStatHash")]
        public uint PrimaryBaseStatHash { get; set; }
    }
}