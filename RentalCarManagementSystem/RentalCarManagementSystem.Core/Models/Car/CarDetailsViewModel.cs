using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Car
{
    public class CarDetailsViewModel 
    {
        public int Id { get; set; }
        public string RegNumber { get; set; } = null!;

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public int MakeYear { get; set; }

        public string Color { get; set; } = null!;

        [DisplayName("Image URL")]
        public string ImageUrl { get; set; } = null!;

        [DisplayName("Price per day")]
        public decimal DailyRate { get; set; }

        public string Description { get; set; } = null!;

        public string GearBox { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public bool IsAvailable { get; set; }

    }
}
