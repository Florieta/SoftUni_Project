using Microsoft.Extensions.DependencyInjection;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Services;
using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Test.UserAreaTests
{
    [TestFixture]
    public class ScheduleServiceTests
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
                .AddSingleton<IScheduleService, ScheduleService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            await SeedAsync(repo);
        }

        [Test]
        public async Task TotalCars_ReturnsCorrectTotalCars()
        {
            var service = serviceProvider.GetService<IScheduleService>();

            var model = await service.TotalAvailableCarsAsync();

            Assert.That(model.TotalCars == 3);
        }

        [Test]
        public async Task TotalAvailableCars_ReturnsCorrectTotalAvailableCars()
        {
            var service = serviceProvider.GetService<IScheduleService>();

            var model = await service.TotalAvailableCarsAsync();

            Assert.That(model.TotalAvailableCars == 2);
        }

        [Test]
        public async Task TotalRentedCars_ReturnsCorrectTotalRentedCars()
        {
            var service = serviceProvider.GetService<IScheduleService>();

            var model = await service.TotalAvailableCarsAsync();

            Assert.That(model.TotalRentedCars == 1);
        }

        [Test]
        public async Task TotalCheckInsTodayCount_ReturnsCorrectTotalCheckIns()
        {
            var service = serviceProvider.GetService<IScheduleService>();

            var model = await service.TotalAvailableCarsAsync();

            Assert.That(model.CheckInsTodayCount == 1);
        }

        [Test]
        public async Task TotalCheckOutsTodaYCount_ReturnsCorrectTotalCheckOuts()
        {
            var service = serviceProvider.GetService<IScheduleService>();

            var model = await service.TotalAvailableCarsAsync();

            Assert.That(model.CheckOutsTodayCount == 1);
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

            var booking = new Booking()
            {
                Id = 1,
                PickUpDateAndTime = new DateTime(2022, 11, 30, 5, 0, 0),
                DropOffDateAndTime = new DateTime(2022, 12, 06, 6, 0, 0),
                Duration = 6,
                PaymentType = "Card",
                InsuranceCode = 1,
                TotalAmount = 292,
                IsActive = true,
                IsPaid = true,
                IsRented = true,
                CarId = 1,
                CustomerId = 1,
                PickUpLocationId = 1,
                DropOffLocationId = 1,
                ApplicationUserId = "d3211a8d-efde-4a19-8087-79cde4679276"
            };
            var booking1 = new Booking()
            {
                Id = 2,
                PickUpDateAndTime = new DateTime(2022, 12, 06, 3, 0, 0),
                DropOffDateAndTime = new DateTime(2022, 12, 09, 5, 0, 0),
                Duration = 3,
                PaymentType = "BankTransfer",
                CarId = 2,
                CustomerId = 2,
                PickUpLocationId = 2,
                DropOffLocationId = 2,
                InsuranceCode = 2,
                TotalAmount = 114,
                IsActive = true,
                IsPaid = false,
                IsRented = false,
                ApplicationUserId = "d3211a8d-efde-4a19-8087-79cde4679276"
            };

            await repo.AddAsync(car);
            await repo.AddAsync(car1);
            await repo.AddAsync(car3);
            await repo.AddAsync(booking);
            await repo.AddAsync(booking1);
            await repo.SaveChangesAsync();
        }
    }
}
