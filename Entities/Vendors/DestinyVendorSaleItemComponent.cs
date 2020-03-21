using System;
using System.Collections.Generic;

namespace Destiny2.Entities.Vendors
{
    public class DestinyVendorSaleItemComponent
    {
        public int SaleStatus { get; set; }
        public IEnumerable<uint> RequiredUnlocks { get; set; }
        public IEnumerable<DestinyUnlockStatus> UnlockStatuses { get; set; }
        public IEnumerable<int> FailureIndexes { get; set; }
        public int Augments { get; set; }
        public int VendorItemIndex { get; set; }
        public uint ItemHash { get; set; }
        public uint? OverrideStyleHash { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<DestinyItemQuantity> Costs { get; set; }
        public DateTime? OverideNextRefreshDate { get; set; }
    }
}