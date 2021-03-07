using System.Collections.Generic;

namespace Destiny2.Entities.Characters
{
    public class DestinyCharacterActivitiesComponent
    {
        public IEnumerable<DestinyActivity> AvailableActivities { get; set; }

            //dateActivityStarted
            //currentActivityHash
            //currentActivityModeHash
            //currentActivityModeType
            //currentActivityModeHashes
            //currentActivityModeTypes
            //currentPlaylistActivityHash
            //lastCompletedStoryHash
    }
}
