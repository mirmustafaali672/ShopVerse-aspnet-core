using Microsoft.AspNetCore.Mvc;
using ShopVerse.Categories;
namespace ShopVerse.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _CategoryAppService;

        public CategoryController(ICategoryAppService CategoryAppService)
        {
            _CategoryAppService = CategoryAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateOrUpdateDto CategoryDto)
        {
            var createdCategory = await _CategoryAppService.CreateAsync(CategoryDto);
            return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory);
        }
        
        [HttpPost("bulk")]
        public async Task<IActionResult> BulkCreate([FromBody] IEnumerable<CategoryCreateOrUpdateDto> CategoryDtos)
        {
            var createdCategories = await _CategoryAppService.BulkCreateAsync(CategoryDtos);
            return Ok(createdCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var Category = await _CategoryAppService.GetByIdAsync(id);
            if (Category == null) return NotFound();
            return Ok(Category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Categories = await _CategoryAppService.GetAllAsync();
            return Ok(Categories);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CategoryCreateOrUpdateDto CategoryDto)
        {
            try
            {
                await _CategoryAppService.UpdateAsync(id, CategoryDto);
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
                await _CategoryAppService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
