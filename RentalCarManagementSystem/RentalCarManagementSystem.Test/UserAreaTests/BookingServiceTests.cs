using Microsoft.Extensions.DependencyInjection;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Models.Booking;
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
    public class BookingServiceTests
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
                .AddSingleton<IBookingService, BookingService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

        }
        [Test]
        public async Task GetCarById_SucceededGetTheCorrectCar()
        {
            var service = serviceProvider.GetService<IBookingService>();

            var id = 1;
            var car = await service.GetCarById(id);

            Assert.That(car != null);
        }

        [Test]
        public async Task CreateBookings_ThrowsExceptionWhenGetTheWrongCar()
        {
            var service = serviceProvider.GetService<IBookingService>();

            var model = new BookingFormViewModel()
            {
                FullName = "Misho Mishev",
                Address = "Bulgaria, Varna, Levski",
                Gender = "Man",
                PhoneNumber = "088333387",
                Email = "ivan@mail.bg",
                IdCardNumber = "12343567",
                DriverLicenseNumber = "2222444567",
                DateOfIssue = new DateTime(2027, 11, 17),
                DateOfExpired = new DateTime(2026, 11, 17),
                IssuedBy = "MVR Sofia",
                PickUpDateAndTime = new DateTime(2022, 11, 30, 5, 0, 0),
                DropOffDateAndTime = new DateTime(2022, 12, 06, 6, 0, 0),
                Duration = 6,
                PaymentType = "Card",
                InsuranceCode = 1,
                TotalAmount = 292,
                IsActive = true,
                IsPaid = true,
                PickUpLocationId = 1,
                DropOffLocationId = 1,
            };
            int carId = 0;
            string userId = "d3211a8d-efde-4a19-8087-79cde4679276";


            Assert.ThrowsAsync<ArgumentException>(async () => await service.Create(model, carId, userId), "Invalid car ID");
        }

        [Test]
        public async Task CreateBooking_CheckIfTheDateOfIssueIsNotBiggerThanDateOfExpired()
        {
            var service = serviceProvider.GetService<IBookingService>();

            var model = new BookingFormViewModel()
            {
                FullName = "Ivan Ivanov",
                Address = "Bulgaria, Varna, Levski",
                Gender = "Man",
                PhoneNumber = "088333387",
                Email = "ivan@mail.bg",
                IdCardNumber = "12343567",
                DriverLicenseNumber = "2222444567",
                DateOfIssue = new DateTime(2016, 11, 17),
                DateOfExpired = new DateTime(2026, 11, 17),
                IssuedBy = "MVR Sofia",
                PickUpDateAndTime = new DateTime(2022, 11, 30, 5, 0, 0),
                DropOffDateAndTime = new DateTime(2022, 12, 06, 6, 0, 0),
                Duration = 6,
                PaymentType = "Card",
                InsuranceCode = 1,
                TotalAmount = 292,
                IsActive = true,
                IsPaid = true,
                PickUpLocationId = 1,
                DropOffLocationId = 1,
            };

            Assert.That(model.DateOfIssue < model.DateOfExpired);
        }

        [Test]
        public async Task CreateBooking_ThrowsExceptionWhenTheDateOfIssueIsBiggerThanDateOfExpired()
        {
            var service = serviceProvider.GetService<IBookingService>();

            var model = new BookingFormViewModel()
            {
                FullName = "Ivan Ivanov",
                Address = "Bulgaria, Varna, Levski",
                Gender = "Man",
                PhoneNumber = "088333387",
                Email = "ivan@mail.bg",
                IdCardNumber = "12343567",
                DriverLicenseNumber = "2222444567",
                DateOfIssue = new DateTime(2027, 11, 17),
                DateOfExpired = new DateTime(2026, 11, 17),
                IssuedBy = "MVR Sofia",
                PickUpDateAndTime = new DateTime(2022, 11, 30, 5, 0, 0),
                DropOffDateAndTime = new DateTime(2022, 12, 06, 6, 0, 0),
                Duration = 6,
                PaymentType = "Card",
                InsuranceCode = 1,
                TotalAmount = 292,
                IsActive = true,
                IsPaid = true,
                PickUpLocationId = 1,
                DropOffLocationId = 1,
            };
            int carId = 2;
            string userId = "d3211a8d-efde-4a19-8087-79cde4679276";


            Assert.ThrowsAsync<ArgumentException>(async () => await service.Create(model, carId, userId), "The date of issue cannot be greater than the date of expire!");
        }

        [Test]
        public async Task CreateBooking_CheckIfThePickUpDateIsNotBiggerThanDropOffDate()
        {
            var service = serviceProvider.GetService<IBookingService>();

            var model = new BookingFormViewModel()
            {
                FullName = "Ivan Ivanov",
                Address = "Bulgaria, Varna, Levski",
                Gender = "Man",
                PhoneNumber = "088333387",
                Email = "ivan@mail.bg",
                IdCardNumber = "12343567",
                DriverLicenseNumber = "2222444567",
                DateOfIssue = new DateTime(2016, 11, 17),
                DateOfExpired = new DateTime(2026, 11, 17),
                IssuedBy = "MVR Sofia",
                PickUpDateAndTime = new DateTime(2022, 11, 30, 5, 0, 0),
                DropOffDateAndTime = new DateTime(2022, 12, 06, 6, 0, 0),
                Duration = 6,
                PaymentType = "Card",
                InsuranceCode = 1,
                TotalAmount = 292,
                IsActive = true,
                IsPaid = true,
                PickUpLocationId = 1,
                DropOffLocationId = 1,
            };
            int carId = 3;
            string userId = "d3211a8d-efde-4a19-8087-79cde4679276";

            await service.Create(model, carId, userId);
            Assert.That(model.PickUpDateAndTime, Is.LessThan (model.DropOffDateAndTime));
        }

        [Test]
        public async Task CreateBooking_ThrowsExceptionWhenThePickUpDateIsBiggerThanDropOffDate()
        {
            var service = serviceProvider.GetService<IBookingService>();

            var model = new BookingFormViewModel()
            {
                FullName = "Test Test",
                Address = "Bulgaria, Varna, Levski",
                Gender = "Man",
                PhoneNumber = "088333387",
                Email = "ivan@mail.bg",
                IdCardNumber = "12343567",
                DriverLicenseNumber = "2222444567",
                DateOfIssue = new DateTime(2016, 11, 17),
                DateOfExpired = new DateTime(2026, 11, 17),
                IssuedBy = "MVR Sofia",
                PickUpDateAndTime = new DateTime(2022, 12, 30, 5, 0, 0),
                DropOffDateAndTime = new DateTime(2022, 12, 06, 6, 0, 0),
                Duration = 6,
                PaymentType = "Card",
                InsuranceCode = 1,
                TotalAmount = 292,
                IsActive = true,
                IsPaid = true,
                PickUpLocationId = 1,
                DropOffLocationId = 1,
            };
            int carId = 3;
            string userId = "0000";


            Assert.ThrowsAsync<ArgumentException>(async () => await service.Create(model, carId, userId), "The date of issue cannot be greater than the date of expire!");
        }

        [Test]
        public async Task CreateBooking_ThrowsExceptionWhenTheUserIsNull()
        {
            var service = serviceProvider.GetService<IBookingService>();

            var model = new BookingFormViewModel()
            {
                FullName = "Ivan Ivanov",
                Address = "Bulgaria, Varna, Levski",
                Gender = "Man",
                PhoneNumber = "088333387",
                Email = "ivan@mail.bg",
                IdCardNumber = "12343567",
                DriverLicenseNumber = "2222444567",
                DateOfIssue = new DateTime(2016, 11, 17),
                DateOfExpired = new DateTime(2026, 11, 17),
                IssuedBy = "MVR Sofia",
                PickUpDateAndTime = new DateTime(2022, 12, 30, 5, 0, 0),
                DropOffDateAndTime = new DateTime(2022, 12, 06, 6, 0, 0),
                Duration = 6,
                PaymentType = "Card",
                InsuranceCode = 1,
                TotalAmount = 292,
                IsActive = true,
                IsPaid = true,
                PickUpLocationId = 1,
                DropOffLocationId = 1,
            };
            int carId = 3;
            string userId = "Test";

            Assert.ThrowsAsync<ArgumentException>(async () => await service.Create(model, carId, userId), "Invalid user ID");
        }

        [Test]
        public async Task GetAllCustomers_SucceededGetAllCustomers()
        {
            var service = serviceProvider.GetService<IBookingService>();

            var customers = await service.GetAllCustomers();

            var customerList = customers.ToList();

            Assert.That(customerList.Count == 2);
        }

        [Test]
        public async Task GetAllBookings_SucceededGetAllBookings()
        {
            var service = serviceProvider.GetService<IBookingService>();

            var bookings = await service.GetAllBookings();

            var bookingList = bookings.ToList();

            Assert.That(bookingList.Count == 2);
        }

        [Test]
        public async Task CreateBooking_CheckIfTheCustomerIsAddedSuccessfully()
        {
            var service = serviceProvider.GetService<IBookingService>();
            var customers = await service.GetAllCustomers();

            var model = new BookingFormViewModel()
            {
                FullName = "Pesho Petrov",
                Address = "Bulgaria, Varna, Levski",
                Gender = "Man",
                PhoneNumber = "088333387",
                Email = "ivan@mail.bg",
                IdCardNumber = "12343567",
                DriverLicenseNumber = "2222444567",
                DateOfIssue = new DateTime(2016, 11, 17),
                DateOfExpired = new DateTime(2026, 11, 17),
                IssuedBy = "MVR Sofia",
                PickUpDateAndTime = new DateTime(2022, 11, 30, 5, 0, 0),
                DropOffDateAndTime = new DateTime(2022, 12, 06, 6, 0, 0),
                Duration = 6,
                PaymentType = "Card",
                InsuranceCode = 1,
                TotalAmount = 292,
                IsActive = true,
                IsPaid = true,
                PickUpLocationId = 1,
                DropOffLocationId = 1,
            };
            int carId = 3;
            string userId = "d3211a8d-efde-4a19-8087-79cde4679276";
            await service.Create(model, carId, userId);

            var customers1 = await service.GetAllCustomers();

            Assert.That(customers1.Count() > customers.Count());
        }

        [Test]
        public async Task CreateBooking_CheckIfTheBookingIsAddedSuccessfully()
        {
            var service = serviceProvider.GetService<IBookingService>();
            var bookings = await service.GetAllBookings();

            var bookingList = bookings.ToList();
            var model = new BookingFormViewModel()
            {
                FullName = "Ivan Ivanov",
                Address = "Bulgaria, Varna, Levski",
                Gender = "Man",
                PhoneNumber = "088333387",
                Email = "ivan@mail.bg",
                IdCardNumber = "12343567",
                DriverLicenseNumber = "2222444567",
                DateOfIssue = new DateTime(2016, 11, 17),
                DateOfExpired = new DateTime(2026, 11, 17),
                IssuedBy = "MVR Sofia",
                PickUpDateAndTime = new DateTime(2022, 11, 30, 5, 0, 0),
                DropOffDateAndTime = new DateTime(2022, 12, 06, 6, 0, 0),
                Duration = 6,
                PaymentType = "Card",
                InsuranceCode = 1,
                TotalAmount = 292,
                IsActive = true,
                IsPaid = true,
                PickUpLocationId = 1,
                DropOffLocationId = 1,
            };
            int carId = 1;
            string userId = "d3211a8d-efde-4a19-8087-79cde4679276";
            await service.Create(model, carId, userId);

            var bookings1 = await service.GetAllBookings();

            var bookingList1 = bookings1.ToList();
            Assert.That(bookingList1.Count > bookingList.Count);
        }
        [Test]
        public async Task CheckIn_SuccedInCheckIn()
        {
            var service = serviceProvider.GetService<IBookingService>();

            var id = 2;

            await service.CheckIn(id);
            var booking = await service.FindBookingById(id);
            Assert.That(booking.IsPaid == true);
            Assert.That(booking.IsRented == true);
        }

        [Test]
        public async Task CheckOut_SuccedInCheckIn()
        {
            var service = serviceProvider.GetService<IBookingService>();

            var id = 1;
            var carId = 1;
            var booking = await service.FindBookingById(id);
            var car = await service.GetCarById(carId);

            await service.CheckOut(id);

            Assert.That(booking.IsActive == false);
            Assert.That(car.IsAvailable == true);
        }

        [Test]
        public async Task GetAllBookings_SucceededShowTheCorrectBookigs()
        {
            var service = serviceProvider.GetService<IBookingService>();

            var bookings = await service.GetAllBookingsAsync();

            var bookingList = bookings.ToList();

            Assert.That(bookingList.Count == 2);
        }

        [Test]
        public async Task GetAllCheckIns_SucceededShowTheCorrectBookigs()
        {
            var service = serviceProvider.GetService<IBookingService>();

            var bookings = await service.AllCheckIns();

            Assert.That(bookings.Count() == 1);
        }

        [Test]
        public async Task GetAllCheckOuts_SucceededShowTheCorrectBookigs()
        {
            var service = serviceProvider.GetService<IBookingService>();

            var bookings = await service.AllCheckOuts();

            Assert.That(bookings.Count() == 1);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();

        }
    }
}
