using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Infrastructure.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Contracts.Admin
{
    public interface IUserServiceAdmin
    {
        Task<ApplicationUser> GetUserByIdRoles(string id);

        Task<IEnumerable<UsersViewModel>> GetAllUsersForManage();

        Task<EditUserViewModel> GetUserByIdEditAsync(string id);

        Task<bool> UpdateUser(EditUserViewModel model);
    }
}
