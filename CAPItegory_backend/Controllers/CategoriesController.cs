using Microsoft.AspNetCore.Mvc;
using CAPItegory_backend.Models;
using CAPItegory_backend.Services;
using CAPItegory_backend.Query;
using CAPItegory_backend.Queries;
using CAPItegory_backend.Rows;

namespace CAPItegory_backend.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService categoryService)
        {
            _service = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryRow>>> GetCategories()
        {
            var categories = await _service.GetAllCategories();
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryRow>> GetCategory(Guid id)
        {
            var category = await _service.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpGet("search")]
        public async Task<ActionResult<SearchRow>> SearchCategory([FromQuery] SearchCategoryQuery query)
        {
            var categories = await _service.SearchCategories(query);
            return Ok(categories);
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
        public async Task<ActionResult<CategoryRow>> CreateCategory(CreateCategoryQuery query)
        {
            CategoryRow category_created;
            try
            {
                category_created = await _service.CreateCategory(query);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

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
