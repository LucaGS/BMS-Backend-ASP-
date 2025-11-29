namespace DotNet8.WebApi.Entities
{
    public class CrownInspection
    {
        public int Id { get; set; }
        public int InspectionId { get; set; }
        public string Notes { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Inspection? Inspection { get; set; }
        public bool AbioticDisturbance { get; set; }
        public string AbioticDisturbanceDescription { get; set; } = string.Empty;
        public bool Dying { get; set; }
        public string DyingDescription { get; set; } = string.Empty;
        public bool OverloadedBranchOrCrown { get; set; }
        public string OverloadedBranchOrCrownDescription { get; set; } = string.Empty;
        public bool BranchBreak { get; set; }
        public string BranchBreakDescription { get; set; } = string.Empty;
        public bool BranchBreakWound { get; set; }
        public string BranchBreakWoundDescription { get; set; } = string.Empty;
        public bool PruningWound { get; set; }
        public string PruningWoundDescription { get; set; } = string.Empty;
        public bool Exudation { get; set; }
        public string ExudationDescription { get; set; } = string.Empty;
        public bool TreeInGroup { get; set; }
        public string TreeInGroupDescription { get; set; } = string.Empty;
        public bool TreeIsDead { get; set; }
        public string TreeIsDeadDescription { get; set; } = string.Empty;
        public bool ForeignVegetation { get; set; }
        public string ForeignVegetationDescription { get; set; } = string.Empty;
        public bool BioticDisturbance { get; set; }
        public string BioticDisturbanceDescription { get; set; } = string.Empty;
        public bool LightningDamage { get; set; }
        public string LightningDamageDescription { get; set; } = string.Empty;
        public bool Deformed { get; set; }
        public string DeformedDescription { get; set; } = string.Empty;
        public bool CompressionFork { get; set; }
        public string CompressionForkDescription { get; set; } = string.Empty;
        public bool DryBranches { get; set; }
        public string DryBranchesDescription { get; set; } = string.Empty;
        public bool IncludedBark { get; set; }
        public string IncludedBarkDescription { get; set; } = string.Empty;
        public bool OneSidedCrown { get; set; }
        public string OneSidedCrownDescription { get; set; } = string.Empty;
        public bool ForeignObject { get; set; }
        public string ForeignObjectDescription { get; set; } = string.Empty;
        public bool Topped { get; set; }
        public string ToppedDescription { get; set; } = string.Empty;
        public bool HabitatStructure { get; set; }
        public string HabitatStructureDescription { get; set; } = string.Empty;
        public bool ResinFlow { get; set; }
        public string ResinFlowDescription { get; set; } = string.Empty;
        public bool Cavity { get; set; }
        public string CavityDescription { get; set; } = string.Empty;
        public bool CompetingBranch { get; set; }
        public string CompetingBranchDescription { get; set; } = string.Empty;
        public bool CompetingTree { get; set; }
        public string CompetingTreeDescription { get; set; } = string.Empty;
        public bool Canker { get; set; }
        public string CankerDescription { get; set; } = string.Empty;
        public bool CrownSecured { get; set; }
        public string CrownSecuredDescription { get; set; } = string.Empty;
        public bool LongitudinalCrack { get; set; }
        public string LongitudinalCrackDescription { get; set; } = string.Empty;
        public bool ClearanceProfile2_50m { get; set; }
        public string ClearanceProfile2_50mDescription { get; set; } = string.Empty;
        public bool ClearanceProfile4_50m { get; set; }
        public string ClearanceProfile4_50mDescription { get; set; } = string.Empty;
        public bool Burl { get; set; }
        public string BurlDescription { get; set; } = string.Empty;
        public bool OpenDecay { get; set; }
        public string OpenDecayDescription { get; set; } = string.Empty;
        public bool WithoutLeaderShoot { get; set; }
        public string WithoutLeaderShootDescription { get; set; } = string.Empty;
        public bool FungalFruitingBody { get; set; }
        public string FungalFruitingBodyDescription { get; set; } = string.Empty;
        public bool RubbingBranches { get; set; }
        public string RubbingBranchesDescription { get; set; } = string.Empty;
        public bool SlimeFlux { get; set; }
        public string SlimeFluxDescription { get; set; } = string.Empty;
        public bool SecondaryCrowns { get; set; }
        public string SecondaryCrownsDescription { get; set; } = string.Empty;
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
        public bool UnfavorableCrownDevelopment { get; set; }
        public string UnfavorableCrownDevelopmentDescription { get; set; } = string.Empty;
        public bool GraftPoint { get; set; }
        public string GraftPointDescription { get; set; } = string.Empty;
        public bool UtilityLineConflict { get; set; }
        public string UtilityLineConflictDescription { get; set; } = string.Empty;
        public bool TopDieback { get; set; }
        public string TopDiebackDescription { get; set; } = string.Empty;
        public bool Wound { get; set; }
        public string WoundDescription { get; set; } = string.Empty;
        public bool WoundWithCallusRidge { get; set; }
        public string WoundWithCallusRidgeDescription { get; set; } = string.Empty;
        public bool WoundCallusClosed { get; set; }
        public string WoundCallusClosedDescription { get; set; } = string.Empty;
        public bool TensionFork { get; set; }
        public string TensionForkDescription { get; set; } = string.Empty;
        public bool ForkedCrown { get; set; }
        public string ForkedCrownDescription { get; set; } = string.Empty;
        public bool ForkCrack { get; set; }
        public string ForkCrackDescription { get; set; } = string.Empty;
    }
}
