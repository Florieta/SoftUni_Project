using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Contracts.Admin
{
    public interface ICategoryServiceAdmin
    {
        Task CreateCategory(CreateCategoryInputModel model);

        Task<bool> CategoryExistsByName(string categoryName);

        Task<IEnumerable<CategoryViewModel>> GetAllAsync();

        Task Edit(int id, CategoryViewModel model);
        Task RemoveCategoryAsync(int id);

        Task<bool> IsExisted(int id);

        Task<Category> FindCategoryAsync(int id);
    }
}
