using System.Threading.Tasks;
using Destiny2.Config;
using Destiny2.Responses;
using Destiny2.User;

namespace Destiny2
{
    public interface IDestiny
    {
         Task<Manifest> GetManifest();
         Task<DestinyLinkedProfilesResponse> GetLinkedProfiles(string accessToken, long membershipId,
             BungieMembershipType type = BungieMembershipType.BungieNext);
        Task<DestinyProfileResponse> GetProfile(string accessToken, BungieMembershipType type, long id);
        Task<DestinyProfileResponse> GetProfile(string accessToken, BungieMembershipType type, long id,
            params DestinyComponentType[] components);
        Task<DestinyCharacterResponse> GetCharacterInfo(string accessToken, BungieMembershipType type, long id,
            long characterId, params DestinyComponentType[] infos);
        Task<DestinyItemResponse> GetItem(string accessToken, BungieMembershipType type, long id, long itemInstanceId,
            params DestinyComponentType[] infos);
        Task<bool> DownloadFile(string relativePath, string destination);
    }
}