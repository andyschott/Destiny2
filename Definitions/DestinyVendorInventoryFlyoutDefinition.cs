using System.Collections.Generic;
using Destiny2.Definitions.Common;

namespace Destiny2.Definitions
{
    public class DestinyVendorInventoryFlyoutDefinition
    {
        public string LockedDescription { get; set; }
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }
        public IEnumerable<DestinyVendorInventoryFlyoutBucketDefinition> Buckets { get; set; }
        public uint FlyoutId { get; set; }
        public bool SuppressNewness { get; set; }
        public uint? EquipmentSlotHash { get; set; }
    }
}