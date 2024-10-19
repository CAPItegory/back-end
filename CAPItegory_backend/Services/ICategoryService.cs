using CAPItegory_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace CAPItegory_backend.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllCategories();

        public Task<Category?> GetCategory(Guid id);

        public Task UpdateCategory(Guid id, Category category);

        public Task<Category> CreateCategory(Category category);

        public Task DeleteCategory(Guid id);
    }
}
