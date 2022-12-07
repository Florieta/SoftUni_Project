using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Admin
{
    public class CreateCategoryInputModel
    {
        [Required]
        [MaxLength(20)]
        public string CategoryName { get; set; } = null!;

    }
}
