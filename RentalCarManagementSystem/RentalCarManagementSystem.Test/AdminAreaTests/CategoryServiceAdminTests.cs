using Microsoft.Extensions.DependencyInjection;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Core.Services.Admin;
using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarManagementSystem.Infrastructure.Models;
using RentalCarManagementSystem.Test.UserAreaTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Test.AdminAreaTests
{
    public class CategoryServiceAdminTests
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
                .AddSingleton<ICategoryServiceAdmin, CategoryServiceAdmin>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();

            await SeedAsync(repo);
        }

        [Test]
        public async Task FindCategory_ReturnsTheCorrectCategory()
        {
            var service = serviceProvider.GetService<ICategoryServiceAdmin>();

            var id = 1;

            var category = await service.FindCategoryAsync(id);

            Assert.That(category != null);
        }

        [Test]
        public async Task CategoryExistsByName_ReturnsTheCorrectResult()
        {
            var service = serviceProvider.GetService<ICategoryServiceAdmin>();

            string categoryName = "Economy";

            var result = await service.CategoryExistsByName(categoryName);

            Assert.That(categoryName, Is.True);
        }


        [Test]
        public async Task IsExisted_ReturnsTheCorrectResult()
        {
            var service = serviceProvider.GetService<ICategoryServiceAdmin>();

            var id = 1;

            var result = await service.IsExisted(id);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsExisted_ReturnsFalseWhenTheInsuranceIsNotFound()
        {
            var service = serviceProvider.GetService<ICategoryServiceAdmin>();

            var id = 12;

            var result = await service.IsExisted(id);

            Assert.That(result, Is.False);
        }
        [Test]
        public async Task GetAll_SucceededShowAllCategories()
        {
            var service = serviceProvider.GetService<ICategoryServiceAdmin>();

            var categories = await service.GetAllAsync();

            var categoryList = categories.ToList();

            Assert.That(categoryList.Count == 3);
        }

        [Test]
        public async Task CreateCategory_SucceededInCheckingThatCategoryNameDoesNotExist()
        {
            var service = serviceProvider.GetService<ICategoryServiceAdmin>();

            var model = new CreateCategoryInputModel()
            {
                CategoryName = "Electric"
            };

            var result = await service.CategoryExistsByName(model.CategoryName);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task CreateCategory_CategoryNameExistsAndReturnsFalse()
        {
            var service = serviceProvider.GetService<ICategoryServiceAdmin>();

            var model = new CreateCategoryInputModel()
            {
                CategoryName = "Economy"
            };

            var result = await service.CategoryExistsByName(model.CategoryName);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task CreateCategory_CategoryNameExistsAndThrowsException()
        {
            var service = serviceProvider.GetService<ICategoryServiceAdmin>();


            var model = new CreateCategoryInputModel()
            {
                CategoryName = "Economy"
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await service.CategoryExistsByName(model.CategoryName), "The category has already existed!");
        }


        [Test]
        public async Task CreateCategory_SucceedInCreatingTheCategory()
        {
            var service = serviceProvider.GetService<ICategoryServiceAdmin>();
            var categories = await service.GetAllAsync();

            var categoryList = categories.ToList();

            var model = new CreateCategoryInputModel()
            {
                CategoryName = "Economy"
            };
            await service.CreateCategory(model);

            var categories1 = await service.GetAllAsync();

            var categoryList1 = categories1.ToList();

            Assert.That(categoryList.Count != categoryList1.Count);
        }

        [Test]
        public async Task RemoveCategory_SucceededInRemovingTheCategory()
        {
            var service = serviceProvider.GetService<ICategoryServiceAdmin>();

            var id = 1;
            var category = await service.FindCategoryAsync(id);

            await service.RemoveCategoryAsync(id);

            Assert.That(category.IsActive == false);
        }

        [Test]
        public async Task EditCategory_SucceededInEditingTheCategory()
        {
            var service = serviceProvider.GetService<ICategoryServiceAdmin>();

            var id = 1;
            var category = await service.FindCategoryAsync(id);
            var categoryName = category.CategoryName;

            var model = new CategoryViewModel
            {
                CategoryName = "Mini van"
            };
            await service.Edit(id, model);

            Assert.That(categoryName != category.CategoryName);
        }
        private async Task SeedAsync(IRepository repo)
        {
            var car = new Car()
            {
                Id = 1,
                RegNumber = "B1234AB",
                Make = "Toyota",
                Model = "Corolla",
                MakeYear = 2022,
                Color = "Black",
                Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment, sedan.",
                ImageUrl = "https://images.dealer.com/autodata/us/640/color/2022/USD20TOC041A0/209.jpg?_returnflight_id=091119126",
                GearBox = "Manual",
                DailyRate = 40,
                IsAvailable = true,
                CategoryId = 3,
            };

            var car1 = new Car()
            {
                Id = 2,
                RegNumber = "B1444CB",
                Make = "Hundai",
                Model = "i20",
                MakeYear = 2022,
                Color = "Grey",
                Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, no highest equipment.",
                ImageUrl = "https://s7g10.scene7.com/is/image/hyundaiautoever/BC3_5DR_TopTrim_DG01-01_EXT_front_rgb_v01_w3a-1:4x3?wid=960&hei=720&fmt=png-alpha&fit=wrap,1",
                GearBox = "Manual",
                DailyRate = 33,
                IsAvailable = true,
                CategoryId = 1,
            };

            var car3 = new Car()
            {
                Id = 3,
                RegNumber = "B1223AB",
                Make = "Citroen",
                Model = "C4",
                MakeYear = 2022,
                Color = "White",
                Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment.",
                ImageUrl = "https://www.citroen-eg.com/wp-content/uploads/2021/11/Polar-White-front1.jpg",
                GearBox = "Automatic",
                DailyRate = 37,
                IsAvailable = false,
                CategoryId = 2,
            };


            var category = new Category()
            {
                Id = 1,
                CategoryName = "Compact"
            };

            var category2 = new Category()
            {
                Id = 2,
                CategoryName = "Intermediate"
            };

            var category3 = new Category()
            {
                Id = 3,
                CategoryName = "Economy"
            };



            await repo.AddAsync(car);
            await repo.AddAsync(car1);
            await repo.AddAsync(car3);
            await repo.AddAsync(category2);
            await repo.AddAsync(category);
            await repo.AddAsync(category3);
            await repo.SaveChangesAsync();
        }
    }
}
