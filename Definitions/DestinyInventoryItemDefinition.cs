using System.Collections.Generic;
using Destiny2.Definitions.Items;
using Newtonsoft.Json;

namespace Destiny2.Definitions
{
    public class DestinyInventoryItemDefinition : AbstractDefinition
    {
        // collectibleHash
        // secondaryIcon
        // secondaryOverlay
        // secondarySpecial
        // backgroundColor
        // screenshot
        public string ItemTypeDisplayName { get; set; }
        // uiItemDisplayStyle
        // itemTypeAndTierDisplayName
        // displaySource
        // tooltipStyle
        // action
        public DestinyItemInventoryBlockDefinition Inventory { get; set; } = null;
        // setData
        public DestinyItemStatBlockDefinition Stats { get; set; }
        // emblemObjectiveHash
        // equippingBlock
        // translationBlock
        // preview
        // quality
        // value
        // sourceData
        // objectives
        public DestinyItemPlugDefinition Plug { get; set; }
        // gearset
        // sack
        public DestinyItemSocketBlockDefinition Sockets { get; set; }
        // summary
        // talentGrid
        public IEnumerable<DestinyItemInvestmentStatDefinition> InvestmentStats { get; set; }
        public IEnumerable<DestinyItemPerkEntryDefinition> Perks { get; set; }
        // loreHash
        // summaryItemHash
        // animations
        // allowActions
        // links
        // doesPostmasterPullHaveSideEffects
        public bool NonTransferrable { get; set; }
        public  IEnumerable<uint> ItemCategoryHashes { get; set; }
        // specialItemType
        // itemType
        // itemSubType
        public DestinyClass ClassType { get; set; }
        public bool Equippable { get; set; }
        // damageTypeHashes
        // damageTypes
        // defaultDamageType
        // defaultDamageTypeHash
    }
}