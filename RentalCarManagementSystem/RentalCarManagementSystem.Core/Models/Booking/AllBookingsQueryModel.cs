using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Booking
{
    public class AllBookingsQueryModel
    {
        public DateTime? SearchTerm { get; set; }
        public IEnumerable<AllBookingsViewModel> Bookings { get; set; } = Enumerable.Empty<AllBookingsViewModel>();
    }
}
