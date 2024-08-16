using Microsoft.AspNetCore.Mvc;
using ShopVerse.Demos;
namespace ShopVerse.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly IDemoAppService _demoAppService;

        public DemoController(IDemoAppService demoAppService)
        {
            _demoAppService = demoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DemoCreateOrUpdateDto demoDto)
        {
            var createdDemo = await _demoAppService.CreateAsync(demoDto);
            return CreatedAtAction(nameof(GetById), new { id = createdDemo.Id }, createdDemo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var demo = await _demoAppService.GetByIdAsync(id);
            if (demo == null) return NotFound();
            return Ok(demo);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var demos = await _demoAppService.GetAllAsync();
            return Ok(demos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] DemoCreateOrUpdateDto demoDto)
        {
            try
            {
                await _demoAppService.UpdateAsync(id, demoDto);
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
                await _demoAppService.DeleteAsync(id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpGet("DemoCall")]
        public bool DemoCall()
        {
            return _demoAppService.DemoCall();
        }
    }
}
