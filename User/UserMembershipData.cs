using System.Collections.Generic;
using Newtonsoft.Json;

namespace Destiny2.User
{
    public class UserMembershipData
    {
        [JsonProperty(PropertyName = "destinyMemberships")]
        public IList<UserInfoCard> Memberships { get; set; } = new List<UserInfoCard>();
    }
}