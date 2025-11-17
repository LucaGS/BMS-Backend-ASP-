namespace DotNet8.WebApi.Dtos
{
    public class CreateGreenAreaDto
    {
        public string Name { get; set; } = string.Empty;
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
