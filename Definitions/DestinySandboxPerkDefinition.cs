namespace Destiny2.Definitions
{
    public class DestinySandboxPerkDefinition : AbstractDefinition
    {
        public string PerkIdentifier { get; set; }
        public bool IsDisplayable { get; set; }
        public uint? DamageTypeHash { get; set; }
    }
}