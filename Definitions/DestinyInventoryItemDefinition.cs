using System.Collections.Generic;
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
        [JsonProperty(PropertyName = "itemTypeDisplayName")]
        public string ItemTypeDisplayName { get; set; }
        // uiItemDisplayStyle
        // itemTypeAndTierDisplayName
        // displaySource
        // tooltipStyle
        // action
        [JsonProperty(PropertyName = "inventory")]
        public DestinyItemInventoryBlockDefinition Inventory { get; set; } = null;
        // setData
        [JsonProperty(PropertyName = "stats")]
        public DestinyItemStatBlockDefinition Stats { get; set; }
        // emblemObjectiveHash
        // equippingBlock
        // translationBlock
        // preview
        // quality
        // value
        // sourceData
        // objectives
        // plug (DestinyItemPlugDefinition)
        // gearset
        // sack
        public DestinyItemSocketBlockDefinition Sockets { get; set; }
        // summary
        // talentGrid
        // investmentStats
        // perks
        // loreHash
        // summaryItemHash
        // animations
        // allowActions
        // links
        // doesPostmasterPullHaveSideEffects
        [JsonProperty(PropertyName = "nonTransferrable")]
        public bool NonTransferrable { get; set; }
        [JsonProperty(PropertyName = "itemCategoryHashes")]
        public  IEnumerable<uint> ItemCategoryHashes { get; set; }
        // specialItemType
        // itemType
        // itemSubType
        [JsonProperty(PropertyName = "classType")]
        public DestinyClass ClassType { get; set; }
        [JsonProperty(PropertyName = "equippable")]
        public bool Equippable { get; set; }
        // damageTypeHashes
        // damageTypes
        // defaultDamageType
        // defaultDamageTypeHash
    }
}