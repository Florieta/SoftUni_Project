using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Infrastructure.Models
{
    public class Car
    {
        //TO DO: Make constans

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(8)]
        public string RegNumber { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string Model { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string Make { get; set; } = null!;

        [Required]
        [Range(2010, 2022)]
        public int MakeYear { get; set; } 

        [Required]
        [MaxLength(20)]
        public string Color { get; set; } = null!;

        [Required]
        [MaxLength(5000)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string GearBox { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        public decimal DailyRate { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;

        public bool NotInUse { get; set; } = false;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
