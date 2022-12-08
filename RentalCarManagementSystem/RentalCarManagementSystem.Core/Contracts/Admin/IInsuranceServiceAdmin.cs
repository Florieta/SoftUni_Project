using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Contracts.Admin
{
    public interface IInsuranceServiceAdmin
    {
        Task<IEnumerable<InsuranceViewModel>> GetAllAsync();

        Task CreateInsurance(CreateInsuranceViewModel model);

        Task Edit(int id, InsuranceViewModel model);

        Task<bool> IsInsuranceExisted(CreateInsuranceViewModel model);

        Task<bool> IsExisted(int insuranceCode);

        Task<Insurance> FindInsuranceAsync(int id);

        Task RemoveInsuranceAsync(int id);
    }
}
