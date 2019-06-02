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
        private string _currentVersion = null;
        private readonly Destiny _destiny;

        public ManifestDownloader(string apiKey, string localDatabasePath, string currentVersion)
        {
            _destiny = new Destiny(apiKey);
            _localDatabasePath = localDatabasePath;
            _currentVersion = currentVersion;
        }

        public async Task<string> DownloadManifest()
        {
            var manifest = await _destiny.GetManifest();
            if(IsManifestOutOfDate(manifest.Version))
            {
                // TODO: should a different language be used based on the user's browser?
                // Download the manifest database
                var compressedFile = await DownloadManifest(manifest.MobileWorldContentPaths["en"]);
                if(!File.Exists(compressedFile))
                {
                    return string.Empty;
                }

                // Extract the downloaded database
                await ExtractDatabase(compressedFile, _localDatabasePath);

                File.Delete(compressedFile);

                // Update the version of the cached database
                if (File.Exists(_localDatabasePath))
                {
                    _currentVersion = manifest.Version;
                    return manifest.Version;
                }
            }

            return string.Empty;
        }

        private bool IsManifestOutOfDate(string latestVersion)
        {
            if(string.IsNullOrEmpty(_currentVersion))
            {
                return true;
            }

            if(_currentVersion != latestVersion)
            {
                return true;
            }

            if(!File.Exists(_localDatabasePath))
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

                    File.Move(extractedDatabase, destination);
                }
                catch (IOException)
                {
                }
            });
        }
    }
}