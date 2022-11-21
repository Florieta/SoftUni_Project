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
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(CreateCustomers());
        }
        private List<Customer> CreateCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer()
                 {
                      Id = 1,
                      FullName = "John Snow",
                      Address = "Bulgaria, Sofia, Mladost 3, bl.222, ap.7",
                      Gender = "Man",
                      PhoneNumber = "0888888887",
                      Email = "johns@mail.bg",
                      IdCardNumber = "12343567",
                      DriverLicenseNumber = "2222444567",
                      DateOfIssue = new DateTime(2016, 11, 17),
                      DateOfExpired = new DateTime(2026, 11, 17),
                      IssuedBy = "MVR Sofia"

                 },

                new Customer()
                 {
                      Id = 2,
                      FullName = "John Brown",
                      Address = "Bulgaria, Varna, ul.Pirin, bl.2, ap.3",
                      Gender = "Man",
                      PhoneNumber = "0888222287",
                      Email = "johnb@gmail.com",
                      IdCardNumber = "12223567",
                      DriverLicenseNumber = "2134244567",
                      DateOfIssue = new DateTime(2011, 10, 22),
                      DateOfExpired = new DateTime(2021, 10, 22),
                      IssuedBy = "MVR Varna"
                 }
            };

            return customers;
        }
    }

}
