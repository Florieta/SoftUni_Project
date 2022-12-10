using RentalCarManagementSystem.Core.Models.Booking;
using RentalCarManagementSystem.Core.Models.Car;
using RentalCarManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Contracts
{
    public interface IBookingService
    {
        Task Create(BookingFormViewModel model, int Id, string userId);

        Task<IEnumerable<Location>> GetLocationsAsync();

        Task<IEnumerable<Insurance>> GetInsurancesAsync();

        Task<IEnumerable<AllBookingsViewModel>> GetAllBookingsAsync(string? searchTerm = null);

        Task CheckIn(int id);
        Task CheckOut(int id);

        Task<bool> Exists(int id);

        Task<BookingDetailsViewModel> BookingDetailsById(int id);

        Task<Booking> FindBookingById(int id);

        Task Edit(int id, EditBookingViewModel model);

        Task<Customer> FindCustomerById(int id);

        Task<Car> GetCarById(int id);

        Task<IEnumerable<AllBookingsViewModel>> AllCheckIns(string? searchTerm = null);

        Task<IEnumerable<AllBookingsViewModel>> AllCheckOuts(string? searchTerm = null);

        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<IEnumerable<Booking>> GetAllBookings();
    }
}
