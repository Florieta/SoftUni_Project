using Microsoft.EntityFrameworkCore;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarManagementSystem.Infrastructure.Models;
using RentalCarManagementSystem.Infrastructure.Models.Identity;
using RentalCarManagementSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Services.Admin
{
    public class CarServiceAdmin : ICarServiceAdmin
    {
        private readonly IRepository repo;

        public CarServiceAdmin(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<bool> CreateCar(CreateCarInputModel model)
        {
            var result = false;
            if (await IsCarExists(model))
            {
                throw new ArgumentException("The car has already existed!");
            }

            var car = new Car()
            {
                Make = model.Make,
                Model = model.Model,
                MakeYear = model.MakeYear,
                RegNumber = model.RegNumber,
                Color = model.Color,
                GearBox = model.GearBox,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                DailyRate = model.DailyRate,
                CategoryId = model.CategoryId,
                IsAvailable = true
            };
            try
            {
                
                await repo.AddAsync(car);
                await repo.SaveChangesAsync();
                result = true;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Something went wrong!");
            }
            return result;
        }

        
        public async Task<bool> IsCarExists(CreateCarInputModel model)
        {
            return await repo.All<Car>()
                .AnyAsync(x => x.RegNumber == model.RegNumber);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await repo.All<Category>()
                .ToListAsync();
        }

        public async Task RemoveCarAsync(int id)
        {
            var car = await FindCarAsync(id);
            if(car == null)
            {
                throw new ArgumentException("The car does not exist!");
            }
            car.NotInUse = true;

            await repo.SaveChangesAsync();

        }

        public async Task<bool> Edit(int id, EditCarViewModel model)
        {
            var result = false;
            var car = await FindCarAsync(id);
            if (car == null)
            {
                throw new ArgumentException("The car does not exist!");
            }

            try
            {
                car.Make = model.Make;
                car.Model = model.Model;
                car.MakeYear = model.MakeYear;
                car.RegNumber = model.RegNumber;
                car.Color = model.Color;
                car.GearBox = model.GearBox;
                car.ImageUrl = model.ImageUrl;
                car.Description = model.Description;
                car.DailyRate = model.DailyRate;
                car.CategoryId = model.CategoryId;

                await repo.SaveChangesAsync();
                result = true;
            }
            catch (Exception)
            {

                throw new InvalidOperationException("Something went wrong!");
            }
            return result;
        }

        public async Task<Car> FindCarAsync(int id)
        {
            return await repo.GetByIdAsync<Car>(id);
        }

        public async Task<int> GetCarCategoryIdAsync(int id)
        {
            return (await repo.GetByIdAsync<Car>(id)).CategoryId;
        }
        public async Task<bool> CategoryExistsById(int categoryId)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }
       
    }
}
