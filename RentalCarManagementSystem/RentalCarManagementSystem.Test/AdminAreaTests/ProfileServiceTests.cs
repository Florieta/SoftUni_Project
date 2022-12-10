using Microsoft.Extensions.DependencyInjection;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Core.Services;
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
    [TestFixture]
    public class ProfileServiceTests
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
                .AddSingleton<IProfileServiceAdmin, ProfileServiceAdmin>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

        }

        [Test]
        public async Task GetUserByUsername_Succeed()
        {
            var service = serviceProvider.GetService<IProfileServiceAdmin>();
            var model = new UserProfileViewModel()
            {
                Id = "d3211a8d-efde-4a19-8087-79cde4679276",
                UserName = "Admin",
                Email = "admin@gmail.com",
                Address = null,
                JobPosition = null,
                ImageUrl = null,
                FirstName = "Peter",
                LastName = "Parker",
            };

            var user = await service.GetUserByUsernameAsync(model.UserName);

            Assert.That(user, Is.Not.Null);
        }

        [Test]
        public async Task GetUserByUsername_ThrowsExceptionWhenUsernameDoesNotExists()
        {
            var service = serviceProvider.GetService<IProfileServiceAdmin>();

            var userName = "Test1";

            Assert.ThrowsAsync<ArgumentException>(async () => await service.GetUserByUsernameAsync(userName), "Invalid user!");
        }


        [Test]
        public async Task GetUserById_Succeed()
        {
            var service = serviceProvider.GetService<IProfileServiceAdmin>();

            var id = "d3211a8d-efde-4a19-8087-79cde4679276";

            var user = await service.GetUserById(id);

            Assert.That(user, Is.Not.Null);
        }

        [Test]
        public async Task GetUserByIdWithInvalidId_ReturnFalse()
        {
            var service = serviceProvider.GetService<IProfileServiceAdmin>();

            var id = "d3211a8d";

            var user = await service.GetUserById(id);

            Assert.That(user, Is.Null);
        }

        [Test]
        public async Task GetUserByIdWithInvalidId_ThrowsAppropriateException()
        {
            var service = serviceProvider.GetService<IProfileServiceAdmin>();

            var model = new EditUserProfileViewModel()
            {
                Id = "1",
                UserName = "Admin",
                Email = "admin@gmail.com",
                FirstName = "Peter",
                LastName = "Parker"
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await service.EditProfile(model, model.Id), "Invalid user ID");
        }

        [Test]
        public async Task EditProfile_SuccessfullyEditTheUser()
        {
            var service = serviceProvider.GetService<IProfileServiceAdmin>();

            var model = new EditUserProfileViewModel()
            {
                Id = "d3211a8d-efde-4a19-8087-79cde4679276",
                UserName = "Admin",
                Email = "admin@gmail.com",
                FirstName = "Peter",
                LastName = "Parker"
            };

            var user1 = await service.EditProfile(model, model.Id);

            Assert.IsTrue(user1);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();

        }

    }
}
