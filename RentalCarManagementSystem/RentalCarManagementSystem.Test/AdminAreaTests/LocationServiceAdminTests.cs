using Microsoft.Extensions.DependencyInjection;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Core.Services.Admin;
using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarManagementSystem.Infrastructure.Models;
using RentalCarManagementSystem.Infrastructure.Models.Identity;
using RentalCarManagementSystem.Test.UserAreaTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Test.AdminAreaTests
{
    [TestFixture]
    public class LocationServiceAdminTests
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
                .AddSingleton<ILocationServiceAdmin, LocationServiceAdmin>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

        }
        [Test]
        public async Task GetAllLocations_SucceededShowAllLocations()
        {
            var service = serviceProvider.GetService<ILocationServiceAdmin>();

            var locations = await service.GetAllAsync();

            Assert.That(locations.Count() == 3);
        }

        [Test]
        public async Task FindLocation_ReturnsTheCorrectLocation()
        {
            var service = serviceProvider.GetService<ILocationServiceAdmin>();

            var id = 1;

            var location = await service.FindLocationAsync(id);

            Assert.That(location != null);
        }

        [Test]
        public async Task IsLocationExistedByModel_ReturnsTheCorrectResult()
        {
            var service = serviceProvider.GetService<ILocationServiceAdmin>();

            var model = new CreateLocationViewModel()
            {
                LocationName = "Sofia Airport"
            };

            var result = await service.IsLocationExists(model);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsILocationExistedByModel_ReturnsFalseWhenTheNameOfLocationIsNotFound()
        {
            var service = serviceProvider.GetService<ILocationServiceAdmin>();

            var model = new CreateLocationViewModel()
            {
                LocationName = "Sofia Mall"
            };

            var result = await service.IsLocationExists(model);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task IsExisted_ReturnsTheCorrectResult()
        {
            var service = serviceProvider.GetService<ILocationServiceAdmin>();

            var id = 1;

            var result = await service.IsExisted(id);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsExisted_ReturnsFalseWhenTheLocationIsNotFound()
        {
            var service = serviceProvider.GetService<ILocationServiceAdmin>();

            var id = 12;

            var result = await service.IsExisted(id);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task CreateLocation_ThrowsExceptionWhenTheTypeOfILocationExist()
        {
            var service = serviceProvider.GetService<ILocationServiceAdmin>();

            var model = new CreateLocationViewModel()
            {
                LocationName = "Sofia Airport"
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await service.CreateLocation(model), "The location has already existed!");
        }

        [Test]
        public async Task CreateLocation_SucceedInCreatingTheLocation()
        {
            var service = serviceProvider.GetService<ILocationServiceAdmin>();
            var locations = await service.GetAllAsync();

            var model = new CreateLocationViewModel()
            {
                LocationName = "Varna",
                Address = "Bulgaria, Varna, 9000",
            };
            await service.CreateLocation(model);

            var locations1 = await service.GetAllAsync();

            Assert.That(locations.Count() < locations1.Count());
        }

        [Test]
        public async Task RemoveLocation_SucceededInRemovingTheLocation()
        {
            var service = serviceProvider.GetService<ILocationServiceAdmin>();

            var id = 1;
            var location = await service.FindLocationAsync(id);

            await service.RemoveLocationAsync(id);

            Assert.That(location.IsActive == false);
        }

        [Test]
        public async Task EditLocation_SucceededInEditingTheLocation()
        {
            var service = serviceProvider.GetService<ILocationServiceAdmin>();

            var id = 3;
            var location = await service.FindLocationAsync(id);
            var locationName = location.LocationName;

            var model = new LocationViewModel
            {
                LocationName = "Sofia Mall",
                Address = "Bulgaria, Sofia, 1000"
            };
            await service.Edit(id, model);

            Assert.That(locationName != location.LocationName);
        }
    }
}
