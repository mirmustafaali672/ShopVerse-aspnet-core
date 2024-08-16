using Microsoft.EntityFrameworkCore;
using ShopVerse.Brands;
using ShopVerse.Demos;
using ShopVerse.Shared.Constants;
using ShopVerse.Products;


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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; } // Add DbSet for Products
        public DbSet<ProductImage> ProductImages { get; set; } // Add DbSet for ProductImages

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

            modelBuilder.Entity<Category> ( entity =>
            {
                entity.ToTable("Categories", ShopVerseConts.AppName);
                entity.Property( e => e.Name).IsRequired();
            });


            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products", ShopVerseConts.AppName);
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.Rating).IsRequired();
                entity.HasOne<Brand>()
                    .WithMany() // Assuming Brand does not have a navigation property for Products
                    .HasForeignKey(e => e.BrandId);
                entity.HasOne<Category>()
                    .WithMany() // Assuming Category does not have a navigation property for Products
                    .HasForeignKey(e => e.CategoryId);
                entity.HasMany(e => e.ProductImages)
                    .WithOne(e => e.Product)
                    .HasForeignKey(e => e.ProductId)
                    .HasPrincipalKey( e => e.Id);
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("ProductImages", ShopVerseConts.AppName);
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ImageBase64).IsRequired();
            });
        }
        
    }
}
