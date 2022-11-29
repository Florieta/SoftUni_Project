using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Booking
{
    public class AllBookingsViewModel
    {
        public DateTime SearchTirm { get; set; }
        public int Id { get; set; }

        public int CarId { get; set; }
       
        public string FullName { get; set; } = null!;

        public DateTime PickUpDateAndTime { get; set; }

        public DateTime DropOffDateAndTime { get; set; }

        public decimal TotalAmount { get; set; }
    
        public bool IsRented { get; set; }

        public bool IsPaid { get; set; }

    }
}
