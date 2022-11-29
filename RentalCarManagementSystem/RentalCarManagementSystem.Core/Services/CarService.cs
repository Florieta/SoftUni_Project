using Microsoft.EntityFrameworkCore;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Models.Car;
using RentalCarManagementSystem.Infrastructure.Data;
using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repo;

        public CarService(IRepository repo)
        {
            this.repo = repo;

        }

        public async Task<CarDetailsViewModel> CarDetailsById(int id)
        {
            var car = await this.repo.AllReadonly<Car>().Where(c => c.Id == id)
            .Select(c => new CarDetailsViewModel()
            {
                Id = c.Id,
                Make = c.Make,
                Model = c.Model,
                RegNumber = c.RegNumber,
                MakeYear = c.MakeYear,
                ImageUrl = c.ImageUrl,
                DailyRate = c.DailyRate,
                IsAvailable = c.IsAvailable,
                Color = c.Color,
                Description = c.Description,
                GearBox = c.GearBox,
                CategoryName = c.Category.CategoryName
            }).FirstOrDefaultAsync();

            if (car == null)
            {
                throw new ArgumentException("Invalid car ID");
            }

            return car;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await repo.AllReadonly<Category>().ToListAsync();
        }


        public async Task<IEnumerable<CarServiceModel>> GetAllCarsAsync()
        {
            var allcars = await repo.All<Car>().Where(c => c.NotInUse == false).ToListAsync();

            return allcars
           .Select(m => new CarServiceModel()
           {
               Id = m.Id,
               Make = m.Make,
               Model = m.Model,
               RegNumber = m.RegNumber,
               ImageUrl = m.ImageUrl,
               DailyRate = m.DailyRate,
               IsAvailable = m.IsAvailable
           });
        }

        public async Task CheckOut(int id)
        {
            var car = await repo.GetByIdAsync<Car>(id);
            if (car == null)
            {
                throw new ArgumentException("Invalid car ID");
            }

            car.IsAvailable = true;

            await repo.SaveChangesAsync();
        }

        public async Task<bool> IsAvailable(int id)
        {
            return (await repo.GetByIdAsync<Car>(id)).IsAvailable != false;
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Car>()
                .AnyAsync(c => c.Id == id);
        }

    }
}
