using System.Threading.Tasks;

namespace Destiny2
{
    public interface IManifestDownloader
    {
         Task<string> DownloadManifest(string localDatabasePath, string currentVersion);
    }
}