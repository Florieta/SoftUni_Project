using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Core.Models.Car
{
    public class AllCarsQueryModel
    {
        public string? SearchMake { get; set; }

        public string? SearchModel { get; set; }

        public string? SearchRegNumber { get; set; }

        public IEnumerable<CarServiceModel> Cars { get; set; } = Enumerable.Empty<CarServiceModel>();
    }
}
