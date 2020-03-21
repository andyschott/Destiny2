using System;

namespace Destiny2.Entities.Vendors
{
    public class DestinyVendorComponent
    {
        public bool CanPurchase { get; set; }
        public DestinyProgression progression { get; set; }
        public int VendorLocationIndex { get; set; }
        public int? SeasonalRank { get; set; }
        public uint VendorHash { get; set; }
        public DateTime NextRefreshDate { get; set; }
        public bool Enabled { get; set; }
    }
}