using System.Collections.Generic;
using Destiny2.Misc;

namespace Destiny2.Definitions
{
    public class DestinyProgressionDefinition : AbstractDefinition
    {
        public int Scope { get; set; }
        public bool RepeatLastStep { get; set; }
        public string Source { get; set; }
        public IEnumerable<DestinyProgressionStepDefinition> Steps { get; set; }
        public bool Visible { get; set; }
        public uint FactionHash { get; set; }
        public DestinyColor Color { get; set; }
        public string RankIcon { get; set; }
        public IEnumerable<DestinyProgressionRewardItemQuantity> RewardItems { get; set; }
    }
}