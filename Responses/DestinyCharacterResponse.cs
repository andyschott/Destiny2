using Destiny2.Entities;
using Destiny2.Entities.Characters;

namespace Destiny2.Responses
{
    public class DestinyCharacterResponse
    {
        public SingleComponentResponse<DestinyInventoryComponent> Inventory { get; set; } = null;
        public SingleComponentResponse<DestinyCharacterComponent> Character { get; set; } = null;
        public SingleComponentResponse<DestinyInventoryComponent> Equipment { get; set; } = null;
        public DestinyItemComponentSetOfInt64 ItemComponents { get; set; } = null;
        public SingleComponentResponse<DestinyCharacterProgressionComponent> Progressions { get; set; }
        public SingleComponentResponse<DestinyCharacterActivitiesComponent> Activities { get; set; }
    }
}