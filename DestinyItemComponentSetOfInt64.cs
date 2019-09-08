using Destiny2.Entities.Items;

namespace Destiny2
{
    public class DestinyItemComponentSetOfInt64
    {
        public DictionaryComponentResponseOfInt64<DestinyItemInstanceComponent> Instances { get; set; } = null;
        // perks
        // renderData
        public DictionaryComponentResponseOfInt64<DestinyItemStatsComponent> Stats { get; set; } = null;
        public DictionaryComponentResponseOfInt64<DestinyItemSocketsComponent> Sockets { get; set; } = null;
        // talentGrids
        // plugStates
        // objectives
    }
}