namespace DotNet8.WebApi.Dtos
{
    public class CreateStemBaseInspectionDto
    {
        public string Notes { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Excavation { get; set; }
        public string ExcavationDescription { get; set; } = string.Empty;
        public bool AdventitiousRootFormation { get; set; }
        public string AdventitiousRootFormationDescription { get; set; } = string.Empty;
        public bool Exudation { get; set; }
        public string ExudationDescription { get; set; } = string.Empty;
        public bool StructuresAtStemBase { get; set; }
        public string StructuresAtStemBaseDescription { get; set; } = string.Empty;
        public bool StructuresNearTree { get; set; }
        public string StructuresNearTreeDescription { get; set; } = string.Empty;
        public bool BulgeOrSwelling { get; set; }
        public string BulgeOrSwellingDescription { get; set; } = string.Empty;
        public bool ForeignVegetation { get; set; }
        public string ForeignVegetationDescription { get; set; } = string.Empty;
        public bool BoreDust { get; set; }
        public string BoreDustDescription { get; set; } = string.Empty;
        public bool Bottleneck { get; set; }
        public string BottleneckDescription { get; set; } = string.Empty;
        public bool ForeignObject { get; set; }
        public string ForeignObjectDescription { get; set; } = string.Empty;
        public bool HabitatStructures { get; set; }
        public string HabitatStructuresDescription { get; set; } = string.Empty;
        public bool TreeOnSlope { get; set; }
        public string TreeOnSlopeDescription { get; set; } = string.Empty;
        public bool ResinFlow { get; set; }
        public string ResinFlowDescription { get; set; } = string.Empty;
        public bool Cavity { get; set; }
        public string CavityDescription { get; set; } = string.Empty;
        public bool Canker { get; set; }
        public string CankerDescription { get; set; } = string.Empty;
        public bool OpenDecay { get; set; }
        public string OpenDecayDescription { get; set; } = string.Empty;
        public bool FungalFruitingBody { get; set; }
        public string FungalFruitingBodyDescription { get; set; } = string.Empty;
        public bool SlimeFlux { get; set; }
        public string SlimeFluxDescription { get; set; } = string.Empty;
        public bool StemBaseThickened { get; set; }
        public string StemBaseThickenedDescription { get; set; } = string.Empty;
        public bool CompressionDamage { get; set; }
        public string CompressionDamageDescription { get; set; } = string.Empty;
        public bool Overfilled { get; set; }
        public string OverfilledDescription { get; set; } = string.Empty;
        public bool GraftPoint { get; set; }
        public string GraftPointDescription { get; set; } = string.Empty;
        public bool GirdlingRoot { get; set; }
        public string GirdlingRootDescription { get; set; } = string.Empty;
        public bool RootDamage { get; set; }
        public string RootDamageDescription { get; set; } = string.Empty;
    }
}
