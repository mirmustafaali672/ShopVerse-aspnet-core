using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopVerse.Demos;
using ShopVerse.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopVerse.Demos
{
    public class DemoAppService : IDemoAppService
    {
        private readonly ShopVerseDbContext _context;
        private readonly IMapper _mapper;

        public DemoAppService(ShopVerseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DemoGetDto> CreateAsync(DemoCreateOrUpdateDto demoDto)
        {
            var demo = _mapper.Map<Demo>(demoDto);
            _context.Demos.Add(demo);
            await _context.SaveChangesAsync();
            return _mapper.Map<DemoGetDto>(demo);
        }

        public async Task<DemoGetDto> GetByIdAsync(Guid id)
        {
            var demo = await _context.Demos.FindAsync(id);
            return _mapper.Map<DemoGetDto>(demo);
        }

        public async Task<IEnumerable<DemoGetDto>> GetAllAsync()
        {
            var demos = await _context.Demos.ToListAsync();
            return _mapper.Map<IEnumerable<DemoGetDto>>(demos);
        }

        public async Task UpdateAsync(Guid id, DemoCreateOrUpdateDto demoDto)
        {
            var demo = await _context.Demos.FindAsync(id);
            if (demo == null) throw new ArgumentException("Demo not found");

            _mapper.Map(demoDto, demo);
            _context.Demos.Update(demo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var demo = await _context.Demos.FindAsync(id);
            if (demo == null) throw new ArgumentException("Demo not found");

            _context.Demos.Remove(demo);
            await _context.SaveChangesAsync();
        }

        public bool DemoCall()
        {
            return false;
        }
    }
}
