using Newtonsoft.Json;

namespace Destiny2.Entities.Items
{
    public class DestinyItemInstanceComponent
    {
        [JsonProperty(PropertyName = "damageType")]
        public DamageType DamageType { get; set; }
        [JsonProperty(PropertyName = "damageTypeHash")]
        public uint DamageTypeHash { get; set; }
        [JsonProperty(PropertyName = "primaryStat")]
        public DestinyStat PrimaryStat { get; set; }
        [JsonProperty(PropertyName = "itemLevel")]
        public int ItemLevel { get; set; }
        [JsonProperty(PropertyName = "quality")]
        public int Quality { get; set; }
        [JsonProperty(PropertyName = "isEquipped")]
        public bool IsEquipped { get; set; }
        [JsonProperty(PropertyName = "canEquip")]
        public bool CanEquip { get; set; }
        [JsonProperty(PropertyName = "equipRequiredLevel")]
        public int EquipRequiredLevel { get; set; }
        // unlockHashesRequiredToEquip
        // cannotEquipReason
    }
}