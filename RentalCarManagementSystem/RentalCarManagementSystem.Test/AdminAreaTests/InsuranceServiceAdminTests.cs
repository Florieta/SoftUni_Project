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
    public class InsuranceServiceAdminTests
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
                .AddSingleton<IInsuranceServiceAdmin, InsuranceServiceAdmin>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IRepository>();
        }
        [Test]
        public async Task GetAll_SucceededShowAllInsurances()
        {
            var service = serviceProvider.GetService<IInsuranceServiceAdmin>();

            var insurances = await service.GetAllAsync();

            Assert.That(insurances.Count() == 2);
        }

        [Test]
        public async Task FindInsurance_ReturnsTheCorrectInsurance()
        {
            var service = serviceProvider.GetService<IInsuranceServiceAdmin>();

            var insuranceCode = 1;

            var insurance = await service.FindInsuranceAsync(insuranceCode);

            Assert.That(insurance != null);
        }

        [Test]
        public async Task IsInsuranceExistedByModel_ReturnsTheCorrectResult()
        {
            var service = serviceProvider.GetService<IInsuranceServiceAdmin>();

            var model = new CreateInsuranceViewModel()
            {
                TypeOfInsurance = "FullCoverage",
                CostPerDay = 10
            };

            var result = await service.IsInsuranceExisted(model);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsInsuranceExistedByModel_ReturnsFalseWhenTheTypeOfInsuranceIsNotCorrect()
        {
            var service = serviceProvider.GetService<IInsuranceServiceAdmin>();

            var model = new CreateInsuranceViewModel()
            {
                TypeOfInsurance = "Full",
                CostPerDay = 10
            };

            var result = await service.IsInsuranceExisted(model);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task IsExisted_ReturnsTheCorrectResult()
        {
            var service = serviceProvider.GetService<IInsuranceServiceAdmin>();

            var insuranceCode = 1;

            var result = await service.IsExisted(insuranceCode);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsExisted_ReturnsFalseWhenTheInsuranceIsNotFound()
        {
            var service = serviceProvider.GetService<IInsuranceServiceAdmin>();

            var insuranceCode = 12;

            var result = await service.IsExisted(insuranceCode);

            Assert.That(result, Is.False);
        }


        [Test]
        public async Task CreateInsurance_SucceededInCheckingThatInsuranceTypeDoesNotExist()
        {
            var service = serviceProvider.GetService<IInsuranceServiceAdmin>();

            var model = new CreateInsuranceViewModel()
            {
                TypeOfInsurance = "PartialCover",
                CostPerDay = 6
            };

            var result = await service.IsInsuranceExisted(model);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task CreateInsurance_ThrowsExceptionWhenTheTypeOfInsuranceExist()
        {
            var service = serviceProvider.GetService<IInsuranceServiceAdmin>();

            var model = new CreateInsuranceViewModel()
            {
                TypeOfInsurance = "FullCoverage",
                CostPerDay = 10
            };

            Assert.ThrowsAsync<ArgumentException>(() => service.CreateInsurance(model), "The insurance has already existed!");
        }


        [Test]
        public async Task CreateInsurance_SucceedInCreatingTheInsurance()
        {
            var service = serviceProvider.GetService<IInsuranceServiceAdmin>();
            var insurances = await service.GetAllAsync();

            var insuranceList = insurances.ToList();

            var model = new CreateInsuranceViewModel()
            {
                TypeOfInsurance = "PartialCover"
            };
            await service.CreateInsurance(model);

            var insurances1 = await service.GetAllAsync();

            var insuranceList1 = insurances1.ToList();

            Assert.That(insuranceList.Count != insuranceList1.Count);
        }

        [Test]
        public async Task RemoveInsurance_SucceededInRemovingTheInsurance()
        {
            var service = serviceProvider.GetService<IInsuranceServiceAdmin>();

            var insCode = 1;
            var insurance = await service.FindInsuranceAsync(insCode);

            await service.RemoveInsuranceAsync(insCode);

            Assert.That(insurance.IsActive == false);
        }

        [Test]
        public async Task EditInsurance_SucceededInEditingTheInsurance()
        {
            var service = serviceProvider.GetService<IInsuranceServiceAdmin>();

            var insCode = 1;
            var insurance = await service.FindInsuranceAsync(insCode);
            var costPerDay = insurance.CostPerDay;

            var model = new InsuranceViewModel
            {
                TypeOfInsurance = "FullCoverage",
                CostPerDay = 2
            };
            await service.Edit(insCode, model);

            Assert.That(costPerDay != insurance.CostPerDay);
        }
    }
}
