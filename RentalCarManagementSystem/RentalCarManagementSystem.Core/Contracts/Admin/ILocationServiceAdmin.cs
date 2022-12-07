using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Contracts.Admin
{
    public interface ILocationServiceAdmin
    {
        Task<IEnumerable<LocationViewModel>> GetAllAsync();

        Task<bool> IsLocationExists(CreateLocationViewModel model);

        Task CreateLocation(CreateLocationViewModel model);

        Task Edit(int id, LocationViewModel model);

        Task<bool> IsExisted(int id);

        Task<Location> FindLocationAsync(int id);

        Task RemoveLocationAsync(int id);
    }
}
