using System.Collections.Generic;
using Newtonsoft.Json;

namespace Destiny2.Entities.Items
{
    public class DestinyItemSocketsComponent
    {
        [JsonProperty(PropertyName = "sockets")]
        public IEnumerable<DestinyItemSocketState> Sockets { get; set; }
    }
}