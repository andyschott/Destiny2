using System;
using System.Collections.Generic;

namespace Destiny2
{
    public class DestinyMilestoneQuest
    {
		public uint QuestItemHash { get; set; }
		public DestinyMilestoneActivity Activity { get; set; }
		public DestinyMilestoneChallenge[] Challenges { get; set; }
	}
}