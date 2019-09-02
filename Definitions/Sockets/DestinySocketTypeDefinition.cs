using System.Collections.Generic;

namespace Destiny2.Definitions.Sockets
{
    public class DestinySocketTypeDefinition : AbstractDefinition
    {
        // insertAction
        public IEnumerable<DestinyPlugWhitelistEntryDefinition> PlugWhiteList { get; set; }
        public uint SocketCategoryHash { get; set; }
        public int Visibility { get; set; }
        public bool AlwaysRandomizeSockets { get; set; }
        public bool IsPreviewEnabled { get; set; }
        public bool HideDuplicateReusablePlugs { get; set; }
        public bool OverridesUiAppearance { get; set; }
        public bool AvoidDuplicatesOnInitialization { get; set; }
        // currencyScalars
    }
}