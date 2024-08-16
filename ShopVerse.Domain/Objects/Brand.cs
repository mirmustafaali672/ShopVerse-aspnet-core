using System.Diagnostics.CodeAnalysis;

namespace ShopVerse.Brands;
public class Brand{
    [NotNull]
    public Guid Id { get; set; }
    [NotNull]
    public string Name { get; set; }
    [NotNull]
    public string Description { get; set; }
    [NotNull]
    public string CountryOfOrigin { get; set; }
    public string LogoURL { get; set; }
    [NotNull]
    public DateTime DateEstablished { get; set; }
    public decimal BrandRating { get; set; }
}