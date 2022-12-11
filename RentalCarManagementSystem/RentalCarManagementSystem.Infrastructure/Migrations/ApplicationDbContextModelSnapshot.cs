﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentalCarManagementSystem.Infrastructure.Data;

#nullable disable

namespace RentalCarManagementSystem.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "d86dba5034324ec481562264fecc1d3b",
                            ConcurrencyStamp = "250e574b-0b67-4802-970d-946138d07923",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "5af4facac8424694b91c57854ab6b598",
                            ConcurrencyStamp = "f0ea9044-6b57-4648-a577-8a1abb1400c9",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "d3211a8d-efde-4a19-8087-79cde4679276",
                            RoleId = "d86dba5034324ec481562264fecc1d3b"
                        },
                        new
                        {
                            UserId = "c6e570fd-d889-4a67-a36a-0ecbe758bc2c",
                            RoleId = "5af4facac8424694b91c57854ab6b598"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RentalCarManagementSystem.Infrastructure.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DropOffDateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DropOffLocationId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("InsuranceCode")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRented")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PickUpDateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PickUpLocationId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DropOffLocationId");

                    b.HasIndex("InsuranceCode");

                    b.HasIndex("PickUpLocationId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationUserId = "d3211a8d-efde-4a19-8087-79cde4679276",
                            CarId = 1,
                            CustomerId = 1,
                            DropOffDateAndTime = new DateTime(2022, 12, 24, 6, 0, 0, 0, DateTimeKind.Unspecified),
                            DropOffLocationId = 1,
                            Duration = 6,
                            InsuranceCode = 1,
                            IsActive = true,
                            IsPaid = false,
                            IsRented = false,
                            PaymentType = "Card",
                            PickUpDateAndTime = new DateTime(2022, 12, 18, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            PickUpLocationId = 1,
                            TotalAmount = 292m
                        },
                        new
                        {
                            Id = 2,
                            ApplicationUserId = "d3211a8d-efde-4a19-8087-79cde4679276",
                            CarId = 2,
                            CustomerId = 2,
                            DropOffDateAndTime = new DateTime(2022, 12, 18, 5, 0, 0, 0, DateTimeKind.Unspecified),
                            DropOffLocationId = 2,
                            Duration = 3,
                            InsuranceCode = 2,
                            IsActive = true,
                            IsPaid = true,
                            IsRented = true,
                            PaymentType = "BankTransfer",
                            PickUpDateAndTime = new DateTime(2022, 12, 15, 3, 0, 0, 0, DateTimeKind.Unspecified),
                            PickUpLocationId = 2,
                            TotalAmount = 114m
                        });
                });

            modelBuilder.Entity("RentalCarManagementSystem.Infrastructure.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("DailyRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GearBox")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("MakeYear")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("NotInUse")
                        .HasColumnType("bit");

                    b.Property<string>("RegNumber")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 3,
                            Color = "Black",
                            DailyRate = 40m,
                            Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment, sedan.",
                            GearBox = "Manual",
                            ImageUrl = "https://images.dealer.com/autodata/us/640/color/2022/USD20TOC041A0/209.jpg?_returnflight_id=091119126",
                            IsAvailable = true,
                            Make = "Toyota",
                            MakeYear = 2022,
                            Model = "Corolla",
                            NotInUse = false,
                            RegNumber = "B1234AB"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Color = "Grey",
                            DailyRate = 33m,
                            Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, no highest equipment.",
                            GearBox = "Manual",
                            ImageUrl = "https://s7g10.scene7.com/is/image/hyundaiautoever/BC3_5DR_TopTrim_DG01-01_EXT_front_rgb_v01_w3a-1:4x3?wid=960&hei=720&fmt=png-alpha&fit=wrap,1",
                            IsAvailable = true,
                            Make = "Hundai",
                            MakeYear = 2022,
                            Model = "i20",
                            NotInUse = false,
                            RegNumber = "B1444CB"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Color = "White",
                            DailyRate = 37m,
                            Description = "There are 5 doors, 5 seats, an air-condition, used fuel is petrol, highest equipment.",
                            GearBox = "Automatic",
                            ImageUrl = "https://www.citroen-eg.com/wp-content/uploads/2021/11/Polar-White-front1.jpg",
                            IsAvailable = true,
                            Make = "Citroen",
                            MakeYear = 2022,
                            Model = "C4",
                            NotInUse = false,
                            RegNumber = "B1223AB"
                        });
                });

            modelBuilder.Entity("RentalCarManagementSystem.Infrastructure.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Economy",
                            IsActive = true
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Compact",
                            IsActive = true
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Intermediate",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("RentalCarManagementSystem.Infrastructure.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime>("DateOfExpired")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<string>("DriverLicenseNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdCardNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("IssuedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Bulgaria, Sofia, Mladost 3, bl.222, ap.7",
                            DateOfExpired = new DateTime(2026, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfIssue = new DateTime(2016, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DriverLicenseNumber = "2222444567",
                            Email = "johns@mail.bg",
                            FullName = "John Snow",
                            Gender = "Man",
                            IdCardNumber = "12343567",
                            IssuedBy = "MVR Sofia",
                            PhoneNumber = "0888888887"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Bulgaria, Varna, ul.Pirin, bl.2, ap.3",
                            DateOfExpired = new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfIssue = new DateTime(2011, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DriverLicenseNumber = "2134244567",
                            Email = "johnb@gmail.com",
                            FullName = "John Brown",
                            Gender = "Man",
                            IdCardNumber = "12223567",
                            IssuedBy = "MVR Varna",
                            PhoneNumber = "0888222287"
                        });
                });

            modelBuilder.Entity("RentalCarManagementSystem.Infrastructure.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "d3211a8d-efde-4a19-8087-79cde4679276",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "87d1ce74-ac1d-4478-912c-e5308622825a",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Peter",
                            LastName = "Parker",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAENiWMOAqDULTHLpn419doR7CqNXHaMDTdjMbz20U30PNSlFo6rEVZPV987iybPqoYQ==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4a2642a5-9583-4e62-9238-4053e573c534",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "c6e570fd-d889-4a67-a36a-0ecbe758bc2c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "347ca437-3d99-4861-9c08-1dc984f76ef2",
                            Email = "agent@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Peter",
                            LastName = "Brown",
                            LockoutEnabled = false,
                            NormalizedEmail = "AGENT@GMAIL.COM",
                            NormalizedUserName = "AGENT1",
                            PasswordHash = "AQAAAAEAACcQAAAAEHdc53FqUPi3HwDhmd8ilCJgICRAu5SSrys23huZVruTzz4LT8eiKf5U4aZs2pHIeQ==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3e280194-75f1-471c-967b-a2aa5f55e7de",
                            TwoFactorEnabled = false,
                            UserName = "Agent1"
                        });
                });

            modelBuilder.Entity("RentalCarManagementSystem.Infrastructure.Models.Insurance", b =>
                {
                    b.Property<int>("InsuranceCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InsuranceCode"), 1L, 1);

                    b.Property<decimal>("CostPerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("TypeOfInsurance")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InsuranceCode");

                    b.ToTable("Insurances");

                    b.HasData(
                        new
                        {
                            InsuranceCode = 1,
                            CostPerDay = 10m,
                            IsActive = true,
                            TypeOfInsurance = "FullCoverage"
                        },
                        new
                        {
                            InsuranceCode = 2,
                            CostPerDay = 5m,
                            IsActive = true,
                            TypeOfInsurance = "HalfCoverage"
                        });
                });

            modelBuilder.Entity("RentalCarManagementSystem.Infrastructure.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Bulgaria, Varna, 9000",
                            IsActive = true,
                            LocationName = "Varna Center"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Bulgaria, Varna, 9000",
                            IsActive = true,
                            LocationName = "Varna Airport"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Bulgaria, Sofia, 1000",
                            IsActive = true,
                            LocationName = "Sofia Airport"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RentalCarManagementSystem.Infrastructure.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RentalCarManagementSystem.Infrastructure.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalCarManagementSystem.Infrastructure.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RentalCarManagementSystem.Infrastructure.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentalCarManagementSystem.Infrastructure.Models.Booking", b =>
                {
                    b.HasOne("RentalCarManagementSystem.Infrastructure.Models.Identity.ApplicationUser", "ApplicationUser")
                        .WithMany("Bookings")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalCarManagementSystem.Infrastructure.Models.Car", "Car")
                        .WithMany("Bookings")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalCarManagementSystem.Infrastructure.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalCarManagementSystem.Infrastructure.Models.Location", "DropOffLocation")
                        .WithMany("DropOffBookings")
                        .HasForeignKey("DropOffLocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RentalCarManagementSystem.Infrastructure.Models.Insurance", "Insurance")
                        .WithMany("Bookings")
                        .HasForeignKey("InsuranceCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalCarManagementSystem.Infrastructure.Models.Location", "PickUpLocation")
                        .WithMany("PickUpBookings")
                        .HasForeignKey("PickUpLocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Car");

                    b.Navigation("Customer");

                    b.Navigation("DropOffLocation");

                    b.Navigation("Insurance");

                    b.Navigation("PickUpLocation");
                });

            modelBuilder.Entity("RentalCarManagementSystem.Infrastructure.Models.Car", b =>
                {
                    b.HasOne("RentalCarManagementSystem.Infrastructure.Models.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RentalCarManagementSystem.Infrastructure.Models.Car", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("RentalCarManagementSystem.Infrastructure.Models.Category", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("RentalCarManagementSystem.Infrastructure.Models.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("RentalCarManagementSystem.Infrastructure.Models.Identity.ApplicationUser", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("RentalCarManagementSystem.Infrastructure.Models.Insurance", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("RentalCarManagementSystem.Infrastructure.Models.Location", b =>
                {
                    b.Navigation("DropOffBookings");

                    b.Navigation("PickUpBookings");
                });
#pragma warning restore 612, 618
        }
    }
}
