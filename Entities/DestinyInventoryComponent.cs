using System.Collections.Generic;
using Destiny2.Entities.Items;
using Newtonsoft.Json;

namespace Destiny2.Entities
{
    public class DestinyInventoryComponent
    {
        [JsonProperty(PropertyName = "items")]
        public IEnumerable<DestinyItemComponent> Items { get; set; }
    }
}