using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class UserServiceAdmin : IUserServiceAdmin
    {
        private readonly IRepository repo;

        private readonly IMapper mapper;
        public UserServiceAdmin(IRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<ApplicationUser> GetUserByIdRoles(string id)
        {
            return await repo.GetByIdAsync<ApplicationUser>(id);
        }

        public async Task<IEnumerable<UsersViewModel>> GetAllUsersForManage()
        {
            var users = await repo.All<ApplicationUser>()
                            .ToListAsync();

            var usersServiceModels = mapper.Map<IEnumerable<UsersViewModel>>(users);

            return usersServiceModels;
        }

        public async Task<EditUserViewModel> GetUserByIdEditAsync(string id)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(id);

            return mapper.Map<EditUserViewModel>(user);
        }

        public async Task<bool> UpdateUser(EditUserViewModel model)
        {
            bool result = false;

            var user = await repo.GetByIdAsync<ApplicationUser>(model.Id);

            if (user != null)
            {
                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Address = model.Address;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.JobPosition = model.JobPosition;
                user.ImageUrl = model.ImageUrl;
                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }
    }
}
