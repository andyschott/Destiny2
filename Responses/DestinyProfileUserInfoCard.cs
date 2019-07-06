namespace Destiny2.Responses
{
    public class DestinyProfileUserInfoCard
    {
        // dateLastPlayed
        // supplementalDisplayName
        // iconPath
        public BungieMembershipType MembershipType { get; set; }
        public long MembershipId { get; set; }
        public string DisplayName { get; set; }
    }
}