using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Admin
{
    public class UserRolesViewModel
    {
        public string Id { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string[] RoleNames { get; set; } = null!;
    }
}
