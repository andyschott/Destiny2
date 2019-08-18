using System.Threading.Tasks;
using Destiny2.Definitions;
using Newtonsoft.Json;
using SQLite;

namespace Destiny2.Services
{
    class ManifestDb : IManifest
    {
        private readonly SQLiteAsyncConnection _connection;

        public ManifestDb(IManifestSettings manifestSettings)
        {
            _connection = new SQLiteAsyncConnection(manifestSettings.DbPath.FullName);
        }

        public Task<DestinyClassDefinition> LoadClass(uint hash)
        {
            return LoadObject<ClassDef, DestinyClassDefinition>(hash);
        }

        public Task<DestinyInventoryItemDefinition> LoadInventoryItem(uint hash)
        {
            return LoadObject<InventoryItemDef, DestinyInventoryItemDefinition>(hash);
        }

        public Task<DestinyInventoryBucketDefinition> LoadBucket(uint hash)
        {
            return LoadObject<BucketDef, DestinyInventoryBucketDefinition>(hash);
        }

        private async Task<TObject> LoadObject<TItemDefinition, TObject>(uint hash) where TItemDefinition : ItemDefinition, new()
        {
            var signedHash = ConvertHash(hash);

            var objects = _connection.Table<TItemDefinition>();
            var itemDef = await objects.Where(obj => obj.Id == signedHash).FirstOrDefaultAsync();

            return JsonConvert.DeserializeObject<TObject>(itemDef.Json);
        }

        private static int ConvertHash(uint hash)
        {
            // The API returns an unsigned int for the hash but the database expects
            // a signed int.
            return (int)hash;
        }

        abstract class ItemDefinition
        {
            [PrimaryKey, Column("ID")]
            public int Id { get; set; }

            [Column("JSON")]
            public string Json { get; set; }
        }

        [Table("DESTINYCLASSDEFINITION")]
        class ClassDef : ItemDefinition { }
        [Table("DESTINYINVENTORYITEMDEFINITION")]
        class InventoryItemDef : ItemDefinition { }
        [Table("DESTINYINVENTORYBUCKETDEFINITION")]
        class BucketDef : ItemDefinition { }
    }
}