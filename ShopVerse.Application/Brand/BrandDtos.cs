namespace ShopVerse.Brands;
public class BrandGetDto{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CountryOfOrigin { get; set; }
    public string LogoURL { get; set; }
    public DateTime DateEstablished { get; set; }
    public decimal BrandRating { get; set; }
}
public class BrandCreateOrUpdateDto{
    public string Name { get; set; }
    public string Description { get; set; }
    public string CountryOfOrigin { get; set; }
    public string LogoURL { get; set; }
    public DateTime DateEstablished { get; set; }
    public decimal BrandRating { get; set; }
}
public class BrandGetListDto {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LogoURL { get; set; }
}


