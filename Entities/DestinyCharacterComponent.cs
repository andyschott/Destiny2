using Newtonsoft.Json;

namespace Destiny2.Entities
{
    public class DestinyCharacterComponent
    {
        [JsonProperty(PropertyName = "light")]
        public int Light { get; set; }

        [JsonProperty(PropertyName = "raceHash")]
        public uint RaceHash { get; set; }

        [JsonProperty(PropertyName = "genderHash")]
        public uint GenderHash { get; set; }

        [JsonProperty(PropertyName = "classHash")]
        public uint ClassHash { get; set; }

        [JsonProperty(PropertyName = "baseCharacterLevel")]
        public int Level { get; set; }
        
    }
}