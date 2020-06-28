using System.Collections.Generic;

namespace Destiny2.Components.Collectibles
{
    public class DestinyProfileCollectiblesComponent
    {
        public IEnumerable<uint> RecentCollectibleHashes { get; set; }
        public IEnumerable<uint> NewnessFlaggedCollectibleHashes { get; set; }
        public IDictionary<uint, DestinyCollectibleComponent> Collectibles { get; set; }
        public uint CollectionCategoriesRootNodeHash { get; set; }
        public uint CollectionBadgesRootNodeHash { get; set; }
    }
}