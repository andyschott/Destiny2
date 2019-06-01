using Destiny2.Entities;
using Newtonsoft.Json;

namespace Destiny2.Responses
{
    public class DestinyCharacterResponse
    {
        [JsonProperty(PropertyName = "inventory")]
        public SingleComponentResponse<DestinyInventoryComponent> Inventory { get; set; } = null;
        [JsonProperty(PropertyName = "character")]
        public SingleComponentResponse<DestinyCharacterComponent> Character { get; set; } = null;
        [JsonProperty(PropertyName = "equipment")]
        public SingleComponentResponse<DestinyInventoryComponent> Equipment { get; set; } = null;
    }
}