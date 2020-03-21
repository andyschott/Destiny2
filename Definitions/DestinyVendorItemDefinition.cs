using System.Collections.Generic;

namespace Destiny2.Definitions
{
    public class DestinyVendorItemDefinition
    {
        public int VendorItemIndex { get; set; }
        public uint ItemHash { get; set; }
        public int Quantity { get; set; }
        public int FailureIndex { get; set; }
        public IEnumerable<DestinyVendorItemQuantity> Currencies { get; set; }
        public int RefundPolicy { get; set; }
        public int RefundTimeLimit { get; set; }
        public IEnumerable<DestinyItemCreationEntryLevelDefinition> CreationLevels { get; set; }
        public int DisplayCategoryIndex { get; set; }
        public int CategoryIndex { get; set; }
        public int OriginalCategoryIndex { get; set; }
        public int MinimumLevel { get; set; }
        public int MaximumLevel { get; set; }
        public DestinyVendorSaleItemActionBlockDefinition Action { get; set; }
        public string DisplayCategory { get; set; }
        public uint InventoryBucketHash { get; set; }
        public DestinyGatingScope VisibilityScope { get; set; }
        public DestinyGatingScope PurchasableScope { get; set; }
        public int Exclusivity { get; set; }
        public bool? IsOffer { get; set; }
        public bool? IsCrm { get; set; }
        public int SortValue { get; set; }
        public string ExpirationTooltip { get; set; }
        public IEnumerable<int> RedirectToSaleIndexes { get; set; }
        public IEnumerable<DestinyVendorItemSocketOverride> SocketOverrides { get; set; }
    }
}