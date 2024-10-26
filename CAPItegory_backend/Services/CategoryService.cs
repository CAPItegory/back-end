using CAPItegory_backend.Models;
using CAPItegory_backend.Queries;
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

        public async Task<IEnumerable<Category>> SearchCategories(SearchCategoryQuery query)
        {
            var category = _context.Category.AsQueryable();

            //Filters
            if (query.IsRoot != null) {
                category = category.Where(c => (c.Parent == null) == query.IsRoot);
            }
            if (query.BeforeDate != null) { 
                category = category.Where(c => c.CreationDate <= query.BeforeDate);
            }
            if (query.AfterDate != null) { 
                category = category.Where(c => c.CreationDate >= query.AfterDate);
            }

            //Order
            if (query.OrderByName ?? false) {
                category = category.OrderBy(c => c.Name);
            }
            if (query.OrderByCreationDate ?? false) {
                category = category.OrderBy(c => c.CreationDate);
            }
            if (query.OrderByNumberOfChild ?? false) {
                category = category.OrderBy(c => c.NumberOfChildren);
            }

            //Page
            return await category.Skip(query.PageSize * (query.PageNumber - 1)).Take(query.PageSize).ToListAsync();
        }

        public async Task<Category> CreateCategory(CreateCategoryQuery query)
        {
            var category = new Category();
            category.CreationDate = DateTime.Now;
            category.Name = query.Name;
            category.NumberOfChildren = 0;
            if (query.Parent != null)
            {
                category.Parent = _context.Category.Find(query.Parent) ?? throw new KeyNotFoundException();
                category.Parent.NumberOfChildren += 1;
            }
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task DeleteCategory(Guid id)
        {
            var category = await _context.Category.FindAsync(id) ?? throw new KeyNotFoundException();
            if (category.Parent != null) { 
                category.Parent.NumberOfChildren -= 1;
            }
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
                if (query.Parent == id)
                {
                    throw new ArgumentException("Category can't be his own parent");
                }
                var parent = _context.Category.Find(query.Parent) ?? throw new KeyNotFoundException("Can't find parent");
                parent.NumberOfChildren += 1;
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
