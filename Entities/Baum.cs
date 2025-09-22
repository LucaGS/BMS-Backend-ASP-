namespace DotNet8.WebApi.Entities
{
    public class Baum
    {
        public int? Id { get; set; }
        public int GruenFlächenId { get; set; }
        public int Nummer { get; set; }
        public string Art { get; set; } = string.Empty;
        public int? LetzteKontrolleID { get; set; }
        public double Laengengrad { get; set; }
        public double Breitengrad{get; set;}
    }
}
       