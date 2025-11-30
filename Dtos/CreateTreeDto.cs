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
        public int NumberOfTrunks { get; set; }
        public double TrunkDiameter1 { get; set; }
        public double TrunkDiameter2 { get; set; }
        public double TrunkDiameter3 { get; set; }

    }
}
