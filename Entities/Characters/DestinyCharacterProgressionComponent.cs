using System.Collections.Generic;

namespace Destiny2.Entities.Characters
{
    public class DestinyCharacterProgressionComponent
    {
        public IDictionary<uint, DestinyProgression> Progressions { get; set; }
        public IDictionary<uint, DestinyMilestone> Milestones { get; set; }
    }
}