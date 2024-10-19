using CAPItegory_backend.Models;
using CAPItegory_backend.Query;
using Microsoft.EntityFrameworkCore;

namespace CAPItegory_backend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CapitegoryContext _context;

        public CategoryService(CapitegoryContext context) { _context = context; }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category?> GetCategory(Guid id)
        {
            var category = await _context.Category.FindAsync(id);
            return category;
        }

        public async Task<Category> CreateCategory(CreateCategoryQuery query)
        {
            var category = new Category();
            category.CreationDate = DateTime.Now;
            category.Name = query.Name;
            if (query.Parent != null)
            {
                category.Parent = _context.Category.Find(query.Parent) ?? throw new KeyNotFoundException();
            }
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task DeleteCategory(Guid id)
        {
            var category = await _context.Category.FindAsync(id) ?? throw new KeyNotFoundException();
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return;
        }

        public async Task UpdateCategory(Guid id, UpdateCategoryQuery query)
        {
            var category = _context.Category.Find(id) ?? throw new KeyNotFoundException("Can't find category");
            
            _context.Entry(category).State = EntityState.Modified;
            category.Name = query.Name;
            if (query.Parent != null)
            {
                var parent = _context.Category.Find(query.Parent) ?? throw new KeyNotFoundException("Can't find parent");
                category.Parent = parent;
            }
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    throw new KeyNotFoundException();
                }
                else
                {
                    throw;
                }
            }

            return;
        }

        private bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.Id == id);
        }

    }
}
