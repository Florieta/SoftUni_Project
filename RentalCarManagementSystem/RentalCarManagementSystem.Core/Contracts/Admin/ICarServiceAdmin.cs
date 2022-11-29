using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Contracts.Admin
{
    public interface ICarServiceAdmin
    {
        Task CreateCar(CreateCarInputModel model);

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task RemoveCarAsync(int id);

        Task Edit(int id, EditCarViewModel model);

        Task<Car> FindCarAsync(int id);

        Task<int> GetCarCategoryIdAsync(int id);

        Task<bool> CategoryExists(int categoryId);
    }
}
