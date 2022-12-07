using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Infrastructure.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Contracts.Admin
{
    public interface IProfileServiceAdmin
    {
        Task<UserProfileViewModel> GetUserByUsernameAsync(string username);

        Task<bool> EditProfile(EditUserProfileViewModel model, string id);

        Task<ApplicationUser> GetUserById(string id);

    }
}
