using System.Collections.Generic;
using System.Threading.Tasks;
using Destiny2.Definitions;

namespace Destiny2
{
  public interface IManifest
  {
    Task<DestinyClassDefinition> LoadClass(uint hash);
    Task<DestinyInventoryItemDefinition> LoadInventoryItem(uint hash);
    Task<DestinyInventoryBucketDefinition> LoadBucket(uint hash);
    Task<IEnumerable<DestinyItemCategoryDefinition>> LoadItemCategories(IEnumerable<uint> hashes);
    Task<DestinyInventoryItemDefinition> LoadPlug(uint hash);
  }
}