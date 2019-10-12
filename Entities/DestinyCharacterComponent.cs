using System.Collections.Generic;

namespace Destiny2.Entities
{
    public class DestinyCharacterComponent
    {
        public int Light { get; set; }
        public uint RaceHash { get; set; }
        public uint GenderHash { get; set; }
        public uint ClassHash { get; set; }
        public string EmblemPath { get; set; }
        public string EmblemBackgroundPath { get; set; }
        public int Level { get; set; }
        public IDictionary<uint, int> Stats { get; set; }
    }
}