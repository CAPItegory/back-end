using CAPItegory_backend.Models;
using CAPItegory_backend.Queries;
using CAPItegory_backend.Query;
using CAPItegory_backend.Rows;
using Microsoft.AspNetCore.Mvc;

namespace CAPItegory_backend.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllCategories();

        public Task<Category?> GetCategory(Guid id);

        public Task<IEnumerable<CategorySearchRow>> SearchCategories(SearchCategoryQuery query);

        public Task UpdateCategory(Guid id, UpdateCategoryQuery query);

        public Task<Category> CreateCategory(CreateCategoryQuery query);

        public Task DeleteCategory(Guid id);
    }
}
