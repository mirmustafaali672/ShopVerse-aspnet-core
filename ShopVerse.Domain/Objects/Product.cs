using System.Diagnostics.CodeAnalysis;

namespace ShopVerse.Products;
public class Product
{
    [NotNull]
    public Guid Id { get; set; }
    [NotNull]
    public string Name { get; set; }
    public Guid BrandId { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Rating { get; set; }
    public ICollection<ProductImage>? ProductImages { get; set; }
}

public class ProductImage
{
    public Guid Id { get; set; } // Add Id for primary key
    public string ImageBase64 { get; set; }
    public Guid ProductId { get; set; } // Foreign key
    public Product Product { get; set; } // Navigation property
}