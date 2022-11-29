using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalCarManagementSystem.Infrastructure.Models;

namespace RentalCarManagementSystem.Core.Models.Booking
{
    public class BookingDetailsViewModel
    {
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string RegNumber { get; set; } = null!;


        public string FullName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;
  
        public string IdCardNumber { get; set; } = null!;

        public string DriverLicenseNumber { get; set; } = null!;
        public DateTime DateOfExpired { get; set; }

        public DateTime DateOfIssue { get; set; }

        public string IssuedBy { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public DateTime PickUpDateAndTime { get; set; }

        public DateTime DropOffDateAndTime { get; set; }

        public int Duration { get; set; }

        public string PickUpLocationName { get; set; } = null!;

        public string DropOffLocationName { get; set; } = null!;


        public decimal TotalAmount { get; set; }

        public string PaymentType { get; set; } = null!;
    }
}
