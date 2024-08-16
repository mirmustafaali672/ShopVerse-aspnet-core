using Microsoft.EntityFrameworkCore;
using ShopVerse.Demos;
using ShopVerse.Domain;
using ShopVerse.Shared.Constants;

namespace ShopVerse.EntityFrameworkCore
{
    public class ShopVerseDbContext : DbContext
    {
        public ShopVerseDbContext(DbContextOptions<ShopVerseDbContext> options)
            : base(options)
        {
        }
        public DbSet<Demo> Demos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopVerseDbContext).Assembly);

            modelBuilder.Entity<Demo>(entity =>
            {
                // Specify the table name
                entity.ToTable("Tablename", ShopVerseConts.AppName);
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });
        }
        
    }
}
