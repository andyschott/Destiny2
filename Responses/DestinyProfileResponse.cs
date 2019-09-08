using Destiny2.Entities;

namespace Destiny2.Responses
{
    public class DestinyProfileResponse
    {
        public SingleComponentResponse<DestinyProfileComponent> Profile { get; set; } = null;
        public SingleComponentResponse<DestinyInventoryComponent> ProfileInventory { get; set; } = null;
        public DictionaryComponentResponseOfInt64<DestinyCharacterComponent> Characters { get; set; } = null;
        public DictionaryComponentResponseOfInt64<DestinyInventoryComponent> CharacterInventories { get; set; } = null;
        public DictionaryComponentResponseOfInt64<DestinyInventoryComponent> CharacterEquipment { get; set; } = null;
        public DestinyItemComponentSetOfInt64 ItemComponents { get; set; } = null;
        public SingleComponentResponse<DestinyInventoryComponent> ProfileCurrencies { get; set; }
    }
}