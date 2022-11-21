using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Infrastructure.Models
{
    public class Category
    {
       
        [Key]
        public int Id { get; set; } 

        [Required]
        [MaxLength(20)]
        public string CategoryName { get; set; } = null!;

        public ICollection<Car> Cars { get; init; } = new List<Car>();
       

    }
}
