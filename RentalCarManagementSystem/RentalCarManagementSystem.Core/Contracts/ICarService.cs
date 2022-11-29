using RentalCarManagementSystem.Core.Models.Car;
using RentalCarManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarServiceModel>> GetAllCarsAsync();

        Task<CarDetailsViewModel> CarDetailsById(int id);

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task CheckOut(int id);

        Task<bool> Exists(int id);

        Task<bool> IsAvailable(int id);
    }
}
