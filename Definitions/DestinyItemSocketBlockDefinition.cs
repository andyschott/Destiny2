using System.Collections.Generic;

namespace Destiny2.Definitions
{
    public class DestinyItemSocketBlockDefinition
    {
        // details
        public IEnumerable<DestinyItemSocketEntryDefinition> SocketEntries { get; set; }
        public IEnumerable<DestinyItemIntrinsicSocketEntryDefinition> IntrinsicSockets { get; set; }
        public IEnumerable<DestinyItemSocketCategoryDefinition> SocketCategories { get; set; }
    }
}