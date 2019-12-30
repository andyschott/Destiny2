using System;

namespace Destiny2.Definitions.Seasons
{
    public class DestinySeasonDefinition : AbstractDefinition
    {
        public string BackgroundImagePath { get; set; }
        public int SeasonNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public uint SeasonPassHash { get; set; }
        public uint SeasonPassProgressionHash { get; set; }
    }
}