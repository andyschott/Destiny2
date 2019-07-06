using System.Collections.Generic;
using Destiny2.User;

namespace Destiny2.Responses
{
    public class DestinyLinkedProfilesResponse
    {
        public IEnumerable<DestinyProfileUserInfoCard> Profiles { get; set; }
        public UserInfoCard BNetMembership { get; set; }
        // profilesWithErrors
    }
}