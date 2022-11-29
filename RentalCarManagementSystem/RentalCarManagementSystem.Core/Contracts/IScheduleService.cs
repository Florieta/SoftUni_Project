using RentalCarManagementSystem.Core.Models.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Contracts
{
    public interface IScheduleService
    {
        Task<ScheduleServiceModel> TotalAvailableCarsAsync();

    }
}
