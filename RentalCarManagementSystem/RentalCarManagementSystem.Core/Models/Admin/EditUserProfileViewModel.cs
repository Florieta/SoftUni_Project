using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Admin
{
    public class EditUserProfileViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;

        public string? Address { get; set; }

        public string? ImageUrl { get; set; }

        public string? JobPosition { get; set; }


    }
}
