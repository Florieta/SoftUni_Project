using Microsoft.EntityFrameworkCore;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Services.Admin
{
    public class LocationServiceAdmin : ILocationServiceAdmin
    {
        private readonly IRepository repo;

        public LocationServiceAdmin(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<LocationViewModel>> GetAllAsync()
        {
            var entities = await repo.All<Location>().ToListAsync();

            return entities
            .Select(m => new LocationViewModel()
            {
               Id = m.Id,
               LocationName = m.LocationName,
               Address = m.Address
            });
        }

        public async Task CreateLocation(CreateLocationViewModel model)
        {
            if (await IsLocationExists(model))
            {
                throw new ArgumentException("The location has already existed!");
            }

            var location = new Location()
            {
                LocationName = model.LocationName,
                Address = model.Address
            };

            await repo.AddAsync(location);
            await repo.SaveChangesAsync();
        }

        public async Task RemoveLocationAsync(int id)
        {
            var location = await repo.GetByIdAsync<Location>(id);
            location.IsActive = false;

            await repo.SaveChangesAsync();

        }

        public async Task Edit(int id, LocationViewModel model)
        {
            var location = await repo.GetByIdAsync<Location>(id);

            location.Address = model.Address;
            location.LocationName = model.LocationName;

            await repo.SaveChangesAsync();
        }


        public async Task<bool> IsLocationExists(CreateLocationViewModel model)
        {
            return await repo.All<Location>()
                .AnyAsync(x => x.LocationName == model.LocationName);
        }

        public async Task<bool> IsExisted(int id)
        {
            return await repo.All<Location>()
                .AnyAsync(x => x.Id == id);
        }

        public async Task<Location> FindLocationAsync(int id)
        {
            return await repo.GetByIdAsync<Location>(id);
        }
    }
}
