namespace DotNet8.WebApi.Dtos
{
    public class UpdateInspectionDto
    {
        public bool IsSafeForTraffic { get; set; }
        public int NewInspectionIntervall { get; set; }
        public string DevelopmentalStage { get; set; } = string.Empty;
        public int DamageLevel { get; set; }
        public int StandStability { get; set; }
        public int BreakageSafety { get; set; }
        public int Vitality { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
