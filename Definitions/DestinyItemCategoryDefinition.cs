using System.Collections.Generic;
using Destiny;

namespace Destiny2.Definitions
{
    public class DestinyItemCategoryDefinition : AbstractDefinition
    {
        public bool Visible { get; set; }
        public bool Deprecated { get; set; }
        public string ShortTitle { get; set; }
        // itemTypeRegex
        public string PlugCategoryIdentifier { get; set; } = null;
        // itemTypeRegexNot
        public string OriginBucketIdentifier { get; set; }
        public DestinyItemType GrantDestinyItemType { get; set; }
        public DestinyItemSubType GrantDestinySubType { get; set; }
        public DestinyClass GrantDestinyClass { get; set; }
        public IEnumerable<uint> GroupedCategoryHashes { get; set; } = null;
        public IEnumerable<uint> ParentCategoryHashes { get; set; } = null;
        public bool GroupCategoryOnly { get; set; }
    }
}