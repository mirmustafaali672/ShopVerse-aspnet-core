using Microsoft.EntityFrameworkCore;
using ShopVerse.Domain;

namespace ShopVerse.EntityFrameworkCore
{
    public class ShopVerseDbContext : DbContext
    {
        public ShopVerseDbContext(DbContextOptions<ShopVerseDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopVerseDbContext).Assembly);
        }
    }
}
