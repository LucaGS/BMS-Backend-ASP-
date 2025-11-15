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
        public double CrownAttachmentHeightMeters { get; set; }
        public int NumberOfTrunks { get; set; }
        public double TrunkInclination { get; set; }


    }
}
