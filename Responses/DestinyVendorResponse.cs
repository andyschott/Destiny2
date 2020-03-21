using Destiny2.Components.Inventory;
using Destiny2.Entities.Vendors;

namespace Destiny2.Responses
{
    public class DestinyVendorResponse
    {
        public SingleComponentResponse<DestinyVendorComponent> Vendor { get; set; }
        public SingleComponentResponse<DestinyVendorCategoriesComponent> Categories { get; set; }
        public DictionaryComponentResponse<int, DestinyVendorSaleItemComponent> Sales { get; set; }
        // itemComponents
        public SingleComponentResponse<DestinyCurrenciesComponent> CurrencyLookups { get; set; }
    }
}