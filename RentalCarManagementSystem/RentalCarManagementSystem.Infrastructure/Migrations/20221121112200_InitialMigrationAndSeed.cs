using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCarManagementSystem.Infrastructure.Data.Migrations
{
    public partial class InitialMigrationAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobPosition",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    IdCardNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DriverLicenseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfExpired = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    InsuranceCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfInsurance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CostPerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.InsuranceCode);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Make = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MakeYear = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GearBox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DailyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickUpDateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DropOffDateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PickUpLocationId = table.Column<int>(type: "int", nullable: false),
                    DropOffLocationId = table.Column<int>(type: "int", nullable: false),
                    InsuranceCode = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Insurances_InsuranceCode",
                        column: x => x.InsuranceCode,
                        principalTable: "Insurances",
                        principalColumn: "InsuranceCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Locations_DropOffLocationId",
                        column: x => x.DropOffLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Locations_PickUpLocationId",
                        column: x => x.PickUpLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "JobPosition", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c6e570fd-d889-4a67-a36a-0ecbe758bc2c", 0, null, "3171c8cc-1520-47c8-9247-97103c134342", "agent@mail.com", false, "Peter", null, null, "Brown", false, null, "AGENT@GMAIL.COM", "AGENT1", "AQAAAAEAACcQAAAAEOwbGjTZJepRxz8rET0jJHdMGFPX58Ay4L00UOOptr52cgrapNMz+lmDt1I0owsKrQ==", "1234567890", false, "0d5455f4-76a7-4d98-b3a8-e758a0a83f02", false, "Agent1" },
                    { "d3211a8d-efde-4a19-8087-79cde4679276", 0, null, "89e447bb-e5f4-45f6-aef9-62eb4d260084", "admin@gmail.com", false, "Peter", null, null, "Parker", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEPdxwqa1r+urkB7eAZ5avJT9RkWddub6fj6tew2ZMwkHMvE9QTFV5CSMHQG5E8YYvg==", "1234567890", false, "f4c88227-6584-4eb4-b402-590b63d28183", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Economy" },
                    { 2, "Compact" },
                    { 3, "Intermediate" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "DateOfExpired", "DateOfIssue", "DriverLicenseNumber", "Email", "FullName", "Gender", "IdCardNumber", "IssuedBy", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Bulgaria, Sofia, Mladost 3, bl.222, ap.7", new DateTime(2026, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "2222444567", "johns@mail.bg", "John Snow", "Man", "12343567", "MVR Sofia", "0888888887" },
                    { 2, "Bulgaria, Varna, ul.Pirin, bl.2, ap.3", new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2011, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "2134244567", "johnb@gmail.com", "John Brown", "Man", "12223567", "MVR Varna", "0888222287" }
                });

            migrationBuilder.InsertData(
                table: "Insurances",
                columns: new[] { "InsuranceCode", "CostPerDay", "TypeOfInsurance" },
                values: new object[,]
                {
                    { 1, 10m, "FullCoverage" },
                    { 2, 5m, "HalfCoverage" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "LocationName" },
                values: new object[,]
                {
                    { 1, "Bulgaria, Varna, 9000", "Varna Center" },
                    { 2, "Bulgaria, Varna, 9000", "Varna Airport" },
                    { 3, "Bulgaria, Sofia, 1000", "Sofia Airport" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Color", "DailyRate", "Description", "GearBox", "ImageUrl", "IsAvailable", "Make", "MakeYear", "Model", "RegNumber" },
                values: new object[] { 1, 3, "Black", 40m, "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment, sedan.", "Manual", "https://images.dealer.com/autodata/us/640/color/2022/USD20TOC041A0/209.jpg?_returnflight_id=091119126", true, "Toyota", 2022, "Corolla", "B1234AB" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Color", "DailyRate", "Description", "GearBox", "ImageUrl", "IsAvailable", "Make", "MakeYear", "Model", "RegNumber" },
                values: new object[] { 2, 1, "Grey", 33m, "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, no highest equipment.", "Manual", "https://s7g10.scene7.com/is/image/hyundaiautoever/BC3_5DR_TopTrim_DG01-01_EXT_front_rgb_v01_w3a-1:4x3?wid=960&hei=720&fmt=png-alpha&fit=wrap,1", true, "Hundai", 2022, "i20", "B1444CB" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Color", "DailyRate", "Description", "GearBox", "ImageUrl", "IsAvailable", "Make", "MakeYear", "Model", "RegNumber" },
                values: new object[] { 3, 2, "White", 37m, "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment.", "Automatic", "https://www.citroen-eg.com/wp-content/uploads/2021/11/Polar-White-front1.jpg", true, "Citroen", 2022, "C4", "B1223AB" });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "ApplicationUserId", "CarId", "CustomerId", "DropOffDateAndTime", "DropOffLocationId", "Duration", "InsuranceCode", "IsActive", "IsPaid", "PaymentType", "PickUpDateAndTime", "PickUpLocationId", "TotalAmount" },
                values: new object[] { 1, "d3211a8d-efde-4a19-8087-79cde4679276", 1, 1, new DateTime(2022, 11, 23, 6, 0, 0, 0, DateTimeKind.Unspecified), 1, 6, 1, true, false, "Card", new DateTime(2022, 11, 17, 5, 0, 0, 0, DateTimeKind.Unspecified), 1, 292m });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "ApplicationUserId", "CarId", "CustomerId", "DropOffDateAndTime", "DropOffLocationId", "Duration", "InsuranceCode", "IsActive", "IsPaid", "PaymentType", "PickUpDateAndTime", "PickUpLocationId", "TotalAmount" },
                values: new object[] { 2, "d3211a8d-efde-4a19-8087-79cde4679276", 2, 2, new DateTime(2022, 11, 20, 5, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 2, true, false, "BankTransfer", new DateTime(2022, 11, 17, 3, 0, 0, 0, DateTimeKind.Unspecified), 2, 114m });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ApplicationUserId",
                table: "Bookings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CarId",
                table: "Bookings",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DropOffLocationId",
                table: "Bookings",
                column: "DropOffLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_InsuranceCode",
                table: "Bookings",
                column: "InsuranceCode");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PickUpLocationId",
                table: "Bookings",
                column: "PickUpLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6e570fd-d889-4a67-a36a-0ecbe758bc2c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3211a8d-efde-4a19-8087-79cde4679276");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "JobPosition",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
