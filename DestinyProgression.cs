using System.Collections.Generic;

namespace Destiny2
{
    public class DestinyProgression
    {
        public uint ProgressionHash { get; set; }
        public int DailyProgress { get; set; }
        public int DailyLimit { get; set; }
        public int WeeklyProgress { get; set; }
        public int WeeklyLimit { get; set; }
        public int CurrentProgress { get; set; }
        public int Level { get; set; }
        public int LevelCap { get; set; }
        public int StepIndex { get; set; }
        public int ProgressToNextLevel { get; set; }
        public int NextLevelAt { get; set; }
        public int? CurrentResetCount { get; set; }
        public IEnumerable<DestinyProgressionResetEntry> SeasonResets { get; set; }
        public IEnumerable<int> RewardItemStates { get; set; }
    }
}