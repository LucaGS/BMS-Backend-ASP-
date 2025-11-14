namespace DotNet8.WebApi.Dtos
{
    public class CreateTreeDto
    {
        public int GreenAreaId { get; set; }
        public int Number { get; set; }
        public string Species { get; set; } = string.Empty;
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double TreeHeightMeters { get; set; }
        public double CrownDiameterMeters { get; set; }
        public double CrownBaseHeightMeters { get; set; }
        public int TrunkCount { get; set; }
        public int TrunkInclinationDegrees { get; set; }
    }
}
