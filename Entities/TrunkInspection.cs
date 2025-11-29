namespace DotNet8.WebApi.Entities
{
    public class TrunkInspection
    {
        public int Id { get; set; }
        public int InspectionId { get; set; }
        public string Notes { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Inspection? Inspection { get; set; }
        public bool AbioticDisturbance { get; set; }
        public string AbioticDisturbanceDescription { get; set; } = string.Empty;
        public bool BranchBreakWound { get; set; }
        public string BranchBreakWoundDescription { get; set; } = string.Empty;
        public bool PruningWound { get; set; }
        public string PruningWoundDescription { get; set; } = string.Empty;
        public bool Exudation { get; set; }
        public string ExudationDescription { get; set; } = string.Empty;
        public bool TreeRemoved { get; set; }
        public string TreeRemovedDescription { get; set; } = string.Empty;
        public bool BulgeOrSwelling { get; set; }
        public string BulgeOrSwellingDescription { get; set; } = string.Empty;
        public bool ForeignVegetation { get; set; }
        public string ForeignVegetationDescription { get; set; } = string.Empty;
        public bool BioticDisturbance { get; set; }
        public string BioticDisturbanceDescription { get; set; } = string.Empty;
        public bool LightningDamage { get; set; }
        public string LightningDamageDescription { get; set; } = string.Empty;
        public bool LeavesBrokenOff { get; set; }
        public string LeavesBrokenOffDescription { get; set; } = string.Empty;
        public bool Deformed { get; set; }
        public string DeformedDescription { get; set; } = string.Empty;
        public bool SpiralGrain { get; set; }
        public string SpiralGrainDescription { get; set; } = string.Empty;
        public bool CompressionFork { get; set; }
        public string CompressionForkDescription { get; set; } = string.Empty;
        public bool IncludedBark { get; set; }
        public string IncludedBarkDescription { get; set; } = string.Empty;
        public bool ForeignObject { get; set; }
        public string ForeignObjectDescription { get; set; } = string.Empty;
        public bool Topped { get; set; }
        public string ToppedDescription { get; set; } = string.Empty;
        public bool HabitatStructures { get; set; }
        public string HabitatStructuresDescription { get; set; } = string.Empty;
        public bool ResinFlow { get; set; }
        public string ResinFlowDescription { get; set; } = string.Empty;
        public bool Cavity { get; set; }
        public string CavityDescription { get; set; } = string.Empty;
        public bool Canker { get; set; }
        public string CankerDescription { get; set; } = string.Empty;
        public bool LongitudinalCrack { get; set; }
        public string LongitudinalCrackDescription { get; set; } = string.Empty;
        public bool MowingDamage { get; set; }
        public string MowingDamageDescription { get; set; } = string.Empty;
        public bool Burl { get; set; }
        public string BurlDescription { get; set; } = string.Empty;
        public bool OpenDecay { get; set; }
        public string OpenDecayDescription { get; set; } = string.Empty;
        public bool FungalFruitingBody { get; set; }
        public string FungalFruitingBodyDescription { get; set; } = string.Empty;
        public bool Leaning { get; set; }
        public string LeaningDescription { get; set; } = string.Empty;
        public bool SlimeFlux { get; set; }
        public string SlimeFluxDescription { get; set; } = string.Empty;
        public bool SecondaryRadialGrowthMissing { get; set; }
        public string SecondaryRadialGrowthMissingDescription { get; set; } = string.Empty;
        public bool WoodpeckerHole { get; set; }
        public string WoodpeckerHoleDescription { get; set; } = string.Empty;
        public bool CompressionDamage { get; set; }
        public string CompressionDamageDescription { get; set; } = string.Empty;
        public bool TorsionCrack { get; set; }
        public string TorsionCrackDescription { get; set; } = string.Empty;
        public bool Deadwood { get; set; }
        public string DeadwoodDescription { get; set; } = string.Empty;
        public bool WidowmakerBranch { get; set; }
        public string WidowmakerBranchDescription { get; set; } = string.Empty;
        public bool GraftPoint { get; set; }
        public string GraftPointDescription { get; set; } = string.Empty;
        public bool SupplyShadow { get; set; }
        public string SupplyShadowDescription { get; set; } = string.Empty;
        public bool Wobbles { get; set; }
        public string WobblesDescription { get; set; } = string.Empty;
        public bool Wound { get; set; }
        public string WoundDescription { get; set; } = string.Empty;
        public bool WoundCallusRidge { get; set; }
        public string WoundCallusRidgeDescription { get; set; } = string.Empty;
        public bool WoundCallusClosed { get; set; }
        public string WoundCallusClosedDescription { get; set; } = string.Empty;
        public bool TensionFork { get; set; }
        public string TensionForkDescription { get; set; } = string.Empty;
        public bool ForkedTrunk { get; set; }
        public string ForkedTrunkDescription { get; set; } = string.Empty;
        public bool ForkCrack { get; set; }
        public string ForkCrackDescription { get; set; } = string.Empty;
    }
}
