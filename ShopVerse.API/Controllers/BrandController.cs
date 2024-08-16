using Microsoft.AspNetCore.Mvc;
using ShopVerse.Brands;
namespace ShopVerse.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandAppService _BrandAppService;

        public BrandController(IBrandAppService BrandAppService)
        {
            _BrandAppService = BrandAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BrandCreateOrUpdateDto BrandDto)
        {
            var createdBrand = await _BrandAppService.CreateAsync(BrandDto);
            return CreatedAtAction(nameof(GetById), new { id = createdBrand.Id }, createdBrand);
        }
        
        [HttpPost("bulk")]
        public async Task<IActionResult> BulkCreate([FromBody] IEnumerable<BrandCreateOrUpdateDto> brandDtos)
        {
            var createdBrands = await _BrandAppService.BulkCreateAsync(brandDtos);
            return Ok(createdBrands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var Brand = await _BrandAppService.GetByIdAsync(id);
            if (Brand == null) return NotFound();
            return Ok(Brand);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Brands = await _BrandAppService.GetAllAsync();
            return Ok(Brands);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] BrandCreateOrUpdateDto BrandDto)
        {
            try
            {
                await _BrandAppService.UpdateAsync(id, BrandDto);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _BrandAppService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
