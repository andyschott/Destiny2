using System.Collections.Generic;
using System.Threading.Tasks;
using Destiny2.Definitions;
using Destiny2.Definitions.Sockets;

namespace Destiny2
{
  public interface IManifest
  {
    Task<DestinyClassDefinition> LoadClass(uint hash);
    Task<DestinyInventoryItemDefinition> LoadInventoryItem(uint hash);
    Task<IEnumerable<DestinyInventoryItemDefinition>> LoadInventoryItemsWithCategory(uint categoryHash);
    Task<DestinyInventoryBucketDefinition> LoadBucket(uint hash);
    Task<IEnumerable<DestinyItemCategoryDefinition>> LoadItemCategories(IEnumerable<uint> hashes);
    Task<DestinyInventoryItemDefinition> LoadPlug(uint hash);
    Task<DestinySocketTypeDefinition> LoadSocketType(uint hash);
    Task<DestinySocketCategoryDefinition> LoadSocketCategory(uint hash);
    Task<DestinyStatDefinition> LoadStat(uint hash);
    Task<IEnumerable<DestinyStatDefinition>> LoadStats(IEnumerable<uint> hashes);
  }
}