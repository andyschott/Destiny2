using Destiny2.Entities.Items;
using Newtonsoft.Json;

namespace Destiny2.Responses
{
    public class DestinyItemResponse
    {
        [JsonProperty(PropertyName = "characterId")]
        public long CharacterId { get; set; }
        [JsonProperty(PropertyName = "item")]
        public SingleComponentResponse<DestinyItemComponent> Item { get; set; }
        [JsonProperty(PropertyName = "instance")]
        public SingleComponentResponse<DestinyItemInstanceComponent> Instance { get; set; }
        // objectives
        // perks
        //renderData
        [JsonProperty(PropertyName = "stats")]
        public SingleComponentResponse<DestinyItemStatsComponent> Stats { get; set; }
        // talentGrid
        [JsonProperty(PropertyName = "sockets")]
        public SingleComponentResponse<DestinyItemSocketsComponent> Sockets { get; set; }
    }
}