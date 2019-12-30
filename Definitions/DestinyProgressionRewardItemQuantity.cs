using System.Collections.Generic;

namespace Destiny2.Definitions
{
    public class DestinyProgressionRewardItemQuantity
    {
        public int RewardedAtProgressionLevel { get; set; }
        public int AcquisionBehavior { get; set; }
        public string UIDisplayStyle { get; set; }
        public IEnumerable<string> ClaimUnlockDisplayStrings { get; set; }
        public uint ItemHash { get; set; }
        public long? ItemInstanceId { get; set; }
        public int Quantity { get; set; }
    }
}