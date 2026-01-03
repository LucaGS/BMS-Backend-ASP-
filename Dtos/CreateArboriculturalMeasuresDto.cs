namespace DotNet8.WebApi.Dtos
{
    public class CreateArboriculturalMeasuresDto
    {
        public String MeasureName { get; set; } = String.Empty;
        public String Description { get; set; } = String.Empty;
        public int UserId { get; set; } 
    }
}
