using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Destiny2.Config;

namespace Destiny2
{
    class ManifestDownloader : IManifestDownloader
    {
        private readonly IDestiny _destiny;

        public ManifestDownloader(IDestiny destiny)
        {
            _destiny = destiny;
        }

        public async Task<string> DownloadManifest(string localDatabasePath, string currentVersion)
        {
            var manifest = await _destiny.GetManifest();
            if(IsManifestOutOfDate(currentVersion, manifest.Version, localDatabasePath))
            {
                // TODO: should a different language be used based on the user's browser?
                // Download the manifest database
                var compressedFile = await DownloadManifest(manifest.MobileWorldContentPaths["en"]);
                if(!File.Exists(compressedFile))
                {
                    return string.Empty;
                }

                // Extract the downloaded database
                await ExtractDatabase(compressedFile, localDatabasePath);

                File.Delete(compressedFile);

                // Update the version of the cached database
                if (File.Exists(localDatabasePath))
                {
                    return manifest.Version;
                }
            }

            return string.Empty;
        }

        private bool IsManifestOutOfDate(string currentVersion, string latestVersion, string localDatabasePath)
        {
            if(string.IsNullOrEmpty(currentVersion))
            {
                return true;
            }

            if(currentVersion != latestVersion)
            {
                return true;
            }

            if(!File.Exists(localDatabasePath))
            {
                return true;
            }

            return false;
        }

        private async Task<string> DownloadManifest(string remotePath)
        {
            var compressedFile = Path.GetTempFileName();
            await _destiny.DownloadFile(remotePath, compressedFile);

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

                    var extractedDatabase = Directory.GetFiles(destinationDir, "world*content").FirstOrDefault();
                    if (string.IsNullOrEmpty(extractedDatabase))
                    {
                        return;
                    }

                    if (File.Exists(destination))
                    {
                        File.Delete(destination);
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