using System.Collections.Generic;

namespace Destiny2.Definitions.Sockets
{
    public class DestinyPlugWhitelistEntryDefinition
    {
        public uint CategoryHash { get; set; }
        public string CategoryIdentifier { get; set; }
        public IEnumerable<uint> ReinitializationPossiblePlugHashes { get; set; }
    }
}