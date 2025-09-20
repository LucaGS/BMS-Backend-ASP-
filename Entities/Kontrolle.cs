
    namespace DotNet8.WebApi.Entities
    {
        public class Kontrolle
        {
            public int Id { get; set; }
            public string NeuesKontrollIntervall { get; set; } = string.Empty; // Tippfehler korrigiert
            public DateTime Datum { get; set; }
            public bool Verkehrssicher { get; set; }

            public int BaumId { get; set; }
            public Baum Baum { get; set; } = null!;

        }
    }
