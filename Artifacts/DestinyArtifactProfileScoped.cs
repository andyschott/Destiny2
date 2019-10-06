namespace Destiny2.Artifacts
{
    public class DestinyArtifactProfileScoped
    {
        public uint ArtifactHash { get; set; }
        public DestinyProgression PointProgression { get; set; }
        public int PointsAcquired { get; set; }
        public DestinyProgression PowerBonusProgression { get; set; }
        public int PowerBonus { get; set; }
    }
}