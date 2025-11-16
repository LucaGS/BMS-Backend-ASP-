namespace DotNet8.WebApi.Dtos
{
    public class CreateInspectionDto
    {
        public bool IsSafeForTraffic { get; set; }
        public int TreeId { get; set; }
        public CreateCrownInspectionDto CrownInspection { get; set; } = new();
        public CreateTrunkInspectionDto TrunkInspection { get; set; } = new();  
    }
}
