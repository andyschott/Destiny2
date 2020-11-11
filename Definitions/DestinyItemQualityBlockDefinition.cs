using System.Collections.Generic;

namespace Destiny2.Definitions
{
    public class DestinyItemQualityBlockDefinition
    {
        public IEnumerable<uint> InfusionCategoryHashes { get; set; }
        public uint ProgressionLevelRequirementHash { get; set; }
        public int CurrentVersion { get; set; }
        public IEnumerable<DestinyItemVersionDefinition> Versions { get; set; }
        public IEnumerable<string> DisplayVersionWatermarkIcons { get; set; }
    }
}