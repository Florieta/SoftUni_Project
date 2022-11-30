using RentalCarManagementSystem.Core.Models.Car;
using RentalCarManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Booking
{
    public class BookingFormViewModel 
    {

        //Customer

        [Required]
        [StringLength(75, MinimumLength = 10)]
        public string FullName { get; set; } = null!;

        [Required]
        [StringLength(75, MinimumLength = 10)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(75, MinimumLength = 7)]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string IdCardNumber { get; set; } = null!;

        [Required]
        [StringLength(10, MinimumLength = 5)]

        public string DriverLicenseNumber { get; set; } = null!;

        [Required]
        public DateTime DateOfExpired { get; set; }

        [Required]
        public DateTime DateOfIssue { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]

        public string IssuedBy { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        //Car

        [Required]
        public DateTime PickUpDateAndTime { get; set; }

        [Required]
        public DateTime DropOffDateAndTime { get; set; }

        [Required]
        public int Duration { get; set; }

        public int PickUpLocationId { get; set; }
   
        public IEnumerable<Location> PickUpLocations { get; set; } = new List<Location>();
        public int DropOffLocationId { get; set; }
        public IEnumerable<Location> DropOffLocations { get; set; } = new List<Location>();
        public int InsuranceCode { get; set; }

        public IEnumerable<Insurance> Insurance { get; set; } = new List<Insurance>();

        public decimal DailyRate { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
      

        [Required]
        public string PaymentType { get; set; } = null!;

        public bool IsActive { get; set; }

        public bool IsPaid { get; set; }
    }
}
