namespace ShopVerse.Brands;
public interface IBrandAppService
{
    Task<BrandGetDto> CreateAsync(BrandCreateOrUpdateDto BrandDto);
    Task<BrandGetDto> GetByIdAsync(Guid id);
    Task<IEnumerable<BrandGetListDto>> GetAllAsync();
    Task UpdateAsync(Guid id, BrandCreateOrUpdateDto BrandDto);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<BrandGetDto>> BulkCreateAsync(IEnumerable<BrandCreateOrUpdateDto> brandDtos);
}