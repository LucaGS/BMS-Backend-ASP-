namespace DotNet8.WebApi.Entities
{
    public class GreenArea
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Longitude { get; set; }
        public double Latitude { get; set; }

    }
}
