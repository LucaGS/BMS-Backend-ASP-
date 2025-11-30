using Microsoft.EntityFrameworkCore;

namespace DotNet8.WebApi.Entities
{
    [Index(nameof(UserId), nameof(Number), IsUnique = true)]
    public class Tree
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GreenAreaId { get; set; }
        public int Number { get; set; }
        public string Species { get; set; } = string.Empty;
        public int? LastInspectionId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double CrownDiameterMeters { get; set; }
        public int NumberOfTrunks { get; set; }
        public double TrunkDiameter1 { get; set; }
        public double TrunkDiameter2 { get; set; }
        public double TrunkDiameter3 { get; set; }
        public double TreeSizeMeters { get; set; }
        public DateTime NextInspection { get; set; }
    }
}
