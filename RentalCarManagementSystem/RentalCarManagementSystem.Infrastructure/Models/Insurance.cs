using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Infrastructure.Models
{
    public class Insurance
    {
        [Key]
        public int InsuranceCode { get; set; }

       
        [StringLength(50)]
        public string TypeOfInsurance { get; set; } = null!;

        public decimal CostPerDay { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
