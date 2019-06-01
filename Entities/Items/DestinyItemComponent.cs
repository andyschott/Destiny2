using Newtonsoft.Json;

namespace Destiny2.Entities.Items
{
    public class DestinyItemComponent
    {
        [JsonProperty(PropertyName = "itemHash")]
        public uint ItemHash { get; set; }
        [JsonProperty(PropertyName = "itemInstanceId")]
        public long ItemInstanceId { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
        // bindStatus
        [JsonProperty(PropertyName = "location")]
        public ItemLocation Location { get; set; }
        [JsonProperty(PropertyName = "bucketHash")]
        public uint BucketHash { get; set; }
        [JsonProperty(PropertyName = "transferStatus")]
        public TransferStatuses TransferStatus { get; set; }
        // lockable
        // state
        // overrideStyleItemHash
        // expirationDate
    }
}