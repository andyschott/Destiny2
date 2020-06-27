using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Destiny2.Definitions;
using Destiny2.Definitions.Seasons;
using Destiny2.Definitions.Sockets;
using Newtonsoft.Json;
using SQLite;

namespace Destiny2.Services
{
    class ManifestDb : IManifest
    {
        private readonly SQLiteAsyncConnection _connection;
        private readonly string _dbPath;

        public ManifestDb(IManifestSettings manifestSettings)
        {
            _dbPath = manifestSettings.DbPath.FullName;
            _connection = new SQLiteAsyncConnection(_dbPath);
        }

        public Task<DestinyClassDefinition> LoadClass(uint hash)
        {
            return LoadObject<ClassDef, DestinyClassDefinition>(hash);
        }

        public Task<DestinyInventoryItemDefinition> LoadInventoryItem(uint hash)
        {
            return LoadObject<InventoryItemDef, DestinyInventoryItemDefinition>(hash);
        }

        public async Task<IEnumerable<DestinyInventoryItemDefinition>> LoadInventoryItemsWithCategory(uint categoryHash)
        {
            var rows = _connection.Table<InventoryItemDef>();
            var itemDefs = await rows.ToListAsync();

            var objects = itemDefs.Select(itemDef =>JsonConvert.DeserializeObject<DestinyInventoryItemDefinition>(itemDef.Json))
                .Where(itemDef => itemDef.ItemCategoryHashes?.Contains(categoryHash) ?? false);
            return objects.ToList();
        }

        public Task<DestinyInventoryBucketDefinition> LoadBucket(uint hash)
        {
            return LoadObject<BucketDef, DestinyInventoryBucketDefinition>(hash);
        }

        public Task<IEnumerable<DestinyItemCategoryDefinition>> LoadItemCategories(IEnumerable<uint> hashes)
        {
            return LoadObjects<CategoryDef, DestinyItemCategoryDefinition>(hashes);
        }

        public Task<DestinyInventoryItemDefinition> LoadPlug(uint hash)
        {
            return LoadObject<InventoryItemDef, DestinyInventoryItemDefinition>(hash);
        }

        public Task<DestinySocketTypeDefinition> LoadSocketType(uint hash)
        {
            return LoadObject<SocketDef, DestinySocketTypeDefinition>(hash);
        }

        public Task<DestinySocketCategoryDefinition> LoadSocketCategory(uint hash)
        {
            return LoadObject<SocketCategoryDef, DestinySocketCategoryDefinition>(hash);
        }

        public Task<DestinyStatDefinition> LoadStat(uint hash)
        {
            return LoadObject<StatDef, DestinyStatDefinition>(hash);
        }

        public Task<IEnumerable<DestinyStatDefinition>> LoadStats(IEnumerable<uint> hashes)
        {
            return LoadObjects<StatDef, DestinyStatDefinition>(hashes);
        }

        public Task<string> GetJson(string tableName, uint hash)
        {
            return DoesTableExist(tableName).ContinueWith(existsTask =>
            {
                if(!existsTask.Result)
                {
                    return string.Empty;
                }

                using(var conn = new SQLiteConnection(_dbPath))
                {
                    var signedHash = ConvertHash(hash);
                    var cmd = conn.CreateCommand($"select json from {tableName} where id = ?",
                        signedHash);
                    return cmd.ExecuteScalar<string>();
                }
            });
        }

        public Task<IEnumerable<string>> GetJson(string tableName, IEnumerable<uint> hashes)
        {
            return DoesTableExist(tableName).ContinueWith(existsTask =>
            {
                if(!existsTask.Result)
                {
                    return Enumerable.Empty<string>();
                }

                using(var conn = new SQLiteConnection(_dbPath))
                {
                    var signedHashes = ConvertHashes(hashes);
                    var placeholders = Enumerable.Repeat("?", hashes.Count());

                    var cmd = conn.CreateCommand($"select json from {tableName} where id in ({string.Join(",", placeholders)})");
                    foreach(var hash in signedHashes)
                    {
                        cmd.Bind(hash);
                    }
                    var items = cmd.ExecuteQuery<ItemDefinition>();
                    return items.Select(item => item.Json);
                }
            });
        }

        public Task<DestinySeasonDefinition> LoadSeason(uint hash)
        {
            return LoadObject<SeasonDef, DestinySeasonDefinition>(hash);
        }

