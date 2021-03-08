using System;
using System.Collections.Generic;

namespace Destiny2
{
    public class DestinyMilestone
    {
		public uint MilestoneHash { get; set; }
		public IEnumerable<DestinyMilestoneQuest> AvailableQuests { get; set; }
		public IEnumerable<DestinyMilestoneChallengeActivity> Activities { get; set; }
		public uint[] VendorHashes { get; set; }
		public IEnumerable<DestinyMilestoneVendor> Vendors { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public int Order { get; set; }
	}
}