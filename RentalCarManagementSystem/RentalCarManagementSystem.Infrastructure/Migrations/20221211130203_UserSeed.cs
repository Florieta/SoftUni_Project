using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCarManagementSystem.Infrastructure.Data.Migrations
{
    public partial class UserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d86dba5034324ec481562264fecc1d3b",
                column: "ConcurrencyStamp",
                value: "250e574b-0b67-4802-970d-946138d07923");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5af4facac8424694b91c57854ab6b598", "f0ea9044-6b57-4648-a577-8a1abb1400c9", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6e570fd-d889-4a67-a36a-0ecbe758bc2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "347ca437-3d99-4861-9c08-1dc984f76ef2", "AQAAAAEAACcQAAAAEHdc53FqUPi3HwDhmd8ilCJgICRAu5SSrys23huZVruTzz4LT8eiKf5U4aZs2pHIeQ==", "3e280194-75f1-471c-967b-a2aa5f55e7de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3211a8d-efde-4a19-8087-79cde4679276",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87d1ce74-ac1d-4478-912c-e5308622825a", "AQAAAAEAACcQAAAAENiWMOAqDULTHLpn419doR7CqNXHaMDTdjMbz20U30PNSlFo6rEVZPV987iybPqoYQ==", "4a2642a5-9583-4e62-9238-4053e573c534" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DropOffDateAndTime", "PickUpDateAndTime" },
                values: new object[] { new DateTime(2022, 12, 24, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 18, 5, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DropOffDateAndTime", "IsPaid", "IsRented", "PickUpDateAndTime" },
                values: new object[] { new DateTime(2022, 12, 18, 5, 0, 0, 0, DateTimeKind.Unspecified), true, true, new DateTime(2022, 12, 15, 3, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5af4facac8424694b91c57854ab6b598", "c6e570fd-d889-4a67-a36a-0ecbe758bc2c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5af4facac8424694b91c57854ab6b598", "c6e570fd-d889-4a67-a36a-0ecbe758bc2c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5af4facac8424694b91c57854ab6b598");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d86dba5034324ec481562264fecc1d3b",
                column: "ConcurrencyStamp",
                value: "1ee8340f-7b7f-4cb1-ab9b-3e64676da165");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6e570fd-d889-4a67-a36a-0ecbe758bc2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6a4eed8-24ff-47d5-bc30-365a23dc1a18", "AQAAAAEAACcQAAAAEHRe7LtbTc7Z8C6d90F9HTyNf8gPQCm9YyTJzA1x/4NlZwPviPHajoFIdTTXGg3ebQ==", "e3ba3b23-aaa1-4732-8396-3162e3241a0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3211a8d-efde-4a19-8087-79cde4679276",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68eb2800-18ca-4ff7-a787-f875687d92ea", "AQAAAAEAACcQAAAAEISjnr8elFFsrEEeeTaqyImf0qn8gDHPQy/SiG/rlJ4PkZRF95qgC8iaAogj6Zk0DA==", "81cfb432-b0e9-4d16-bbe1-4a2b68cc3393" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DropOffDateAndTime", "PickUpDateAndTime" },
                values: new object[] { new DateTime(2022, 11, 23, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 17, 5, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DropOffDateAndTime", "IsPaid", "IsRented", "PickUpDateAndTime" },
                values: new object[] { new DateTime(2022, 11, 20, 5, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2022, 11, 17, 3, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
