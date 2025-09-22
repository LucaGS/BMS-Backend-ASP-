
    namespace DotNet8.WebApi.Entities
    {
        public class Kontrolle
        {
            public int Id { get; set; }
            public string NeuesKontrollIntervall { get; set; } = string.Empty; 
            public DateTime Datum { get; set; }
            public bool Verkehrssicher { get; set; }
            public int BaumId { get; set; }

        }
    }
