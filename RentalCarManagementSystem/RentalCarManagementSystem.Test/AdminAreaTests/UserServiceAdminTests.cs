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

            await SeedAsync(repo);
        }

        [Test]
        public async Task SucceedGetUserByIdForEdit_ReturnsTheCorrectInstanceOdUsersViewModel()
        {
            var service = serviceProvider.GetService<IUserServiceAdmin>();

            var userId = "someId";

            var user = await service.GetUserByIdEditAsync(userId);

            Assert.IsInstanceOf(typeof(UsersViewModel), user);
        }

        [Test]
        public async Task SucceedGetUserByIdForEdit_ReturnsTheCorrectResult()
        {
            var service = serviceProvider.GetService<IUserServiceAdmin>();

            var userId = "someId";

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

            var userId = "someId";

            var user = await service.GetUserByIdRoles(userId);

            Assert.IsInstanceOf(typeof(ApplicationUser), user);
        }

        [Test]
        public async Task SucceedGetUserByIdForRoles_ReturnsCorrectResult()
        {
            var service = serviceProvider.GetService<IUserServiceAdmin>();

            var userId = "someId";

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
            var model = new EditUserViewModel()
            {
                Id = "someId",
                UserName = "Admin"
            };

            var service = serviceProvider.GetService<IUserServiceAdmin>();

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

        private async Task SeedAsync(IRepository repo)
        {
            var user = new ApplicationUser()
            {
                Id = "someId",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "1234567890",
                FirstName = "Peter",
                LastName = "Parker"
            };

            var user2 = new ApplicationUser()
            {
                Id = "testId",
                UserName = "Agent1",
                NormalizedUserName = "AGENT1",
                Email = "agent@mail.com",
                NormalizedEmail = "AGENT@GMAIL.COM",
                PhoneNumber = "1234567890",
                FirstName = "Peter",
                LastName = "Brown",
            };

            await repo.AddAsync(user);
            await repo.AddAsync(user2);

            await repo.SaveChangesAsync();
        }
    }
}
