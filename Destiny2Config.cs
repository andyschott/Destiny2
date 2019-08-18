namespace Destiny2
{
  public class Destiny2Config
  {
    public Destiny2Config(string appName, string appVersion, string appId, string url, string email)
      : this($"{appName}/{appVersion} AppId/{appId} (+{url};{email})")
    {
    }

    public Destiny2Config(string userAgent)
    {
      UserAgent = userAgent;
    }

    public string BaseUrl { get; set; } = "https://www.bungie.net";
    public string ApiKey { get; set; }
    public string ManifestDatabasePath { get; set; } = "";
    public int ManifestCheckTimeout { get; set; } = 5 * 60 * 1000;
    public string UserAgent { get; }

    public bool IsValid => !string.IsNullOrEmpty(BaseUrl) &&
      !string.IsNullOrEmpty(ApiKey) &&
      !string.IsNullOrEmpty(UserAgent) &&
      ManifestDatabasePath != null &&
      ManifestCheckTimeout > 0;
  }
}