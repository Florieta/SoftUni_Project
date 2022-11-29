using AutoMapper;
using RentalCarManagementSystem.Core.Models.Admin;
using RentalCarManagementSystem.Infrastructure.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<ApplicationUser, UserRolesViewModel>();
            CreateMap<ApplicationUser, UsersViewModel>();
            CreateMap<ApplicationUser, EditUserViewModel>();
        }
    }
}
