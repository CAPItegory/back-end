﻿using CAPItegory_backend.Models;
using CAPItegory_backend.Query;
using Microsoft.AspNetCore.Mvc;

namespace CAPItegory_backend.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllCategories();

        public Task<Category?> GetCategory(Guid id);

        public Task UpdateCategory(Guid id, UpdateCategoryQuery query);

        public Task<Category> CreateCategory(CreateCategoryQuery query);

        public Task DeleteCategory(Guid id);
    }
}
