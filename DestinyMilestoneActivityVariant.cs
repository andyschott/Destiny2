using System;
using System.Collections.Generic;

namespace Destiny2
{
    public class DestinyMilestoneActivityVariant
	{
		public uint ActivityHash { get; set; }
		public uint? ActivityModeHash { get; set; }
		public ActivityModeType? ActivityModeType { get; set; }
	}
}