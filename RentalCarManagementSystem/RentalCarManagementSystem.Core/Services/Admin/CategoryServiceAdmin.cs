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

        public async Task<bool> CategoryExistsByName(string categoryName)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(c => c.CategoryName == categoryName);
        }

    }
}
