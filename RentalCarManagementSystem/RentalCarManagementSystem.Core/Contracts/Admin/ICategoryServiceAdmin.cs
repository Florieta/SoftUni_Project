using RentalCarManagementSystem.Core.Models.Admin;
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

    }
}
