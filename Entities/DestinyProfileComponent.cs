using System.Collections.Generic;

namespace Destiny2.Entities
{
    public class DestinyProfileComponent
    {
        public IEnumerable<long> CharacterIds { get; set; } = new List<long>();
        public IEnumerable<uint> SeasonHashes { get; set; } = new List<uint>();
    }
}