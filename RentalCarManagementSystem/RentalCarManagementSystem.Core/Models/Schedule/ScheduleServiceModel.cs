using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Schedule
{
    public class ScheduleServiceModel
    {
        public int TotalCars { get; set; }

        public int TotalAvailableCars { get; set; }

        public int TotalRentedCars { get; set; }

        public int CheckInsTodayCount { get; set; }

        public int CheckOutsTodayCount { get; set; }
    }
}
