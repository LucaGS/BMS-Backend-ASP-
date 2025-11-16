using DotNet8.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.WebApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tree> Trees { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<GreenArea> GreenAreas { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
