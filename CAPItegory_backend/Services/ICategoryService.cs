using CAPItegory_backend.Models;
using CAPItegory_backend.Queries;
using CAPItegory_backend.Query;
using CAPItegory_backend.Rows;

namespace CAPItegory_backend.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryRow>> GetAllCategories();

        public Task<CategoryRow?> GetCategory(Guid id);

        public Task<IEnumerable<CategoryRow>> SearchCategories(SearchCategoryQuery query);

        public Task UpdateCategory(Guid id, UpdateCategoryQuery query);

        public Task<CategoryRow> CreateCategory(CreateCategoryQuery query);

        public Task DeleteCategory(Guid id);
    }
}
