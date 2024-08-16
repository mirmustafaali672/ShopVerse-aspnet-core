using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopVerse.Brands;
using ShopVerse.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopVerse.Brands
{
    public class BrandAppService : IBrandAppService
    {
        private readonly ShopVerseDbContext _context;
        private readonly IMapper _mapper;

        public BrandAppService(ShopVerseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BrandGetDto> CreateAsync(BrandCreateOrUpdateDto BrandDto)
        {
            var Brand = _mapper.Map<Brand>(BrandDto);
            _context.Brands.Add(Brand);
            await _context.SaveChangesAsync();
            return _mapper.Map<BrandGetDto>(Brand);
        }

        public async Task<BrandGetDto> GetByIdAsync(Guid id)
        {
            var Brand = await _context.Brands.FindAsync(id);
            return _mapper.Map<BrandGetDto>(Brand);
        }

        public async Task<IEnumerable<BrandGetListDto>> GetAllAsync()
        {
            var Brands = await _context.Brands.ToListAsync();
            return _mapper.Map<IEnumerable<BrandGetListDto>>(Brands);
        }

        public async Task UpdateAsync(Guid id, BrandCreateOrUpdateDto BrandDto)
        {
            var Brand = await _context.Brands.FindAsync(id);
            if (Brand == null) throw new ArgumentException("Brand not found");

            _mapper.Map(BrandDto, Brand);
            _context.Brands.Update(Brand);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var Brand = await _context.Brands.FindAsync(id);
            if (Brand == null) throw new ArgumentException("Brand not found");

            _context.Brands.Remove(Brand);
            await _context.SaveChangesAsync();
        }
         public async Task<IEnumerable<BrandGetDto>> BulkCreateAsync(IEnumerable<BrandCreateOrUpdateDto> brandDtos)
        {
            var brands = _mapper.Map<IEnumerable<Brand>>(brandDtos);
            _context.Brands.AddRange(brands);
            await _context.SaveChangesAsync();

            return _mapper.Map<IEnumerable<BrandGetDto>>(brands);
        }
    }
}
