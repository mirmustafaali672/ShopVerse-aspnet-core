namespace ShopVerse.Products;
public class ProductGetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid BrandId { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Rating { get; set; }
    public ICollection<ProductGetImage>? ProductImages { get; set; }
}
public class ProductCreateOrUpdateDto
{
    public string Name { get; set; }
    public Guid BrandId { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Rating { get; set; }
    public ICollection<CreateOrUpdateProductImage>? ProductImages { get; set; }
}
public class ProductGetListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid BrandId { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Rating { get; set; }
    public ICollection<ProductGetImage>? ProductImages { get; set; }
}

public class ProductGetImage
{
    public Guid Id { get; set; }
    public string ImageBase64 { get; set; }
    public Guid ProductId { get; set; }
}

public class CreateOrUpdateProductImage
{
    public Guid Id { get; set; }
    public string ImageBase64 { get; set; }
    public Guid ProductId { get; set; }
}

