namespace DotNet8.WebApi.Dtos
{
    public class CreateTreeDto
    {
        public int GreenAreaId { get; set; }
        public int Number { get; set; }
        public string Species { get; set; } = string.Empty;
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double CrownDiameterMeters { get; set; }
        public double CrownAttachmentHeightMeters { get; set; }
        public int NumberOfTrunks { get; set; }
        public double TrunkInclination { get; set; }

    }
}
