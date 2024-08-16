using Microsoft.AspNetCore.Mvc;
using ShopVerse.Products;
namespace ShopVerse.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _ProductAppService;

        public ProductController(IProductAppService ProductAppService)
        {
            _ProductAppService = ProductAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateOrUpdateDto ProductDto)
        {
            var createdProduct = await _ProductAppService.CreateAsync(ProductDto);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }
        
        [HttpPost("bulk")]
        public async Task<IActionResult> BulkCreate([FromBody] IEnumerable<ProductCreateOrUpdateDto> ProductDtos)
        {
            var createdProducts = await _ProductAppService.BulkCreateAsync(ProductDtos);
            return Ok(createdProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var Product = await _ProductAppService.GetByIdAsync(id);
            if (Product == null) return NotFound();
            return Ok(Product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Products = await _ProductAppService.GetAllAsync();
            return Ok(Products);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductCreateOrUpdateDto ProductDto)
        {
            try
            {
                await _ProductAppService.UpdateAsync(id, ProductDto);
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
                await _ProductAppService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
