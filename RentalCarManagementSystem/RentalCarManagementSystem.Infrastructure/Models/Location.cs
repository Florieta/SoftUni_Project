using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Infrastructure.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        public string LocationName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        [InverseProperty("PickUpLocation")]
        public ICollection<Booking> PickUpBookings { get; set; } = new List<Booking>();

        [InverseProperty("DropOffLocation")]
        public ICollection<Booking> DropOffBookings { get; set; } = new List<Booking>();

    }
}
