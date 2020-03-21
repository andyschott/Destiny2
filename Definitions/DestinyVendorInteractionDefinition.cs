using System.Collections.Generic;
using Destiny2.Definitions.Common;

namespace Destiny2.Definitions
{
    public class DestinyVendorInteractionDefinition
    {
        public int InteractionIndex { get; set; }
        public IEnumerable<DestinyVendorInteractionReplyDefinition> Replies { get; set; }
        public int VendorCategoryIndex { get; set; }
        public uint? QuestlineItemHash { get; set; }
        public IEnumerable<DestinyVendorInteractionSackEntryDefinition> SackInteractionList { get; set; }
        public uint UIInteractionType { get; set; }
        public int InteractionType { get; set; }
        public string RewardBlockLabel { get; set; }
        public int RewardVendorCategoryIndex { get; set; }
        public string FlavorLineOne { get; set; }
        public string FlavorLineTwo { get; set; }
        public DestinyDisplayPropertiesDefinition HeaderDisplayProperties { get; set; }
        public string Instructions { get; set; }
    }
}