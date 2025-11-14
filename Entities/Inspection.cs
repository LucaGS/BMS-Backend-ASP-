using System;

namespace DotNet8.WebApi.Entities
{
    public class Inspection
    {
        public int Id { get; set; }
        public DateTime PerformedAt { get; set; }
        public bool IsSafeForTraffic { get; set; }
        public int TreeId { get; set; }
        public int UserId { get; set; }
        public int TreeSizeCM { get; set; }
        public string Entwicklungsphase { get; set; } = string.Empty;
        public int Vitalitaet { get; set; }
        public int NeuesKontrollIntervallMonate { get; set; }
        public bool FaellungEmpfohlen { get; set; }
        public bool PflegemassnahmenErfasst { get; set; }
        public bool UntersuchungVeranlasst { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
