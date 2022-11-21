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
    internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {

        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasData(CreateBookings());
        }

        private List<Booking> CreateBookings()
        {
            var bookings = new List<Booking>()
            {
                new Booking()
                {
                     Id = 1,
                     PickUpDateAndTime = new DateTime(2022, 11, 17, 5, 0, 0),
                     DropOffDateAndTime = new DateTime(2022, 11, 23, 6, 0, 0),
                     Duration = 6,
                     PaymentType = "Card",
                     InsuranceCode = 1,
                     TotalAmount = 292,
                     IsActive = true,
                     IsPaid = false,
                     CarId = 1,
                     CustomerId = 1,
                     PickUpLocationId = 1,
                     DropOffLocationId = 1,
                     ApplicationUserId = "d3211a8d-efde-4a19-8087-79cde4679276"
                },
                new Booking()
                {
                     Id = 2,
                     PickUpDateAndTime = new DateTime(2022, 11, 17, 3, 0, 0),
                     DropOffDateAndTime = new DateTime(2022, 11, 20, 5, 0, 0),
                     Duration = 3,
                     PaymentType = "BankTransfer",
                     CarId = 2,
                     CustomerId = 2,
                     PickUpLocationId = 2,
                     DropOffLocationId = 2,
                     InsuranceCode = 2,
                     TotalAmount = 114,
                     IsActive = true,
                     IsPaid = false,
                     ApplicationUserId = "d3211a8d-efde-4a19-8087-79cde4679276"
                }
            };

            return bookings;
        }
    }
}

