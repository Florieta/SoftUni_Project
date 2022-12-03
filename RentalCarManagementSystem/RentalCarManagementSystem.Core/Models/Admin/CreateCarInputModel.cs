using RentalCarManagementSystem.Core.CustomAttributes;
using RentalCarManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Admin
{
    public class CreateCarInputModel
    {
        [Required]
        [StringLength(8, MinimumLength = 6)]
        public string RegNumber { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 3)]

        public string Model { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Make { get; set; } = null!;

        [Required]
        [IsBeforeAttribute("01/01/2015")]
        public int MakeYear { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]

        public string Color { get; set; } = null!;

        [Required]
        [StringLength(5000, MinimumLength = 10)]

        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(10, MinimumLength = 3)]

        public string GearBox { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();


        [Required]
        public decimal DailyRate { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;
    }
}
