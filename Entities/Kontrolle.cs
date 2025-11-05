
    namespace DotNet8.WebApi.Entities
    {
        public class Kontrolle
        {
            public int Id { get; set; } 
            public DateTime Datum { get; set; }
            public bool Verkehrssicher { get; set; }
            public int BaumId { get; set; }
            public int UserId { get; set; }
    }
    }
