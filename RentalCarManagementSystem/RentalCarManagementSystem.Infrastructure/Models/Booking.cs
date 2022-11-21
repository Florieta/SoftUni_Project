using RentalCarManagementSystem.Infrastructure.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Infrastructure.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime PickUpDateAndTime { get; set; } 

        [Required]
        public DateTime DropOffDateAndTime { get; set; } 

        [Required]
        public int Duration { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public string PaymentType { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public bool IsPaid { get; set; } = false;

        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;

        [Required]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(PickUpLocation))]
        public int PickUpLocationId { get; set; }

        public Location PickUpLocation { get; set; } = null!;
        [Required]
        [ForeignKey(nameof(DropOffLocation))]
        public int DropOffLocationId { get; set; }
       
        public Location DropOffLocation { get; set; } = null!;

        [ForeignKey(nameof(Insurance))]
        public int InsuranceCode { get; set; }
       
        public Insurance? Insurance { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; } = null!;

        public ApplicationUser ApplicationUser { get; set; } = null!;

    }
}
