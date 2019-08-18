namespace Destiny2
{
  public class Destiny2Config
  {
    public string BaseUrl { get; set; } = "https://www.bungie.net";
    public string ApiKey { get; set; }
    public string ManifestDatabasePath { get; set; } = "";
    public int ManifestCheckTimeout { get; set; } = 5 * 60 * 1000;

    public bool IsValid => !string.IsNullOrEmpty(BaseUrl) &&
      !string.IsNullOrEmpty(ApiKey) &&
      ManifestDatabasePath != null &&
      ManifestCheckTimeout > 0;
  }
}