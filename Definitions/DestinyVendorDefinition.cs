using System.Collections.Generic;

namespace Destiny2.Definitions
{
    public class DestinyVendorDefinition : AbstractDefinition
    {
        public string BuyString { get; set; }
        public string SellString { get; set; }
        public uint DisplayItemHash { get; set; }
        public bool InhibitBuying { get; set; }
        public bool InhibitSelling { get; set; }
        public uint FactionHash { get; set; }
        public int ResetIntervalMinutes { get; set; }
        public int ResetOffsetMinutes { get; set; }
        public IEnumerable<string> FailureStrings { get; set; }
        // ignoring unlockRanges since apparently it doesn't work
        public string VendorIdentifier { get; set; }
        public string VendorPortrait { get; set; }
        public string VendorBanner { get; set; }
        public bool Enabled { get; set; }
        public bool Visible { get; set; }
        public string VendorSubcategoryIdentifier { get; set; }
        public bool ConsolidateCategories { get; set; }
        public IEnumerable<DestinyVendorActionDefinition> Actions { get; set; }
        public IEnumerable<DestinyVendorCategoryEntryDefinition> Categories { get; set; }
        public IEnumerable<DestinyVendorCategoryEntryDefinition> originalCategories { get; set; }
        public IEnumerable<DestinyDisplayCategoryDefinition> DisplayCategories { get; set; }
        public IEnumerable<DestinyVendorInteractionDefinition> Interactions { get; set; }
        public IEnumerable<DestinyVendorInventoryFlyoutDefinition> InventoryFlyouts { get; set; }
        public IEnumerable<DestinyVendorItemDefinition> ItemList { get; set; }
        public IEnumerable<DestinyVendorServiceDefinition> Services { get; set; }
        public IEnumerable<DestinyVendorAcceptedItemDefinition> AcceptedItems { get; set; }
        public bool ReturnWithVendorRequest { get; set; }
        public IEnumerable<DestinyVendorLocationDefinition> Locations { get; set; }
        public IEnumerable<DestinyVendorGroupReference> Groups { get; set; }
        public IEnumerable<uint> IgnoreSaleItemHashes { get; set; }
    }
}