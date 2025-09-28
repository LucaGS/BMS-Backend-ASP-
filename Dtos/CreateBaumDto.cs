namespace DotNet8.WebApi.Dtos
{
    public class CreateBaumDto
    {   public int GruenFlaechenId { get; set; }
        public int Nummer { get; set; }
        public string Art { get; set; } = string.Empty;
        public double Laengengrad { get; set; }
        public double Breitengrad{get; set; }
    }
}
