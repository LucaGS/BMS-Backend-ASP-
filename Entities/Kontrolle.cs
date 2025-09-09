namespace DotNet8.WebApi.Entities
{
    public class Kontrolle{
    
        public int Id { get; set; }
        public string NeuesKotnrollIntervall { get; set; } = string.Empty;
        public DateTime Datum { get; set; }
        public Boolean Verkehrssicher { get; set; }
    }
}
