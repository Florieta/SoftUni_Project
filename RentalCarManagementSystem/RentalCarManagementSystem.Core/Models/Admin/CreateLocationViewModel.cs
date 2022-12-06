using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Admin
{
    public class CreateLocationViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string LocationName { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Address { get; set; } = null!;
    }
}
