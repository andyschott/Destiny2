using System.Collections.Generic;

namespace Destiny2.Components.Inventory
{
    public class DestinyCurrenciesComponent
    {
        public IDictionary<uint, int> ItemQuantities { get; set; }
    }
}