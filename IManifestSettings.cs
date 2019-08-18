using System.IO;

namespace Destiny2
{
  public interface IManifestSettings
  {
        FileInfo DbPath { get; }
        FileInfo VersionPath { get; }
        /// <summary>
        /// How often to check for a new manifest database, in milliseconds.
        /// </summary>
        int ManifestCheckTimeout { get; }
  }
}