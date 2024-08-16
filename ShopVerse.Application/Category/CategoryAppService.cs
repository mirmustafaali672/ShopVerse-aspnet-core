using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopVerse.Categories;
using ShopVerse.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopVerse.Categories
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ShopVerseDbContext _context;
        private readonly IMapper _mapper;

        public CategoryAppService(ShopVerseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryGetDto> CreateAsync(CategoryCreateOrUpdateDto CategoryDto)
        {
            var Category = _mapper.Map<Category>(CategoryDto);
            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();
            return _mapper.Map<CategoryGetDto>(Category);
        }

        public async Task<CategoryGetDto> GetByIdAsync(Guid id)
        {
            var Category = await _context.Categories.FindAsync(id);
            return _mapper.Map<CategoryGetDto>(Category);
        }

        public async Task<IEnumerable<CategoryGetListDto>> GetAllAsync()
        {
            var Categories = await _context.Categories.ToListAsync();
            return _mapper.Map<IEnumerable<CategoryGetListDto>>(Categories);
        }

        public async Task UpdateAsync(Guid id, CategoryCreateOrUpdateDto CategoryDto)
        {
            var Category = await _context.Categories.FindAsync(id);
            if (Category == null) throw new ArgumentException("Category not found");

            _mapper.Map(CategoryDto, Category);
            _context.Categories.Update(Category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var Category = await _context.Categories.FindAsync(id);
            if (Category == null) throw new ArgumentException("Category not found");

            _context.Categories.Remove(Category);
            await _context.SaveChangesAsync();
        }
         public async Task<IEnumerable<CategoryGetDto>> BulkCreateAsync(IEnumerable<CategoryCreateOrUpdateDto> CategoryDtos)
        {
            var Categories = _mapper.Map<IEnumerable<Category>>(CategoryDtos);
            _context.Categories.AddRange(Categories);
            await _context.SaveChangesAsync();

            return _mapper.Map<IEnumerable<CategoryGetDto>>(Categories);
        }
    }
}
