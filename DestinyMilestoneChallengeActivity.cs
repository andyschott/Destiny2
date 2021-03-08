using System;
using System.Collections.Generic;

namespace Destiny2
{
    public class DestinyMilestoneChallengeActivity
	{
		public uint ActivityHash { get; set; }
		public uint[] ChallengeObjectiveHashes { get; set; }
		public uint[] ModifierHashes { get; set; }
		public int? LoadoutRequirementIndex { get; set; }
		public uint[] PhaseHashes { get; set; }
		public IDictionary<uint, bool> BooleanActivityOptions { get; set; }
	}
}