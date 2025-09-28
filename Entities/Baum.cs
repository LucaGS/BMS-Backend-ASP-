using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet8.WebApi.Entities
{
    [Index(nameof(Nummer), IsUnique = true)]
    public class Baum
    {   public int UserId { get; set; } 
        public int? Id { get; set; }
        public int GruenFlächenId { get; set; }
        public int Nummer { get; set; }
        public string Art { get; set; } = string.Empty;
        public int? LetzteKontrolleID { get; set; }
        public double Laengengrad { get; set; }
        public double Breitengrad{get; set;}
    }
}
       