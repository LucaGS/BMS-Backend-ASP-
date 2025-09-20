using DotNet8.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.WebApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Baum> Baeume { get; set; }
        public DbSet<Kontrolle> Kontrollen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Baum -> (optionale) LetzteKontrolle
            modelBuilder.Entity<Baum>()
                .HasOne(b => b.LetzteKontrolle)
                .WithMany()
                .HasForeignKey(b => b.LetzteKontrolleID)
                .OnDelete(DeleteBehavior.SetNull);   // ok

            // Baum -> * Kontrollen  (KEINE DB-Kaskade!)
            modelBuilder.Entity<Kontrolle>()
                .HasOne(k => k.Baum)
                .WithMany(b => b.Kontrollen)
                .HasForeignKey(k => k.BaumId)
                .OnDelete(DeleteBehavior.Restrict);  // oder .NoAction()
        }   

    }
}
