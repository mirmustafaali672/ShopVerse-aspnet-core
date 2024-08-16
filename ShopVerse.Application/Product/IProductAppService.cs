namespace ShopVerse.Products;
public interface IProductAppService
{
    Task<ProductGetDto> CreateAsync(ProductCreateOrUpdateDto ProductDto);
    Task<ProductGetDto> GetByIdAsync(Guid id);
    Task<IEnumerable<ProductGetListDto>> GetAllAsync();
    Task UpdateAsync(Guid id, ProductCreateOrUpdateDto ProductDto);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<ProductGetDto>> BulkCreateAsync(IEnumerable<ProductCreateOrUpdateDto> ProductDtos);
}