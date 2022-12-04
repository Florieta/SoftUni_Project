using RentalCarManagementSystem.Core.Models.User;
using RentalCarManagementSystem.Infrastructure.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Contracts
{
    public interface IUserService
    {
        Task<UserProfileViewModel> GetUserByUsernameAsync(string username);

        Task<bool> EditProfile(EditUserProfileViewModel model);

        Task<ApplicationUser> GetUserById(string id);

    }
}
