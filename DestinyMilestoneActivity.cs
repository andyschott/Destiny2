using System;
using System.Collections.Generic;

namespace Destiny2
{
    public class DestinyMilestoneActivity
    {
		public uint ActivityHash { get; set; }
		public IEnumerable<uint> ModifierHashes { get; set; }
		public IEnumerable<DestinyMilestoneActivityVariant> Variants { get; set; }
		public uint? ActivityModeHash { get; set; }
		public ActivityModeType? ActivityModeType { get; set; }
	}
}