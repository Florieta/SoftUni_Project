using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Admin
{
    public class CreateInsuranceViewModel
    {
        [StringLength(50, MinimumLength = 3)]
        public string TypeOfInsurance { get; set; } = null!;

        public decimal CostPerDay { get; set; }
        public bool IsActive { get; set; }

    }
}
