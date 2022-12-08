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
    public class InsuranceServiceAdmin : IInsuranceServiceAdmin
    {
        private readonly IRepository repo;
        public InsuranceServiceAdmin(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<InsuranceViewModel>> GetAllAsync()
        {
            var entities = await repo.All<Insurance>().ToListAsync();

            return entities
            .Select(m => new InsuranceViewModel()
            {
                InsuranceCode = m.InsuranceCode,
                TypeOfInsurance = m.TypeOfInsurance,
                CostPerDay = m.CostPerDay
            });
        }

        public async Task CreateInsurance(CreateInsuranceViewModel model)
        {
            if (await IsInsuranceExisted(model))
            {
                throw new ArgumentException("The insurance has already existed!");
            }

            var insurance = new Insurance()
            {
                TypeOfInsurance = model.TypeOfInsurance,
                CostPerDay = model.CostPerDay,
                IsActive = true
            };

            await repo.AddAsync(insurance);
            await repo.SaveChangesAsync();
        }

        public async Task RemoveInsuranceAsync(int id)
        {
            var insurance = await repo.GetByIdAsync<Insurance>(id);
            insurance.IsActive = false;

            await repo.SaveChangesAsync();

        }

        public async Task Edit(int id, InsuranceViewModel model)
        {
            var insurance = await repo.GetByIdAsync<Insurance>(id);

            insurance.TypeOfInsurance = model.TypeOfInsurance;
            insurance.CostPerDay = model.CostPerDay;

            await repo.SaveChangesAsync();
        }


        public async Task<bool> IsInsuranceExisted(CreateInsuranceViewModel model)
        {
            return await repo.All<Insurance>()
                .AnyAsync(x => x.TypeOfInsurance == model.TypeOfInsurance);
        }

        public async Task<bool> IsExisted(int insuranceCode)
        {
            return await repo.All<Insurance>()
                .AnyAsync(x => x.InsuranceCode == insuranceCode);
        }

        public async Task<Insurance> FindInsuranceAsync(int id)
        {
            return await repo.GetByIdAsync<Insurance>(id);
        }
    }
}
