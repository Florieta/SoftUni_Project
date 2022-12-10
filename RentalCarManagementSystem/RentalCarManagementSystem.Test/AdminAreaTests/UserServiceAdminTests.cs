using Microsoft.Extensions.DependencyInjection;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Mapping;
using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Core.Services.Admin;
using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarManagementSystem.Infrastructure.Models.Identity;
using RentalCarManagementSystem.Test.UserAreaTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Test.AdminAreaTests
{
    public class UserServiceAdminTests
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
                .AddSingleton<IUserServiceAdmin, UserServiceAdmin>()
                .AddAutoMapper(typeof(UserMapping))
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();
        }

        [Test]
        public async Task SucceedGetUserByIdForEdit_ReturnsTheCorrectInstanceOfUsersViewModel()
        {
            var service = serviceProvider.GetService<IUserServiceAdmin>();

            var userId = "d3211a8d-efde-4a19-8087-79cde4679276";

            var user = await service.GetUserByIdEditAsync(userId);

            Assert.IsInstanceOf(typeof(EditUserViewModel), user);
        }

        [Test]
        public async Task SucceedGetUserByIdForEdit_ReturnsTheCorrectResult()
        {
            var service = serviceProvider.GetService<IUserServiceAdmin>();

            var userId = "d3211a8d-efde-4a19-8087-79cde4679276";

            var user = await service.GetUserByIdEditAsync(userId);

            Assert.That(user != null);
        }

        [Test]
        public async Task GetUserByIdForEditWithInvalidId_ReturnsNull()
        {
            var service = serviceProvider.GetService<IUserServiceAdmin>();

            var userId = "laaaaaaaaaaaa";

            var user = await service.GetUserByIdEditAsync(userId);

            Assert.That(user == null);
        }

        [Test]
        public async Task SucceedGetUserByIdForRoles_ReturnsTheCorrectInstance()
        {
            var service = serviceProvider.GetService<IUserServiceAdmin>();

            var userId = "d3211a8d-efde-4a19-8087-79cde4679276";

            var user = await service.GetUserByIdRoles(userId);

            Assert.IsInstanceOf(typeof(ApplicationUser), user);
        }

        [Test]
        public async Task SucceedGetUserByIdForRoles_ReturnsCorrectResult()
        {
            var service = serviceProvider.GetService<IUserServiceAdmin>();

            var userId = "d3211a8d-efde-4a19-8087-79cde4679276";

            var user = await service.GetUserByIdRoles(userId);

            Assert.That(user != null);
        }

        [Test]
        public async Task GetUserByIdForRolesWithInvalidId_ReturnsNull()
        {
            var service = serviceProvider.GetService<IUserServiceAdmin>();

            var userId = "Laaaaa";

            var user = await service.GetUserByIdRoles(userId);

            Assert.That(user == null);
        }

        [Test]
        public async Task EditUser_ReturnsCorrectResult()
        {
            var service = serviceProvider.GetService<IUserServiceAdmin>();

            var model = new EditUserViewModel()
            {
                Id = "d3211a8d-efde-4a19-8087-79cde4679276",
                UserName = "Admin",
                Email = "admin1@gmail.com",
                PhoneNumber = "1234567890",
                FirstName = "Peter",
                LastName = "Parker",
            };

            var result = await service.UpdateUser(model);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task EditUserWithInvalidId_ReturnsFalse()
        {
            var model = new EditUserViewModel()
            {
                Id = "aaaaa",
                UserName = "tast"
            };

            var service = serviceProvider.GetService<IUserServiceAdmin>();

            var result = await service.UpdateUser(model);

            Assert.That(result, Is.False);
        }

    }
}
