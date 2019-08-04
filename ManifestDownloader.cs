using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Destiny2
{
    class ManifestDownloader : IManifestDownloader
    {
        private readonly IDestiny _destiny;
        private readonly ILogger _logger;

        public ManifestDownloader(IDestiny destiny, ILogger<ManifestDownloader> logger)
        {
            _destiny = destiny;
            _logger = logger;
        }

        public async Task<string> DownloadManifest(string localDatabasePath, string currentVersion)
        {
            var manifest = await _destiny.GetManifest();
            if(IsManifestOutOfDate(currentVersion, manifest.Version, localDatabasePath))
            {
                _logger.LogInformation("The local manifest is out of date. Downloading the latest manifest.");

                // TODO: should a different language be used based on the user's browser?
                // Download the manifest database
                var compressedFile = await DownloadManifest(manifest.MobileWorldContentPaths["en"]);
                if(!File.Exists(compressedFile))
                {
                    return string.Empty;
                }

                // Extract the downloaded database
                await ExtractDatabase(compressedFile, localDatabasePath);

                try
                {
                    File.Delete(compressedFile);
                }
                catch(IOException ex)
                {
                    _logger.LogError(ex.ToString());
                    return string.Empty;
                }

                // Update the version of the cached database
                if (File.Exists(localDatabasePath))
                {
                    return manifest.Version;
                }
            }
            else
            {
                _logger.LogInformation("Local manifest is up to date.");
            }

            return string.Empty;
        }

        private bool IsManifestOutOfDate(string currentVersion, string latestVersion, string localDatabasePath)
        {
            _logger.LogInformation($"Current manifest version: {currentVersion}");
            _logger.LogInformation($"Bungie manifest version: {latestVersion}");

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
                _logger.LogInformation("No local manifest.");
                return true;
            }

            return false;
        }

        private async Task<string> DownloadManifest(string remotePath)
        {
            var compressedFile = Path.GetTempFileName();
            _logger.LogInformation($"Downloading the manifest from {remotePath} to {compressedFile}");
            await _destiny.DownloadFile(remotePath, compressedFile);

            return compressedFile;
        }

        private Task ExtractDatabase(string source, string destination)
        {
            return Task.Run(() =>
            {
                try
                {
                    var destinationDir = Path.GetDirectoryName(destination);
                    _logger.LogInformation($"Extracting the manifest to {destinationDir}");
                    ZipFile.ExtractToDirectory(source, destinationDir);

                    var extractedDatabase = Directory.GetFiles(destinationDir, "world*content").FirstOrDefault();
                    if (string.IsNullOrEmpty(extractedDatabase))
                    {
                        _logger.LogError("Could not find the manfiest in the extracted zip file.");
                        return;
                    }

                    if (File.Exists(destination))
                    {
                        _logger.LogInformation("Deleting the previous manifest");
                        File.Delete(destination);
                    }

                    _logger.LogInformation($"Moving the downloaded manifest from {extractedDatabase} to {destination}");
                    File.Move(extractedDatabase, destination);
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex.ToString());
                }
            });
        }
    }
}