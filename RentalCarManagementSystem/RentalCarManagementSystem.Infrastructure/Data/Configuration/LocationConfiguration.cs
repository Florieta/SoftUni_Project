using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCarManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Infrastructure.Data.Configuration
{
    internal class LocationConfiguration : IEntityTypeConfiguration<Location>
    {

        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(CreateLocations());
            
        }
        private List<Location> CreateLocations()
        {
            var locations = new List<Location>()
            {
                new Location()
                 {
                      Id = 1,
                      LocationName = "Varna Center",
                      Address = "Bulgaria, Varna, 9000"
                 },

                new Location()
                {
                    Id = 2,
                    LocationName = "Varna Airport",
                    Address = "Bulgaria, Varna, 9000"
                },

                new Location()
                {
                    Id = 3,
                    LocationName = "Sofia Airport",
                    Address = "Bulgaria, Sofia, 1000"

                }
            };

            return locations;
        }
    }
}
