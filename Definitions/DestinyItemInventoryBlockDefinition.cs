using Newtonsoft.Json;

namespace Destiny2.Definitions
{
    public class DestinyItemInventoryBlockDefinition
    {
        // stackUniqueLabel
        // maxStackSize
        [JsonProperty(PropertyName = "bucketTypeHash")]
        public uint BucketTypeHash { get; set; }
        // recoveryBucketTypeHash
        // recoveryBucketTypeHash
        [JsonProperty(PropertyName = "isInstanceItem")]
        public bool IsInstanceItem { get; set; }
        // tierTypeName
        // tierType
        // expirationTooltip
        // expiredInActivityMessage
        // expiredInOrbitMessage
        // suppressExpirationWhenObjectivesComplete
    }
}