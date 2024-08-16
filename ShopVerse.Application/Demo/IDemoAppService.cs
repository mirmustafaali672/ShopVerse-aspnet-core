namespace ShopVerse.Demos
{
    public interface IDemoAppService
    {
        Task<DemoGetDto> CreateAsync(DemoCreateOrUpdateDto demoDto);
        Task<DemoGetDto> GetByIdAsync(Guid id);
        Task<IEnumerable<DemoGetDto>> GetAllAsync();
        Task UpdateAsync(Guid id, DemoCreateOrUpdateDto demoDto);
        Task DeleteAsync(Guid id);
        bool DemoCall();
    }
}
