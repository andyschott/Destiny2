using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Destiny2.Config;

namespace Destiny2
{
    public class ManifestDownloader
    {
        private readonly string _localDatabasePath;
        private readonly Version _currentVersion;

        public ManifestDownloader(string localDatabasePath, string currentVersion)
        {
            _localDatabasePath = localDatabasePath;
            _currentVersion = new Version(currentVersion);
        }

        public async Task<Manifest> CreateManifest()
        {
            using(var destiny = new Destiny(null, null))
            {
                var manifest = await destiny.GetManifest();
                if(IsManifestOutOfDate(manifest.Version))
                {
                    // TODO: use a different language maybe?
                    // Download the manifest database
                    var compressedFile = await DownloadManifest(destiny, manifest.MobileWorldContentPaths["en"]);
                    if(!File.Exists(compressedFile))
                    {
                        return manifest;
                    }

                    // Extract the downloaded database
                    await ExtractDatabase(compressedFile, _localDatabasePath);

                    // Update the version of the cached database
                    if (File.Exists(_localDatabasePath))
                    {
                        // TODO: Create a class to read from the manifest database
                        // _database = new Database(databasePath);
                        // CachedManifestVersion = Version;
                    }
                }

                return manifest;
            }
        }

        private bool IsManifestOutOfDate(string latestVersion)
        {
            var latest = new Version(latestVersion);

            if(_currentVersion < latest)
            {
                return true;
            }

            if(!File.Exists(_localDatabasePath))
            {
                return true;
            }

            return false;
        }

        private async Task<string> DownloadManifest(Destiny destiny, string remotePath)
        {
            var compressedFile = Path.GetTempFileName();
            await destiny.DownloadFile(remotePath, compressedFile);

            return compressedFile;
        }

        private static Task ExtractDatabase(string source, string destination)
        {
            return Task.Run(() =>
            {
                try
                {
                    var destinationDir = Path.GetDirectoryName(destination);
                    ZipFile.ExtractToDirectory(source, destinationDir);

                    var extractedDatabase = Directory.GetFiles(destinationDir).FirstOrDefault();
                    if (string.IsNullOrEmpty(extractedDatabase))
                    {
                        return;
                    }

                    File.Move(extractedDatabase, destination);
                }
                catch (IOException)
                {
                }
            });
        }
    }
}