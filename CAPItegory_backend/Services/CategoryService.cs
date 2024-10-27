using AutoMapper;
using CAPItegory_backend.Models;
using CAPItegory_backend.Queries;
using CAPItegory_backend.Query;
using CAPItegory_backend.Rows;
using Microsoft.EntityFrameworkCore;

namespace CAPItegory_backend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CapitegoryContext _context;
        private readonly IMapper _mapper;

        public CategoryService(CapitegoryContext context, IMapper mapper) { 
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryRow>> GetAllCategories()
        {
            return _mapper.Map<IEnumerable<CategoryRow>>(await _context.Category.ToListAsync());
        }

        public async Task<CategoryRow?> GetCategory(Guid id)
        {
            var category = (await _context.Category.Include(c => c.Children).AsQueryable().Where(c => c.Id == id).ToListAsync())[0];
            return _mapper.Map<CategoryRow>(category);
        }

        public async Task<IEnumerable<CategoryRow>> SearchCategories(SearchCategoryQuery query)
        {
            var category = _context.Category.Include(c => c.Parent).AsQueryable();

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
            if (query.ParentId != null)
            {
                category = category.Where(c => c.Parent != null && c.Parent.Id == query.ParentId);
            }

            //Order
            if (query.OrderByName ?? false) {
                category = category.OrderBy(c => c.Name);
            }
            if (query.OrderByCreationDate ?? false) {
                category = category.OrderBy(c => c.CreationDate);
            }
            if (query.OrderByNumberOfChild ?? false) {
                category = category.OrderBy(c => c.Children.Count);
            }

            //Page
            var result = await category.Skip(query.PageSize * (query.PageNumber - 1)).Take(query.PageSize).ToListAsync();
            return _mapper.Map<IEnumerable<CategoryRow>>(result);
        }

        public async Task<CategoryRow> CreateCategory(CreateCategoryQuery query)
        {
            var category = new Category
            {
                CreationDate = DateTime.Now,
                Name = query.Name,
                Children = []
            };
            if (query.Parent != null)
            {
                category.Parent = _context.Category.Find(query.Parent) ?? throw new KeyNotFoundException();
                category.Parent.Children.Add(category);
            }
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryRow>(category);
        }

        public async Task DeleteCategory(Guid id)
        {
            var category = await _context.Category.FindAsync(id) ?? throw new KeyNotFoundException();
            if (category.Parent != null) { 
                category.Parent.Children.Remove(category);
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
                parent.Children.Add(category);
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
