using AutoMapper;
using CAPItegory_backend.Models;
using CAPItegory_backend.Queries;
using CAPItegory_backend.Query;
using CAPItegory_backend.Rows;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            var parentsList =  (await _context.Category.Include(c => c.Children).AsQueryable().Where(c => c.Children.Any(c => c.Id == id)).ToListAsync());
            if ( !parentsList.IsNullOrEmpty() )
            {
                category.Parent = parentsList[0];
            }
            return _mapper.Map<CategoryRow>(category);
        }

        public async Task<SearchRow> SearchCategories(SearchCategoryQuery query)
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
            var row = new SearchRow
            {
                Categories = _mapper.Map<IEnumerable<CategoryRow>>(result),
                TotalPages = (int)Math.Ceiling((double)category.Count() / (double)query.PageSize),
                PageNumber = query.PageNumber,
                PageSize = query.PageSize,
            };
            return row;
        }

        public async Task<CategoryRow> CreateCategory(CreateCategoryQuery query)
        {
            if (query.Name == null || query.Name.Trim() == "")
            {
                throw new ArgumentException("Name can't be empty");
            }
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
            var category = await _context.Category.Include(c => c.Children).FirstOrDefaultAsync(c => c.Id == id) ?? throw new KeyNotFoundException();
            category.Parent?.Children.Remove(category);
            await DeleteCategory(category);
            await _context.SaveChangesAsync();

            return;
        }

        public async Task UpdateCategory(Guid id, UpdateCategoryQuery query)
        {
            var category = await _context.Category.Include(c => c.Parent).FirstOrDefaultAsync(c => c.Id == id) ?? throw new KeyNotFoundException("Can't find category");
            
            _context.Entry(category).State = EntityState.Modified;
            if (query.Name != null && query.Name.Trim() != "")
            {
                category.Name = query.Name;
            }
            if (query.Parent != Guid.Empty)
            {
                if (query.Parent == id)
                {
                    throw new ArgumentException("Category can't be his own parent");
                }
                Category? parent = null;
                if (query.Parent != null)
                {
                    parent = await _context.Category.Include(c => c.Parent).FirstOrDefaultAsync(c => c.Id == query.Parent) ?? throw new KeyNotFoundException("Can't find parent");
                    if (IsChildOf(parent, category))
                    {
                        throw new ArgumentException("Category can't be child of his own child");
                    }
                    parent.Children.Add(category);
                }
                category.Parent?.Children.Remove(category);
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

        private async Task DeleteCategory(Category category)
        {
            var children = await _context.Category.Include(c => c.Children).Where(c => c.ParentId == category.Id).ToListAsync();
            foreach (var child in children)
            {
                await DeleteCategory(child);
            }
            _context.Category.Remove(category);
        }

        private bool IsChildOf(Category category, Category parent)
        {
            if (category.Parent == null)
            {
                return false;
            }
            if (category.Parent.Id == parent.Id)
            {
                return true;
            }
            var categoryParent = _context.Category.Include(c => c.Parent).FirstOrDefault(c => c.Id == category.Parent.Id) ?? category.Parent;
            return IsChildOf(categoryParent, parent);
        }
    }
}
