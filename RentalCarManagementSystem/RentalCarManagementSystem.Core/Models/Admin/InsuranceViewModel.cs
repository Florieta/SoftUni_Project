using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Admin
{
    public class InsuranceViewModel
    {
        public int InsuranceCode { get; set; }
        public string TypeOfInsurance { get; set; } = null!;
        public decimal CostPerDay { get; set; }
    }
}
