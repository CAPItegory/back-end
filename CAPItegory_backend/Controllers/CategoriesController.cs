using Microsoft.AspNetCore.Mvc;
using CAPItegory_backend.Models;
using CAPItegory_backend.Services;
using CAPItegory_backend.Query;

namespace CAPItegory_backend.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CapitegoryContext _context;

        private readonly ICategoryService _service;

        public CategoriesController(CapitegoryContext context, ICategoryService categoryService)
        {
            _context = context;
            _service = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _service.GetAllCategories();
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
            var category = await _service.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, UpdateCategoryQuery query)
        {
            try
            {
                await _service.UpdateCategory(id, query);
            } catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            } catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CreateCategoryQuery query)
        {
            var category_created = await _service.CreateCategory(query);

            return CreatedAtAction("GetCategory", new { id = category_created.Id }, category_created);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            try
            {
                await _service.DeleteCategory(id);
            } catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
