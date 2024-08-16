namespace ShopVerse.Categories;
public interface ICategoryAppService
{
    Task<CategoryGetDto> CreateAsync(CategoryCreateOrUpdateDto CategoryDto);
    Task<CategoryGetDto> GetByIdAsync(Guid id);
    Task<IEnumerable<CategoryGetListDto>> GetAllAsync();
    Task UpdateAsync(Guid id, CategoryCreateOrUpdateDto CategoryDto);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<CategoryGetDto>> BulkCreateAsync(IEnumerable<CategoryCreateOrUpdateDto> CategoryDtos);
}