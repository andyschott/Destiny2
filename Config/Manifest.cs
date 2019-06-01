using Newtonsoft.Json;
using System.Collections.Generic;

namespace Destiny2.Config
{
  [JsonObject(MemberSerialization.OptIn)]
  public class Manifest
  {
    [JsonProperty(PropertyName = "version")]
    public string Version { get; set; }

    [JsonProperty(PropertyName = "mobileWorldContentPaths")]
    public IDictionary<string, string> MobileWorldContentPaths;
  }
}