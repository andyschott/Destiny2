using System.Collections.Generic;

namespace Destiny2
{
    public class DestinyActivity
    {
        public uint ActivityHash { get; set; }
        public bool IsNew { get; set; }
        public bool CanLead { get; set; }
        public bool CanJoin { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsVisible { get; set; }
        public int DisplayLevel { get; set; }
        public int RecommendedLight{ get; set; }
        public int DifficultyTier { get; set; }

            //challenges
            //modifierHashes
            //booleanActivityOptions
            //loadoutRequirementIndex
    }
}