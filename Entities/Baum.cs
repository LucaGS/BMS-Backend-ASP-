namespace DotNet8.WebApi.Entities
{
    public class Baum
    {
        public int Id { get; set; }
        public int Nummer { get; set; }
        public string Art { get; set; } = string.Empty;
        public DateTime Pflanzdatum { get; set; }
        public double Hoehe { get; set; }
        public string Standort { get; set; } = string.Empty;
        public string Pflegehinweise { get; set; } = string.Empty;
        public string BildUrl { get; set; } = string.Empty;
            

    }
}
