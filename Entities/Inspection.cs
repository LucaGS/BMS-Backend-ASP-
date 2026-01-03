using System;

namespace DotNet8.WebApi.Entities
{
    public class Inspection
    {
        public int Id { get; set; }
        public DateTime PerformedAt { get; set; }
        public bool IsSafeForTraffic { get; set; }
        public int TreeId { get; set; }
        public int UserId { get; set; }
        public int NewInspectionIntervall { get; set; }
        public string DevelopmentalStage { get; set; } = string.Empty;
        public int Vitality { get; set; }
        public String Description { get; set; } = string.Empty;
        public CrownInspection CrownInspection { get; set; } = new();
        public TrunkInspection TrunkInspection { get; set; } = new();
        public StemBaseInspection StemBaseInspection { get; set; } = new();
        public ICollection<ArboriculturalMeasure> ArboriculturalMeasures { get; set; } = new List<ArboriculturalMeasure>();
    }
}
