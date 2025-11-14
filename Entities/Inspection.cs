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
    }
}
