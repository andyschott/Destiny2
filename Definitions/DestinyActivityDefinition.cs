using Destiny2.Definitions.Common;

namespace Destiny2.Definitions
{
    public class DestinyActivityDefinition : AbstractDefinition
    {
        public DestinyDisplayPropertiesDefinition OriginalDisplayProperties { get; set; }
        public DestinyDisplayPropertiesDefinition SelectionScreenDisplayProperties { get; set; }
        public string ReleaseIcon { get; set; }
        public int ReleaseTime { get; set; }
        public int ActivityLightLevel { get; set; }
        public uint DestinationHash { get; set; }
        public uint PlaceHash { get; set; }
        public uint ActivityTypeHash { get; set; }
        public int Tier { get; set; }
        // pgcrImage
        // rewards
        // modifiers
        // isPlaylist
        // challenges
        // optionalUnlockStrings
        // playlistItems
        // activityGraphList
        // matchmaking
        // guidedGame
        // directActivityModeHash
        // directActivityModeType
        // loadouts
        // activityModeHashes
        // activityModeTYpes
        // isPvP
        // insertionPoints
        // activityLocationMappings        
    }
}