using Microsoft.EntityFrameworkCore;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Services.Admin
{
    public class CategoryServiceAdmin : ICategoryServiceAdmin
    {
        private readonly IRepository repo;

        public CategoryServiceAdmin(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        {
            var entities = await repo.All<Category>().ToListAsync();

            return entities
            .Select(m => new CategoryViewModel()
            {
                Id = m.Id,
                CategoryName = m.CategoryName,
            });
        }
        public async Task CreateCategory(CreateCategoryInputModel model)
        {

            if (await CategoryExistsByName(model.CategoryName))
            {
                throw new ArgumentException("The category has already existed!");
            }

            var category = new Category()
            {
                CategoryName = model.CategoryName
            };

            await repo.AddAsync(category);
            await repo.SaveChangesAsync();
        }

        public async Task RemoveCategoryAsync(int id)
        {
            var category = await repo.GetByIdAsync<Category>(id);
            category.IsActive = false;

            await repo.SaveChangesAsync();

        }

        public async Task Edit(int id, CategoryViewModel model)
        {
            var category = await repo.GetByIdAsync<Category>(id);

            category.CategoryName = model.CategoryName;

            await repo.SaveChangesAsync();
        }
        public async Task<Category> FindCategoryAsync(int id)
        {
            return await repo.GetByIdAsync<Category>(id);
        }

        public async Task<bool> CategoryExistsByName(string categoryName)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(c => c.CategoryName == categoryName);
        }

        public async Task<bool> IsExisted(int id)
        {
            return await repo.All<Category>()
                .AnyAsync(x => x.Id == id);
        }
    }
}
