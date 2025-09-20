namespace DotNet8.WebApi.Entities
{
    public class Baum
    {
        public int Id { get; set; }
        public int Nummer { get; set; }
        public string Art { get; set; } = string.Empty;
        public Bilder? Bild { get; set; }
        // Optionales 1:1 auf die letzte Kontrolle
        public int? LetzteKontrolleID { get; set; }
        public Kontrolle? LetzteKontrolle { get; set; }

        public double Laengengrad { get; set; }
        public double Breitengrad { get; set; }

        public ICollection<Kontrolle> Kontrollen { get; set; } = new List<Kontrolle>();
    }
}
