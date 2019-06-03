using System.Collections.Generic;
using Destiny2.Entities.Items;
using Newtonsoft.Json;

namespace Destiny2
{
    public class DestinyItemComponentSetOfInt64
    {
        [JsonProperty(PropertyName = "instances")]
        public DictionaryComponentResponseOfInt64<DestinyItemInstanceComponent> Instances { get; set; } = null;
        // perks
        // renderData
        // stats
        // sockets
        // talentGrids
        // plugStates
        // objectives
    }
}