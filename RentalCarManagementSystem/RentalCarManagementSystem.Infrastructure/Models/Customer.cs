using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Infrastructure.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(75)]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength(75)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(75)]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        public string IdCardNumber { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string DriverLicenseNumber { get; set; } = null!;
        [Required]
        public DateTime DateOfExpired { get; set; }
        [Required]
        
        public DateTime DateOfIssue { get; set; }
        [Required]
        [MaxLength(20)]
        public string IssuedBy { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();


    }
}
