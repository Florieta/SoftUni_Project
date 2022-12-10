using Microsoft.Extensions.DependencyInjection;
using RentalCarManagementSystem.Core.Services.Admin;
using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarManagementSystem.Core.Contracts.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCarManagementSystem.Test.UserAreaTests;
using RentalCarManagementSystem.Infrastructure.Models;
using RentalCarManagementSystem.Infrastructure.Models.Identity;
using RentalCarManagementSystem.Core.Models.Admin;

namespace RentalCarManagementSystem.Test.AdminAreaTests
{
    [TestFixture]
    public class CarServiceAdminTests
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IRepository, Repository>()
                .AddSingleton<ICarServiceAdmin, CarServiceAdmin>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

        }

        [Test]
        public async Task CreateCar_SucceededCheckThatTheCarDoesNotExist()
        {
            var service = serviceProvider.GetService<ICarServiceAdmin>();

            var model = new CreateCarInputModel()
            {
                RegNumber = "B1992AB",
                Make = "Toyota",
                Model = "Corolla",
                MakeYear = 2022,
                Color = "Black",
                Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment, sedan.",
                ImageUrl = "https://images.dealer.com/autodata/us/640/color/2022/USD20TOC041A0/209.jpg?_returnflight_id=091119126",
                GearBox = "Manual",
                DailyRate = 40,
                IsAvailable = true,
                CategoryId = 3,
            };

            var result = await service.IsCarExists(model);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task CreateCar_ThrowsExceptionWhenTheCarExists()
        {
            var service = serviceProvider.GetService<ICarServiceAdmin>();

            var model = new CreateCarInputModel()
            {
                RegNumber = "B1234AB",
                Make = "Toyota",
                Model = "Corolla",
                MakeYear = 2022,
                Color = "Black",
                Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment, sedan.",
                ImageUrl = "https://images.dealer.com/autodata/us/640/color/2022/USD20TOC041A0/209.jpg?_returnflight_id=091119126",
                GearBox = "Manual",
                DailyRate = 40,
                IsAvailable = true,
                CategoryId = 3,
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await service.CreateCar(model), "The car has already existed!");
        }

        [Test]
        public async Task CreateCar_SucceedInCreatingTheCar()
        {
            var service = serviceProvider.GetService<ICarServiceAdmin>();
            var cars = await service.GetAllAsync();

            var model = new CreateCarInputModel()
            {
                RegNumber = "B1111AB",
                Make = "Toyota",
                Model = "Corolla",
                MakeYear = 2022,
                Color = "Black",
                Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment, sedan.",
                ImageUrl = "https://images.dealer.com/autodata/us/640/color/2022/USD20TOC041A0/209.jpg?_returnflight_id=091119126",
                GearBox = "Manual",
                DailyRate = 40,
                IsAvailable = true,
                CategoryId = 3,
            };

            await service.CreateCar(model);

            var newCars = await service.GetAllAsync();

            Assert.That(newCars.Count() > cars.Count());
        }

        [Test]
        public async Task RemoveCar_SucceedInRemovingTheCar()
        {
            var service = serviceProvider.GetService<ICarServiceAdmin>();

            int id = 1;
            var car = await service.FindCarAsync(id);
            await service.RemoveCarAsync(id);

            Assert.That(car.NotInUse, Is.True);
        }

        [Test]
        public async Task RemoveCar_ThrowsExceptionWhenNoCarIsFound()
        {
            var service = serviceProvider.GetService<ICarServiceAdmin>();

            int id = 5;

            Assert.ThrowsAsync<ArgumentException>(async () => await service.RemoveCarAsync(id), "The car does not exist!");
        }



        [Test]
        public async Task EditCar_SucceedInEditingTheCar()
        {
            var service = serviceProvider.GetService<ICarServiceAdmin>();

            int id = 1;

            var car = await service.FindCarAsync(id);
            var regNumber = car.RegNumber;

            var model = new EditCarViewModel()
            {
                RegNumber = "B4444AB",
                Make = "Toyota",
                Model = "Corolla",
                MakeYear = 2022,
                Color = "Black",
                Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment, sedan.",
                ImageUrl = "https://images.dealer.com/autodata/us/640/color/2022/USD20TOC041A0/209.jpg?_returnflight_id=091119126",
                GearBox = "Manual",
                DailyRate = 40,
                CategoryId = 3,
            };

            await service.Edit(id, model);
            var car1 = await service.FindCarAsync(id);
            var newRegNumber = car.RegNumber;
            Assert.That(regNumber != newRegNumber);
        }

        [Test]
        public async Task EditCar_ThrowsExceptionWhenCarIsNotFound()
        {
            var service = serviceProvider.GetService<ICarServiceAdmin>();

            int id = 4;
            var model = new EditCarViewModel()
            {
                RegNumber = "B1234AB",
                Make = "Toyota",
                Model = "Corolla",
                MakeYear = 2022222,
                Color = "Black",
                Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment, sedan.",
                ImageUrl = " ",
                GearBox = "Manual",
                DailyRate = 40,
                CategoryId = 3,
            };

           
            Assert.ThrowsAsync<ArgumentException>(async () => await service.Edit(id, model), "The car does not exist!");
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();

        }

    }
}
