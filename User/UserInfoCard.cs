using Newtonsoft.Json;

namespace Destiny2.User
{
    public class UserInfoCard
    {
        [JsonProperty(PropertyName = "supplementalDisplayName")]
        public string SupplementalDisplayName { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "iconPath")]
        public string IconPath { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "membershipType")]
        public BungieMembershipType MembershipType { get; set; } = BungieMembershipType.None;

        [JsonProperty(PropertyName = "membershipId")]
        public long MembershipId { get; set; } = 0L;

        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; } = string.Empty;
    }
}