        public Task<DestinySeasonPassDefinition> LoadSeasonPass(uint hash)
        {
            return LoadObject<SeasonPassDef, DestinySeasonPassDefinition>(hash);
        }

        public Task<DestinyProgressionDefinition> LoadProgression(uint hash)
        {
            return LoadObject<ProgressionDef, DestinyProgressionDefinition>(hash);
        }

        public Task<DestinyVendorDefinition> LoadVendor(uint hash)
        {
            return LoadObject<DestinyVendorDef, DestinyVendorDefinition>(hash);
        }

        public Task<DestinySandboxPerkDefinition> LoadSandboxPerk(uint hash)
        {
            return LoadObject<DestinySandboxPerkDef, DestinySandboxPerkDefinition>(hash);
        }

        public Task<IEnumerable<DestinySandboxPerkDefinition>> LoadSandboxPerks(IEnumerable<uint> hashes)
        {
            return LoadObjects<DestinySandboxPerkDef, DestinySandboxPerkDefinition>(hashes);
        }

        public Task<DestinyDamageTypeDefinition> LoadDamageType(uint hash)
        {
            return LoadObject<DestinyDamageTypeDef, DestinyDamageTypeDefinition>(hash);
        }

        private Task<bool> DoesTableExist(string tableName)
        {
            return Task.Run(() =>
            {
                using(var conn = new SQLiteConnection(_dbPath))
                {
                    var cmd = conn.CreateCommand("select count(name) from sqlite_master where type = 'table' and name = ? collate nocase",
                        tableName);
                    var count = cmd.ExecuteScalar<int>();
                    return count > 0;
                }
            });
        }

        private async Task<TObject> LoadObject<TItemDefinition, TObject>(uint hash) where TItemDefinition : ItemDefinition, new()
        {
            var signedHash = ConvertHash(hash);

            var objects = _connection.Table<TItemDefinition>();
            var itemDef = await objects.Where(obj => obj.Id == signedHash).FirstOrDefaultAsync();

            return JsonConvert.DeserializeObject<TObject>(itemDef.Json);
        }

        private async Task<IEnumerable<TObject>> LoadObjects<TItemDefinition, TObject>(IEnumerable<uint> hashes) where TItemDefinition : ItemDefinition, new()
        {
            var signedHashes = ConvertHashes(hashes);

            var rows = _connection.Table<TItemDefinition>();
            var itemDefs = await rows.Where(obj => signedHashes.Contains(obj.Id)).ToListAsync();

            var objects = from itemDef in itemDefs
                          select JsonConvert.DeserializeObject<TObject>(itemDef.Json);
            return objects.ToList();
        }

        private static ISet<int> ConvertHashes(IEnumerable<uint> hashes)
        {
            var convertedHashes = from hash in hashes
                                  select ConvertHash(hash);

            return new HashSet<int>(convertedHashes);
        }

        private static int ConvertHash(uint hash)
        {
            // The API returns an unsigned int for the hash but the database expects
            // a signed int.
            return (int)hash;
        }

        class ItemDefinition
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
        [Table("DESTINYITEMCATEGORYDEFINITION")]
        class CategoryDef : ItemDefinition { }
        [Table("DESTINYSOCKETTYPEDEFINITION")]
        class SocketDef : ItemDefinition { }
        [Table("DESTINYSOCKETCATEGORYDEFINITION")]
        class SocketCategoryDef : ItemDefinition { }
        [Table("DESTINYSTATDEFINITION")]
        class StatDef : ItemDefinition { }
        [Table("DESTINYSEASONDEFINITION")]
        class SeasonDef : ItemDefinition { }
        [Table("DESTINYSEASONPASSDEFINITION")]
        class SeasonPassDef : ItemDefinition { }
        [Table("DESTINYPROGRESSIONDEFINITION")]
        class ProgressionDef : ItemDefinition { }
        [Table("DESTINYVENDORDEFINITION")]
        class DestinyVendorDef : ItemDefinition {}
        [Table("DESTINYSANDBOXPERKDEFINITION")]
        class DestinySandboxPerkDef : ItemDefinition {}
        [Table("DESTINYDAMAGETYPEDEFINITION")]
        class DestinyDamageTypeDef : ItemDefinition {}
    }
}