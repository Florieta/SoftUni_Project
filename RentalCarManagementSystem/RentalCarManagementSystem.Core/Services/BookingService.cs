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
                InsuranceCode = model.InsuranceCode,
                TotalAmount = model.TotalAmount,
                PaymentType = model.PaymentType,
                ApplicationUserId = userId,
                IsActive = true,
                IsPaid = false
            };


            await repo.AddAsync<Booking>(booking);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllBookingsViewModel>> GetAllBookingsAsync()
        {
            var all = await repo.All<Booking>().Where(x => x.IsActive == true && x.IsRented == true)
                .Include(c => c.Customer)
                .ToListAsync();

            return all
                .Select(m => new AllBookingsViewModel()
                {
                    Id = m.Id,
                    CarId = m.CarId,
                    FullName = m.Customer.FullName,
                    PickUpDateAndTime = m.PickUpDateAndTime,
                    DropOffDateAndTime = m.DropOffDateAndTime,
                    TotalAmount = m.TotalAmount,
                    IsRented = m.IsRented
                }).OrderBy(t => t.PickUpDateAndTime);
        }

        public async Task<IEnumerable<AllBookingsViewModel>> GetAllCheckInsAsync()
        {
            var all = await repo.All<Booking>().Where(x => x.IsActive == true && x.IsRented == false)
                .Include(c => c.Customer)
                .ToListAsync();

            return all
                .Select(m => new AllBookingsViewModel()
                {
                    Id = m.Id,
                    CarId = m.CarId,
                    FullName = m.Customer.FullName,
                    PickUpDateAndTime = m.PickUpDateAndTime,
                    DropOffDateAndTime = m.DropOffDateAndTime,
                    TotalAmount = m.TotalAmount,
                    IsRented = m.IsRented
                }).OrderBy(t => t.PickUpDateAndTime);
        }

        public async Task<IEnumerable<AllBookingsViewModel>> GetAllCheckOutsAsync()
        {
            var all = await repo.All<Booking>().Where(x => x.IsActive == true && x.IsRented == true)
                .Include(c => c.Customer)
                .ToListAsync();

            return all
                .Select(m => new AllBookingsViewModel()
                {
                    Id = m.Id,
                    CarId = m.CarId,
                    FullName = m.Customer.FullName,
                    PickUpDateAndTime = m.PickUpDateAndTime,
                    DropOffDateAndTime = m.DropOffDateAndTime,
                    TotalAmount = m.TotalAmount,
                    IsRented = m.IsRented
                }).OrderBy(t => t.DropOffDateAndTime);
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

        //public async Task<BookingsQueryModel> All(DateTime searchTerm, int currentPage = 1, int bookingsPerPage = 1)
        //{
        //    var result = new BookingsQueryModel();
        //    var bookings = repo.AllReadonly<Booking>()
        //        .Where(b => b.IsActive && b.IsPaid == false && b.IsRented == false);

        //        bookings = bookings
        //            .Where(b => EF.Functions.Like(b.PickUpDateAndTime.ToString(), searchTerm.ToString()));

        //    result.Bookings = await bookings
        //        .Skip((currentPage - 1) * bookingsPerPage)
        //        .Take(bookingsPerPage)
        //        .Select(b => new BookingServiceModel()
        //        {
        //            Id = b.Id,
        //            PickUpDateAndTime = b.PickUpDateAndTime,
        //            DropOffDateAndTime = b.DropOffDateAndTime,
        //            Duration = b.Duration,
        //            PaymentType = b.PaymentType,
        //            TotalAmount = b.TotalAmount,
        //            FullName = b.Customer.FullName,
        //            Address = b.Customer.Address,
        //            PhoneNumber = b.Customer.PhoneNumber,
        //            Email = b.Customer.Email,
        //            IdCardNumber = b.Customer.IdCardNumber,
        //            DriverLicenseNumber = b.Customer.DriverLicenseNumber,
        //            DateOfIssue = b.Customer.DateOfIssue,
        //            DateOfExpired = b.Customer.DateOfExpired,
        //            IssuedBy = b.Customer.IssuedBy,
        //            Gender = b.Customer.Gender,
        //            PickUpLocationName = b.PickUpLocation.LocationName,
        //            DropOffLocationName = b.DropOffLocation.LocationName,
        //            Model = b.Car.Model,
        //            Make = b.Car.Make,
        //            RegNumber = b.Car.RegNumber
        //        })
        //        .ToListAsync();

        //    result.TotalBookingsCount = await bookings.CountAsync();

        //    return result;
        //}

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
    }
}
