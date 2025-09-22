using DotNet8.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.WebApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Baum> Baeume { get; set; }
        public DbSet<Kontrolle> Kontrollen { get; set; }
        public DbSet<Bilder> Bilder { get; set; }
        public DbSet<GruenFlaeche> GruenFlaechen { get; set; }   

    }
}
