using System.Collections.Generic;

namespace Destiny2.Definitions
{
    public class DestinyItemSocketCategoryDefinition
    {
        public uint SocketCategoryHash { get; set; }
        public IEnumerable<int> SocketIndexes { get; set; }
    }
}