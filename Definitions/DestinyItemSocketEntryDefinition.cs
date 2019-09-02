using System.Collections.Generic;

namespace Destiny2.Definitions
{
    public class DestinyItemSocketEntryDefinition
    {
        public uint SocketTypeHash { get; set; }
        public uint SingleInitialItemHash { get; set; }
        public IEnumerable<DestinyItemSocketEntryPlugItemDefinition> ReusablePlugItems { get; set; }
        public bool PreventInitializationOnVendorPurchase { get; set; }
        public bool HidePerksInItemTooltip { get; set; }
        public int PlugSources { get; set; }
        public uint? ReusablePlugSetHash { get; set; }
        public IEnumerable<DestinyItemSocketEntryPlugItemRandomizedDefinition> RandomizedPlugItems { get; set; }
        public bool DefaultVisible { get; set; }
    }
}