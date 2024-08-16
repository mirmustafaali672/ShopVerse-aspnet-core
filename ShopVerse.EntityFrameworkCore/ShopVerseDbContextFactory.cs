using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShopVerse.EntityFrameworkCore
{
    public class ShopVerseDbContextFactory : IDesignTimeDbContextFactory<ShopVerseDbContext>
    {
        public ShopVerseDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopVerseDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=ShopVerse;Integrated Security=true;TrustServerCertificate=true;");

            return new ShopVerseDbContext(optionsBuilder.Options);
        }
    }
}
