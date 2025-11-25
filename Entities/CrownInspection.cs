namespace DotNet8.WebApi.Entities
{
    public class CrownInspection
    {
        public int Id { get; set; }
        public int InspectionId { get; set; }
        public string Notes { get; set; } = string.Empty;
        public Inspection? Inspection { get; set; }
        public bool AbioticDisturbance { get; set; }
        public bool Dying { get; set; }
        public bool OverloadedBranchOrCrown { get; set; }
        public bool BranchBreak { get; set; }
        public bool BranchBreakWound { get; set; }
        public bool PruningWound { get; set; }
        public bool Exudation { get; set; }
        public bool TreeInGroup { get; set; }
        public bool TreeIsDead { get; set; }
        public bool ForeignVegetation { get; set; }
        public bool BioticDisturbance { get; set; }
        public bool LightningDamage { get; set; }
        public bool Deformed { get; set; }
        public bool CompressionFork { get; set; }
        public bool DryBranches { get; set; }
        public bool IncludedBark { get; set; }
        public bool OneSidedCrown { get; set; }
        public bool ForeignObject { get; set; }
        public bool Topped { get; set; }
        public bool HabitatStructure { get; set; }
        public bool ResinFlow { get; set; }
        public bool Cavity { get; set; }
        public bool CompetingBranch { get; set; }
        public bool CompetingTree { get; set; }
        public bool Canker { get; set; }
        public bool CrownSecured { get; set; }
        public bool LongitudinalCrack { get; set; }
        public bool ClearanceProfile2_50m { get; set; }
        public bool ClearanceProfile4_50m { get; set; }
        public bool Burl { get; set; }
        public bool OpenDecay { get; set; }
        public bool WithoutLeaderShoot { get; set; }
        public bool FungalFruitingBody { get; set; }
        public bool RubbingBranches { get; set; }
        public bool SlimeFlux { get; set; }
        public bool SecondaryCrowns { get; set; }
        public bool WoodpeckerHole { get; set; }
        public bool CompressionDamage { get; set; }
        public bool TorsionCrack { get; set; }
        public bool Deadwood { get; set; }
        public bool WidowmakerBranch { get; set; }
        public bool UnfavorableCrownDevelopment { get; set; }
        public bool GraftPoint { get; set; }
        public bool UtilityLineConflict { get; set; }
        public bool TopDieback { get; set; }
        public bool Wound { get; set; }
        public bool WoundWithCallusRidge { get; set; }
        public bool WoundCallusClosed { get; set; }
        public bool TensionFork { get; set; }
        public bool ForkedCrown { get; set; }
        public bool ForkCrack { get; set; }
    }
}
