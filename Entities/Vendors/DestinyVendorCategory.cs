using System.Collections.Generic;

namespace Destiny2.Entities.Vendors
{
    public class DestinyVendorCategory
    {
        public int DisplayCategoryIndex { get; set; }
        public IEnumerable<int> ItemIndexes { get; set; }
    }
}