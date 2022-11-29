using Microsoft.EntityFrameworkCore;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Models.Schedule;
using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepository repo;

        public ScheduleService(IRepository repo)
        {
            this.repo = repo;

        }
        public async Task<ScheduleServiceModel> TotalAvailableCarsAsync()
        {
            var totalCars = await repo.All<Car>().CountAsync();
            var totalAvailableCars = await repo.All<Car>().CountAsync(c => c.IsAvailable == true);
            var allRentedCars = await repo.All<Car>().CountAsync(c => c.IsAvailable == false);
            var checkInsTodayCount = await repo.All<Booking>().Where(c => c.IsPaid == false && c.IsActive == true 
            && c.IsRented == false && c.PickUpDateAndTime == DateTime.Today).CountAsync();
            var checkOutTodayCounts = await repo.All<Booking>().Where(c => c.IsActive == true
            && c.IsRented == true && c.DropOffDateAndTime == DateTime.Today).CountAsync();

            return new ScheduleServiceModel()
            {
                TotalCars = totalCars,
                TotalAvailableCars = totalAvailableCars,
                TotalRentedCars = allRentedCars,
                CheckInsTodayCount = checkInsTodayCount ,
                CheckOutsTodayCount = checkInsTodayCount
            };
        }

       
       
    }
}
