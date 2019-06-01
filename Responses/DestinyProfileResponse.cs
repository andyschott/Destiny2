using Destiny2.Entities;
using Newtonsoft.Json;

namespace Destiny2.Responses
{
    public class DestinyProfileResponse
    {
        [JsonProperty(PropertyName = "profile")]
        public SingleComponentResponse<DestinyProfileComponent> Profile { get; set; } = null;
    }
}