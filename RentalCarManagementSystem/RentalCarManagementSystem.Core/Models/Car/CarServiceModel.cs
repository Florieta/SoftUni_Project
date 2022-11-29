using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Car
{
    public class CarServiceModel
    {
        public int Id { get; set; }

        public string RegNumber { get; set; } = null!;
        
        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; } = null!;

        [DisplayName("Price per day")]
        public decimal DailyRate { get; set; }

        [DisplayName("Is Rented")]
        public bool IsAvailable { get; set; } 
    }
}
