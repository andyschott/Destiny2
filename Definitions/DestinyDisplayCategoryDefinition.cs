using Destiny2.Definitions.Common;

namespace Destiny2.Definitions
{
    public class DestinyDisplayCategoryDefinition
    {
        public int Index { get; set; }
        public string Identifier { get; set; }
        public uint DisplayCategoryHash { get; set; }
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }
        public bool DisplayInBanner { get; set; }
        public uint? ProgressionHash { get; set; }
        public int SortOrder { get; set; }
        public uint? DisplayStyleHash { get; set; }
        public string DisplayStyleIdentifier { get; set; }
    }
}