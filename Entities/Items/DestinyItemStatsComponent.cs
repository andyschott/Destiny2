using System.Collections.Generic;
using Newtonsoft.Json;

namespace Destiny2.Entities.Items
{
    public class DestinyItemStatsComponent
    {
        [JsonProperty(PropertyName = "stats")]
        public IDictionary<uint, DestinyStat> Stats { get; set; }
    }
}