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

            await SeedAsync(repo);
        }

        [Test]
        public async Task CreateCar_SucceededCheckThatTheCarDoesNotExist()
        {
            var service = serviceProvider.GetService<ICarServiceAdmin>();

            var model = new CreateCarInputModel()
            {
                RegNumber = "B1882AB",
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

            Assert.That(result, Is.True);
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

            var result = await service.IsCarExists(model);

            Assert.That(result, Is.False);
            Assert.Throws<ArgumentException>(() => service.IsCarExists(model), "The car has already existed!");
        }

        [Test]
        public async Task CreateCar_ThrowsExceptionWhenWeCannotAddACar()
        {
            var service = serviceProvider.GetService<ICarServiceAdmin>();

            var model = new CreateCarInputModel()
            {
                Make = "Toyota",
                Model = "Corolla",
                MakeYear = 2022,
                Color = "Black",
                Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment, sedan.",
                ImageUrl = "https://images.dealer.com/autodata/us/640/color/2022/USD20TOC041A0/209.jpg?_returnflight_id=091119126",
                GearBox = "Manual",
                DailyRate = 40,
                IsAvailable = true,
            };

            var result = await service.CreateCar(model);
            Assert.That(result, Is.False);
            Assert.Throws<InvalidOperationException>(() => service.CreateCar(model), "Something went wrong!");
        }


        [Test]
        public async Task CreateCar_SucceedInCreatingTheCar()
        {
            var service = serviceProvider.GetService<ICarServiceAdmin>();

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

            var result = await service.CreateCar(model);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task RemoveCar_SucceedInRemovingTheCar()
        {
            var service = serviceProvider.GetService<ICarServiceAdmin>();

            int id = 1;
            var car = await service.FindCarAsync(id);
            await service.RemoveCarAsync(id);

            Assert.That(car.NotInUse, Is.False);
        }

        [Test]
        public async Task RemoveCar_ThrowsExceptionWhenNoCarIsFound()
        {
            var service = serviceProvider.GetService<ICarServiceAdmin>();

            int id = 5;
            var car = await service.FindCarAsync(id);
            await service.RemoveCarAsync(id);

            Assert.Throws<ArgumentException>(() => service.FindCarAsync(id), "The car does not exist!");
        }

        [Test]
        public async Task EditCar_SucceedInGettingTheRightCar()
        {
            var service = serviceProvider.GetService<ICarServiceAdmin>();

            int id = 1;
            var car = await service.FindCarAsync(id);
            await service.RemoveCarAsync(id);

            Assert.That(car.NotInUse, Is.False);
        }

        [Test]
        public async Task EditCar_SucceedInEditingTheCar()
        {
            var service = serviceProvider.GetService<ICarServiceAdmin>();

            int id = 1;
            var model = new EditCarViewModel()
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
                CategoryId = 3,
            };

            var result = await service.Edit(id, model);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task EditCar_ThrowsExceptionWhenCannotEdit()
        {
            var service = serviceProvider.GetService<ICarServiceAdmin>();

            int id = 3;
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

            var result = await service.Edit(id, model);

            Assert.That(result, Is.False);

            Assert.Throws<InvalidOperationException>(() => service.Edit(id, model), "Something went wrong!");
        }
        private async Task SeedAsync(IRepository repo)
        {
            var car = new Car()
            {
                Id = 1,
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

            var car1 = new Car()
            {
                Id = 2,
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
                CategoryId = 1,
            };

            var car3 = new Car()
            {
                Id = 3,
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
                CategoryId = 2,
            };



            var user = new ApplicationUser()
            {
                Id = "d3211a8d-efde-4a19-8087-79cde4679276",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "1234567890",
                FirstName = "Peter",
                LastName = "Parker"
            };


            var category = new Category()
            {
                CategoryName = "Compact"
            };



            await repo.AddAsync(car);
            await repo.AddAsync(car1);
            await repo.AddAsync(car3);
            await repo.AddAsync(user);
            await repo.AddAsync(category);
            await repo.SaveChangesAsync();
        }
    }
}
