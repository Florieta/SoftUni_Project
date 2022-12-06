using Microsoft.Extensions.DependencyInjection;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Models.User;
using RentalCarManagementSystem.Core.Services;
using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarManagementSystem.Infrastructure.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Test.UserAreaTests
{
    [TestFixture]
    public class UserServiceTests
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
                .AddSingleton<IUserService, UserService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            await SeedAsync(repo);
        }

        [Test]
        public async Task GetUserByUsername_Succeed()
        {
            var service = serviceProvider.GetService<IUserService>();

            var userName = "Admin";

            var user = await service.GetUserByUsernameAsync(userName);

            Assert.That(user, Is.Not.Null);
        }

        [Test]
        public async Task GetUserByUsername_ThrowsExceptionWhenUsernameDoesNotExists()
        {
            var service = serviceProvider.GetService<IUserService>();

            var userName = "Aaaaa";

            var user = await service.GetUserByUsernameAsync(userName);

            Assert.That(user, Is.Null);

            Assert.Throws<ArgumentException>(() => service.GetUserByUsernameAsync(userName), "Invalid user!");
        }


        [Test]
        public async Task GetUserById_Succeed()
        {
            var service = serviceProvider.GetService<IUserService>();

            var id = "d3211a8d-efde-4a19-8087-79cde4679276";

            var user = await service.GetUserById(id);

            Assert.That(user, Is.Not.Null);
        }

        [Test]
        public async Task GetUserByIdWithInvalidId_ReturnFalse()
        {
            var service = serviceProvider.GetService<IUserService>();

            var id = "d3211a8d";

            var user = await service.GetUserById(id);

            Assert.That(user, Is.Null);
        }

        [Test]
        public async Task GetUserByIdWithInvalidId_ThrowsAppropriateException()
        {
            var service = serviceProvider.GetService<IUserService>();

            var id = "d3211a8d";

            var user = await service.GetUserById(id);

            Assert.Throws<ArgumentException>(() => service.GetUserById(id), "Invalid user ID");
        }

        [Test]
        public async Task EditProfile_SuccessfullyEditTheUser()
        {
            var service = serviceProvider.GetService<IUserService>();

            var model = new EditUserProfileViewModel()
            {
                Id = "d3211a8d-efde-4a19-8087-79cde4679276",
                UserName = "Admin",
                Email = "admin@gmail.com",
                FirstName = "Peter",
                LastName = "Parker"
            };

            var user1 = await service.EditProfile(model);

            Assert.IsTrue(user1);
        }

        [Test]
        public async Task EditProfile_ReturnFalse()
        {
            var service = serviceProvider.GetService<IUserService>();

            var model = new EditUserProfileViewModel()
            {
                Id = "1",
                UserName = "Admin",
                Email = "admin@gmail.com",
                FirstName = "Peter",
                LastName = "Parker"
            };

            var user1 = await service.EditProfile(model);

            Assert.That(user1 == false);
        }

        private async Task SeedAsync(IRepository repo)
        {
          
            var user = new ApplicationUser()
            {
                Id = "d3211a8d-efde-4a19-8087-79cde4679276",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "1234567890",
                FirstName = "Peter",
                LastName = "Parker"
            };

            var agent = new ApplicationUser()
            {
                Id = "c6e570fd-d889-4a67-a36a-0ecbe758bc2c",
                UserName = "Agent1",
                NormalizedUserName = "AGENT1",
                Email = "agent@mail.com",
                NormalizedEmail = "AGENT@MAIL.COM",
                PhoneNumber = "1234567890",
                FirstName = "Peter",
                LastName = "Brwon"
            };

            await repo.AddAsync(user);
            await repo.AddAsync(agent);
            await repo.SaveChangesAsync();
        }

    }
}
