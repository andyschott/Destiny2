using System.Collections.Generic;

namespace Destiny2.Definitions.Common
{
    public class DestinyDisplayPropertiesDefinition
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool HasIcon { get; set; }
        public IEnumerable<DestinyIconSequenceDefinition> IconSequences { get; set; }
    }
}