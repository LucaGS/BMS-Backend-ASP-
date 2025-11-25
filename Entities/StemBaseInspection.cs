namespace DotNet8.WebApi.Entities
{
    public class StemBaseInspection
    {
        public int Id { get; set; }
        public int InspectionId { get; set; }
        public string Notes { get; set; } = string.Empty;
        public Inspection? Inspection { get; set; }
        public bool Excavation { get; set; }
        public bool AdventitiousRootFormation { get; set; }
        public bool Exudation { get; set; }
        public bool StructuresAtStemBase { get; set; }
        public bool StructuresNearTree { get; set; }
        public bool BulgeOrSwelling { get; set; }
        public bool ForeignVegetation { get; set; }
        public bool BoreDust { get; set; }
        public bool Bottleneck { get; set; }
        public bool ForeignObject { get; set; }
        public bool HabitatStructures { get; set; }
        public bool TreeOnSlope { get; set; }
        public bool ResinFlow { get; set; }
        public bool Cavity { get; set; }
        public bool Canker { get; set; }
        public bool OpenDecay { get; set; }
        public bool FungalFruitingBody { get; set; }
        public bool SlimeFlux { get; set; }
        public bool StemBaseThickened { get; set; }
        public bool CompressionDamage { get; set; }
        public bool Overfilled { get; set; }
        public bool GraftPoint { get; set; }
        public bool GirdlingRoot { get; set; }
        public bool RootDamage { get; set; }
    }
}
