using Destiny2.Entities;
using Newtonsoft.Json;

namespace Destiny2.Responses
{
    public class DestinyProfileResponse
    {
        [JsonProperty(PropertyName = "profile")]
        public SingleComponentResponse<DestinyProfileComponent> Profile { get; set; } = null;
        [JsonProperty(PropertyName = "profileInventory")]
        public SingleComponentResponse<DestinyInventoryComponent> ProfileInventory { get; set; } = null;
        [JsonProperty(PropertyName = "characters")]
        public DictionaryComponentResponseOfInt64<DestinyCharacterComponent> Characters { get; set; } = null;
        [JsonProperty(PropertyName = "characterInventories")]
        public DictionaryComponentResponseOfInt64<DestinyInventoryComponent> CharacterInventories { get; set; } = null;
        [JsonProperty(PropertyName = "characterEquipment")]
        public DictionaryComponentResponseOfInt64<DestinyInventoryComponent> CharacterEquipment { get; set; } = null;
        [JsonProperty(PropertyName = "itemComponents")]
        public DestinyItemComponentSetOfInt64 ItemComponents { get; set; } = null;
    }
}