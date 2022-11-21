using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalCarManagementSystem.Infrastructure.Data.Configuration;
using RentalCarManagementSystem.Infrastructure.Models;
using RentalCarManagementSystem.Infrastructure.Models.Identity;

namespace RentalCarManagementSystem.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; init; } = null!;
        public DbSet<Car> Cars { get; init; } = null!;
        public DbSet<Category> Categories { get; init; } = null!;

        public DbSet<Customer> Customers { get; init; } = null!;

        public DbSet<Location> Locations { get; init; } = null!;
        public DbSet<Insurance> Insurances { get; init; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new BookingConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());
            builder.ApplyConfiguration(new InsuranceConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());

            builder.Entity<Booking>(e =>
            {
                e.HasOne(t => t.PickUpLocation)
                    .WithMany(c => c.PickUpBookings)
                    .HasForeignKey(t => t.PickUpLocationId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(t => t.DropOffLocation)
                    .WithMany(c => c.DropOffBookings)
                    .HasForeignKey(t => t.DropOffLocationId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(builder);
        }
    }
}