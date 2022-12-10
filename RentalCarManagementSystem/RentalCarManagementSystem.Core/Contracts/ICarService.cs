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
        Task<IEnumerable<CarServiceModel>> GetAllCarsAsync(string? searchMake = null, string? searchModel = null,
           string? searchRegNumber = null);

        Task<CarDetailsViewModel> CarDetailsById(int id);

        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<bool> Exists(int id);

        Task<bool> IsAvailable(int id);
    }
}
