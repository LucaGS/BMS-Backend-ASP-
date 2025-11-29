namespace DotNet8.WebApi.Entities
{
    public class ArboriculturalMeasure
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MeasureName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Inspection> Inspections { get; set; } = new List<Inspection>();
    }
}
