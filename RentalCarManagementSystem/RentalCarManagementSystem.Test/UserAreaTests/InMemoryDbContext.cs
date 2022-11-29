using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RentalCarManagementSystem.Infrastructure.Data;


namespace RentalCarManagementSystem.Test.UserAreaTests
{
    public class InMemoryDbContext
    {
        private readonly SqliteConnection connection;
        private readonly DbContextOptions<ApplicationDbContext> dbContextOptions;

        public InMemoryDbContext()
        {
            connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connection)
                .Options;

            using var context = new ApplicationDbContext(dbContextOptions);

            context.Database.EnsureCreated();
        }

        public ApplicationDbContext CreateContext() => new ApplicationDbContext(dbContextOptions);


        public void Dispose() => connection.Dispose();
    }
}
