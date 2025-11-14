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
        public String Entwicklungsphase { get; set; }
        public int Vitalitaet { get; set; }
        public int NeuesKontrollIntervallMonate { get; set; }
        public Boolean FaellungEmpfohlen { get; set; }
        public Boolean PflegemaﬂnahmenErfasst { get; set; }
        public Boolean UntersuchungVeranlasst{ get; set; }
        public String Description { get; set; }
    }
}
