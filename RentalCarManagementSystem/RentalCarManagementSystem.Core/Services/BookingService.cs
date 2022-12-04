using Microsoft.EntityFrameworkCore;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Models.Booking;
using RentalCarManagementSystem.Core.Models.Car;
using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarManagementSystem.Infrastructure.Models;
using RentalCarManagementSystem.Infrastructure.Models.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository repo;

        public BookingService(IRepository repo)
        {
            this.repo = repo;

        }
        

        public async Task Create(BookingFormViewModel model, int Id, string userId)
        {
            var user = await repo.All<ApplicationUser>()
                .Where(u => u.Id == userId)
                .Include(b => b.Bookings)
                .ThenInclude(c => c.Customer)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var car = await repo.GetByIdAsync<Car>(Id);

            if (car == null)
            {
                throw new ArgumentException("Invalid car ID");
            }

            car.IsAvailable = false;


            var customer = new Customer()
            {
                FullName = model.FullName,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                IdCardNumber = model.IdCardNumber,
                DriverLicenseNumber = model.DriverLicenseNumber,
                DateOfIssue = model.DateOfIssue,
                DateOfExpired = model.DateOfExpired,
                IssuedBy = model.IssuedBy,
                Gender = model.Gender
            };

            await repo.AddAsync<Customer>(customer);

            var booking = new Booking()
            {
                CarId = Id,
                Car = car,
                Customer = customer,
                CustomerId = customer.Id,
                PickUpDateAndTime = model.PickUpDateAndTime,
                DropOffDateAndTime = model.DropOffDateAndTime,
                Duration = model.Duration,
                PickUpLocationId = model.PickUpLocationId,
                DropOffLocationId = model.DropOffLocationId,
                InsuranceCode = model.InsuranceCode == 0 ? 0 : model.InsuranceCode,
                TotalAmount = model.TotalAmount,
                PaymentType = model.PaymentType,
                ApplicationUserId = userId,
                IsActive = true,
                IsPaid = false
            };


            await repo.AddAsync<Booking>(booking);
            await repo.SaveChangesAsync();
        }

        public async Task CheckIn(int id)
        {
            var booking = await repo.GetByIdAsync<Booking>(id);
            booking.IsPaid = true;
            booking.IsRented = true;

            await repo.SaveChangesAsync();
        }
        public async Task CheckOut(int id)
        {
            var booking = await repo.GetByIdAsync<Booking>(id);
            var car = await repo.GetByIdAsync<Car>(booking.CarId);
            car.IsAvailable = true;
            booking.IsActive = false;

            await repo.SaveChangesAsync();
        }

        public async Task<BookingDetailsViewModel> BookingDetailsById(int id)
        {
            return await repo.AllReadonly<Booking>()
                .Where(b => b.IsActive)
                .Where(b => b.Id == id)
                .Select(b => new BookingDetailsViewModel()
                {
                    PickUpDateAndTime = b.PickUpDateAndTime,
                    DropOffDateAndTime = b.DropOffDateAndTime,
                    Duration = b.Duration,
                    PaymentType = b.PaymentType,
                    TotalAmount = b.TotalAmount,
                    FullName = b.Customer.FullName,
                    Address = b.Customer.Address,
                    PhoneNumber = b.Customer.PhoneNumber,
                    Email = b.Customer.Email,
                    IdCardNumber = b.Customer.IdCardNumber,
                    DriverLicenseNumber = b.Customer.DriverLicenseNumber,
                    DateOfIssue = b.Customer.DateOfIssue,
                    DateOfExpired = b.Customer.DateOfExpired,
                    IssuedBy = b.Customer.IssuedBy,
                    Gender = b.Customer.Gender,
                    PickUpLocationName = b.PickUpLocation.LocationName,
                    DropOffLocationName = b.DropOffLocation.LocationName,
                    Model = b.Car.Model,
                    Make = b.Car.Make,
                    RegNumber = b.Car.RegNumber

                })
                .FirstAsync();
        }

        public async Task Edit(int id, EditBookingViewModel model)
        {
            var booking = await repo.GetByIdAsync<Booking>(id);

            booking.Id = id;
            booking.CustomerId = model.CustomerId;
            booking.Customer.FullName = model.FullName;
            booking.Customer.Address = model.Address;
            booking.Customer.PhoneNumber = model.PhoneNumber;
            booking.Customer.Email = model.Email;
            booking.Customer.IdCardNumber = model.IdCardNumber;
            booking.Customer.DriverLicenseNumber = model.DriverLicenseNumber;
            booking.Customer.Gender = model.Gender;
            booking.PickUpDateAndTime = model.PickUpDateAndTime;
            booking.DropOffDateAndTime = model.DropOffDateAndTime;
            booking.Duration = model.Duration;
            booking.PickUpLocationId = model.PickUpLocationId;
            booking.DropOffLocationId = model.DropOffLocationId;
            booking.InsuranceCode = model.InsuranceCode;
            booking.TotalAmount = model.TotalAmount;
            booking.PaymentType = model.PaymentType;

            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllBookingsViewModel>> GetAllBookingsAsync(string? searchTerm = null)
        {
            var all = repo.AllReadonly<Booking>().Where(x => x.IsActive == true);

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                var searchTerm1 = DateTime.Parse(searchTerm).Date;
                all = all.Where(b => b.PickUpDateAndTime.Date == searchTerm1);
            }

            return await all
                .Select(m => new AllBookingsViewModel()
                {
                    Id = m.Id,
                    CarId = m.CarId,
                    FullName = m.Customer.FullName,
                    PickUpDateAndTime = m.PickUpDateAndTime,
                    DropOffDateAndTime = m.DropOffDateAndTime,
                    TotalAmount = m.TotalAmount,
                    IsRented = m.IsRented
                }).OrderBy(t => t.PickUpDateAndTime).ToListAsync();
        }

        public async Task<IEnumerable<AllBookingsViewModel>> AllCheckIns(string? searchTerm = null)
        {
            var bookings = repo.AllReadonly<Booking>()
                .Where(b => b.IsActive == true && b.IsPaid == false && b.IsRented == false);


            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                var searchTerm1 = DateTime.Parse(searchTerm).Date;
                bookings = bookings.Where(b => b.PickUpDateAndTime.Date == searchTerm1);
            }

            var result = await bookings
                .Select(b => new AllBookingsViewModel()
                {
                    Id = b.Id,
                    PickUpDateAndTime = b.PickUpDateAndTime,
                    DropOffDateAndTime = b.DropOffDateAndTime,
                    TotalAmount = b.TotalAmount,
                    FullName = b.Customer.FullName,
                })
                .OrderBy(t => t.PickUpDateAndTime)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<AllBookingsViewModel>> AllCheckOuts(string? searchTerm = null)
        {
            var bookings = repo.AllReadonly<Booking>()
                .Where(b => b.IsActive && b.IsPaid == true && b.IsRented == true);


            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                var searchTerm1 = DateTime.Parse(searchTerm).Date;
                bookings = bookings.Where(b => b.DropOffDateAndTime.Date == searchTerm1);
            }

            var result = await bookings
                .Select(b => new AllBookingsViewModel()
                {
                    Id = b.Id,
                    PickUpDateAndTime = b.PickUpDateAndTime,
                    DropOffDateAndTime = b.DropOffDateAndTime,
                    TotalAmount = b.TotalAmount,
                    FullName = b.Customer.FullName,
                })
                .OrderBy(t => t.DropOffDateAndTime)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            return await repo.AllReadonly<Location>()
                .ToListAsync();
        }

        public async Task<IEnumerable<Insurance>> GetInsurancesAsync()
        {
            return await repo.AllReadonly<Insurance>()
                .ToListAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Booking>()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<Booking> FindBookingById(int id)
        {
            return await repo.GetByIdAsync<Booking>(id);
        }

        public async Task<Customer> FindCustomerById(int id)
        {
            return await repo.GetByIdAsync<Customer>(id);
        }

        public async Task<Car> GetCarById(int id)
        {
            return await repo.GetByIdAsync<Car>(id);
        }
    }
}
