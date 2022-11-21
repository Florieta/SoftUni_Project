using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Infrastructure.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; } = null!;
        [MaxLength(75)]
        public string? Address { get; set; }
        public string? JobPosition { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
