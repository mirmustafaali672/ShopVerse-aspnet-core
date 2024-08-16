using Microsoft.EntityFrameworkCore;
using ShopVerse.Brands;
using ShopVerse.Demos;
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
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopVerseDbContext).Assembly);

            modelBuilder.Entity<Demo>(entity =>
            {
                entity.ToTable("Demos", ShopVerseConts.AppName);
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<Brand>( entity =>
            {
                entity.ToTable("Brands", ShopVerseConts.AppName);
                entity.Property( e => e.Name).IsRequired();
                entity.HasIndex( e => e.Name).IsUnique();
                entity.Property( e => e.CountryOfOrigin).IsRequired();
                entity.Property( e => e.DateEstablished).IsRequired();
            });
        }
        
    }
}
