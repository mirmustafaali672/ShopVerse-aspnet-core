using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopVerse.Products;
using ShopVerse.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopVerse.Products
{
    public class ProductAppService : IProductAppService
    {
        private readonly ShopVerseDbContext _context;
        private readonly IMapper _mapper;

        public ProductAppService(ShopVerseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductGetDto> CreateAsync(ProductCreateOrUpdateDto ProductDto)
        {
            var Product = _mapper.Map<Product>(ProductDto);
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductGetDto>(Product);
        }

        public async Task<ProductGetDto> GetByIdAsync(Guid id)
        {
            var Product = await _context.Products.Include( p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == id);
            if (Product == null) throw new ArgumentException("Product not found");
            return _mapper.Map<ProductGetDto>(Product);
        }

        public async Task<IEnumerable<ProductGetListDto>> GetAllAsync()
        {
            var Products = await _context.Products.Include( p => p.ProductImages).ToListAsync();
            return _mapper.Map<IEnumerable<ProductGetListDto>>(Products);
        }

        public async Task UpdateAsync(Guid id, ProductCreateOrUpdateDto ProductDto)
        {
            var Product = await _context.Products.FindAsync(id);
            if (Product == null) throw new ArgumentException("Product not found");

            _mapper.Map(ProductDto, Product);
            _context.Products.Update(Product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var Product = await _context.Products.FindAsync(id);
            if (Product == null) throw new ArgumentException("Product not found");

            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();
        }
         public async Task<IEnumerable<ProductGetDto>> BulkCreateAsync(IEnumerable<ProductCreateOrUpdateDto> ProductDtos)
        {
            var Products = _mapper.Map<IEnumerable<Product>>(ProductDtos);
            _context.Products.AddRange(Products);
            await _context.SaveChangesAsync();

            return _mapper.Map<IEnumerable<ProductGetDto>>(Products);
        }
    }
}
