using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentalCarManagementSystem.Core.Contracts;
using RentalCarManagementSystem.Core.Contracts.Admin;
using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Infrastructure.Data.Common;
using RentalCarManagementSystem.Infrastructure.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Services.Admin
{
    public class ProfileServiceAdmin : IProfileServiceAdmin
    {
        private readonly IRepository repo;

        public ProfileServiceAdmin(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<UserProfileViewModel> GetUserByUsernameAsync(string username)
        {
            var user = await repo.All<ApplicationUser>()
                .Where(x => x.UserName == username)
                .Select(x => new UserProfileViewModel()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Address = x.Address,
                    JobPosition = x.JobPosition,
                    ImageUrl = x.ImageUrl
                })
                .FirstOrDefaultAsync();

            if(user == null)
            {
                throw new ArgumentException("Invalid user!");
            }

            return user;
        }

        public async Task<bool> EditProfile(EditUserProfileViewModel model, string id)
        {
            bool result = false;

            var user = await GetUserById(id);
            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            if (user != null)
            {
                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.JobPosition = model.JobPosition;
                user.ImageUrl = model.ImageUrl;
                user.Address = model.Address;

                await repo.SaveChangesAsync();

                result = true;
            }
            return result;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await repo.GetByIdAsync<ApplicationUser>(id);
        }
    }
}
