using System;

namespace Destiny2
{
    [Flags]
    public enum DestinyProgressionRewardItemState
    {
        None = 0,
        Invisible = 1,
        Earned = 2,
        Claimed = 4,
        ClaimAllowed = 8,
    }
}