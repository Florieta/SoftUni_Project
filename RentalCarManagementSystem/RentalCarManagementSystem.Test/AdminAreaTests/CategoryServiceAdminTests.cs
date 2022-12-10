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

            Assert.That(result, Is.True);
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
                CategoryName = "Test"
            };

            var result = await service.CategoryExistsByName(model.CategoryName);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task CreateCategory_CategoryNameExists()
        {
            var service = serviceProvider.GetService<ICategoryServiceAdmin>();

            var model = new CreateCategoryInputModel()
            {
                CategoryName = "Economy"
            };

            var result = await service.CategoryExistsByName(model.CategoryName);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task CreateCategory_CategoryNameExistsAndThrowsException()
        {
            var service = serviceProvider.GetService<ICategoryServiceAdmin>();

            var model = new CreateCategoryInputModel()
            {
                CategoryName = "Economy"
            };

            Assert.ThrowsAsync<ArgumentException>(async () => await service.CreateCategory(model), "The category has already existed!");
        }


        [Test]
        public async Task CreateCategory_SucceedInCreatingTheCategory()
        {
            var service = serviceProvider.GetService<ICategoryServiceAdmin>();
            var categories = await service.GetAllAsync();

            var model = new CreateCategoryInputModel()
            {
                CategoryName = "Test"
            };
            await service.CreateCategory(model);

            var categories1 = await service.GetAllAsync();

            Assert.That(categories.Count() < categories1.Count());
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
    
    }
}
