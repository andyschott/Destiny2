using System.Collections.Generic;
using Newtonsoft.Json;

namespace Destiny2.Entities
{
    public class DestinyProfileComponent
    {
        [JsonProperty(PropertyName = "characterIds")]
        public IEnumerable<long> CharacterIds { get; set; } = new List<long>();
    }
}