using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCarManagementSystem.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarManagementSystem.Infrastructure.Data.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());

           
            
        }

        private List<Category> CreateCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                 {
                      Id = 1,
                      CategoryName = "Economy"
                 },

                new Category()
                {
                    Id = 2,
                    CategoryName = "Compact"
                },

                new Category()
                {
                    Id = 3,
                    CategoryName = "Intermediate"
                }
            };

            return categories;
        }
    }
}
