namespace DotNet8.WebApi.Entities
{
    public class TrunkInspection
    {
        public int Id { get; set; }
        public int InspectionId { get; set; }
        public string Notes { get; set; } = string.Empty;
        public Inspection? Inspection { get; set; }
        public bool AbioticDisturbance { get; set; }
        public bool BranchBreakWound { get; set; }
        public bool PruningWound { get; set; }
        public bool Exudation { get; set; }
        public bool TreeRemoved { get; set; }
        public bool BulgeOrSwelling { get; set; }
        public bool ForeignVegetation { get; set; }
        public bool BioticDisturbance { get; set; }
        public bool LightningDamage { get; set; }
        public bool LeavesBrokenOff { get; set; }
        public bool Deformed { get; set; }
        public bool SpiralGrain { get; set; }
        public bool CompressionFork { get; set; }
        public bool IncludedBark { get; set; }
        public bool ForeignObject { get; set; }
        public bool Topped { get; set; }
        public bool HabitatStructures { get; set; }
        public bool ResinFlow { get; set; }
        public bool Cavity { get; set; }
        public bool Canker { get; set; }
        public bool LongitudinalCrack { get; set; }
        public bool MowingDamage { get; set; }
        public bool Burl { get; set; }
        public bool OpenDecay { get; set; }
        public bool FungalFruitingBody { get; set; }
        public bool Leaning { get; set; }
        public bool SlimeFlux { get; set; }
        public bool SecondaryRadialGrowthMissing { get; set; }
        public bool WoodpeckerHole { get; set; }
        public bool CompressionDamage { get; set; }
        public bool TorsionCrack { get; set; }
        public bool Deadwood { get; set; }
        public bool WidowmakerBranch { get; set; }
        public bool GraftPoint { get; set; }
        public bool SupplyShadow { get; set; }
        public bool Wobbles { get; set; }
        public bool Wound { get; set; }
        public bool WoundCallusRidge { get; set; }
        public bool WoundCallusClosed { get; set; }
        public bool TensionFork { get; set; }
        public bool ForkedTrunk { get; set; }
        public bool ForkCrack { get; set; }
    }
}
