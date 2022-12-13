using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Admin
{
    public class UserProfileViewModel
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
       
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? Address { get; set; }
        public string? JobPosition { get; set; }

        public string? ImageUrl { get; set; }
    }
}
