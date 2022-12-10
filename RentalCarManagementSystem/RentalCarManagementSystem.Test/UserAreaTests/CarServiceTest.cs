using Microsoft.Extensions.DependencyInjection;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Models.Car;
using RentalCarManagementSystem.Core.Services;
using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarManagementSystem.Infrastructure.Models;
using RentalCarManagementSystem.Infrastructure.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Test.UserAreaTests
{
    [TestFixture]
    public class CarServiceTest
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
                .AddSingleton<ICarService, CarService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            await SeedAsync(repo);
        }

        [Test]
        public async Task GetAllCars_SucceededShowAllCars()
        {
            var service = serviceProvider.GetService<ICarService>();

            var cars = await service.GetAllCarsAsync();

            Assert.That(cars.Count(), Is.EqualTo (6));
        }



        [Test]
        public async Task GetAllAsyncShouldReturnCorrectCollectionOfType()
        {
            var service = serviceProvider.GetService<ICarService>();
            IEnumerable<CarServiceModel> carCollection = await service.GetAllCarsAsync();

            Assert.IsInstanceOf<IEnumerable<CarServiceModel>>(carCollection);
        }

        [Test]
        public async Task GetCarById_Succeed()
        {
            var service = serviceProvider.GetService<ICarService>();

            var id = 12;

            var car = await service.Exists(id);

            Assert.IsTrue(car);
        }

        [Test]
        public async Task GetCarByIdWithInvalidId_ReturnFalse()
        {
            var service = serviceProvider.GetService<ICarService>();

            var id = 113;

            var car = await service.Exists(id);

            Assert.That(car == false);
        }

        [Test]
        public async Task GetCarDetailsById_ReturnCorrectCarDetails()
        {
            var service = serviceProvider.GetService<ICarService>();

            var id = 2;
            var car1 = await service.CarDetailsById(id);

            Assert.That(car1 != null);
        }

        [Test]
        public async Task GetCarDetailsByIdWithInvalidId_ThrowsException()
        {
            var service = serviceProvider.GetService<ICarService>();

            var id = 0;

            Assert.ThrowsAsync<ArgumentException>(async () => await service.CarDetailsById(id), "Invalid car ID");
        }


        [Test]
        public async Task GetAllCategories_SucceededShowAllCategories()
        {
            var service = serviceProvider.GetService<ICarService>();

            var categories = await service.GetCategoriesAsync();

            var categoryList = categories.ToList();

            Assert.That(categoryList.Count == 5);
        }

        [Test]
        public async Task IsAvailable_ReturnsTrueIfTheCarIsAvailable()
        {
            var service = serviceProvider.GetService<ICarService>();

            var id = 1;

            var carAvailability = await service.IsAvailable(id);

            Assert.That(carAvailability == true);
        }

        [Test]
        public async Task IsAvailable_ReturnsFalseIfTheCarIsNotAvailable()
        {
            var service = serviceProvider.GetService<ICarService>();

            var id = 14;

            var carAvailability = await service.IsAvailable(id);

            Assert.That(carAvailability == false);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();

        }

        private async Task SeedAsync(IRepository repo)
        {
            var car = new Car()
            {
                Id = 12,
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
                CategoryId = 8,
                NotInUse = false
            };

            var car1 = new Car()
            {
                Id = 13,
                RegNumber = "B1444CB",
                Make = "Hundai",
                Model = "i20",
                MakeYear = 2022,
                Color = "Grey",
                Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, no highest equipment.",
                ImageUrl = "https://s7g10.scene7.com/is/image/hyundaiautoever/BC3_5DR_TopTrim_DG01-01_EXT_front_rgb_v01_w3a-1:4x3?wid=960&hei=720&fmt=png-alpha&fit=wrap,1",
                GearBox = "Manual",
                DailyRate = 33,
                IsAvailable = true,
                CategoryId = 9,
                NotInUse = false
            };

            var car3 = new Car()
            {
                Id = 14,
                RegNumber = "B1223AB",
                Make = "Citroen",
                Model = "C4",
                MakeYear = 2022,
                Color = "White",
                Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment.",
                ImageUrl = "https://www.citroen-eg.com/wp-content/uploads/2021/11/Polar-White-front1.jpg",
                GearBox = "Automatic",
                DailyRate = 37,
                IsAvailable = false,
                CategoryId = 8,
                NotInUse = false
            };
            
            var category = new Category()
            {
                Id = 8,
                CategoryName = "Compact",
                IsActive = true
            };

            var category1 = new Category()
            {
                Id = 9,
                CategoryName = "Economy",
                IsActive = true

            };

            await repo.AddAsync(car);
            await repo.AddAsync(car1);
            await repo.AddAsync(car3);
            await repo.AddAsync(category1);
            await repo.AddAsync(category);
            await repo.SaveChangesAsync();
        }
    }
}
