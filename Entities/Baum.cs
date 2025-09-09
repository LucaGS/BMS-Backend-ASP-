namespace DotNet8.WebApi.Entities
{
    public class Baum
    {
        public int Id { get; set; }
        public int Nummer { get; set; }
        public string Art { get; set; } = string.Empty;
        public Kontrolle? LetzteKontrolle { get; set; } = new Kontrolle();
        public ICollection<Kontrolle> Kontrollen { get; set; } = new List<Kontrolle>();
        public int? LetzteKontrolleID;
    }
}
