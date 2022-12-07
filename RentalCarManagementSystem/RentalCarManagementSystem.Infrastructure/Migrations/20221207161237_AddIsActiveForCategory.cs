using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCarManagementSystem.Infrastructure.Data.Migrations
{
    public partial class AddIsActiveForCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d86dba5034324ec481562264fecc1d3b",
                column: "ConcurrencyStamp",
                value: "669b0fae-195b-4d84-a333-5b334fb860e7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6e570fd-d889-4a67-a36a-0ecbe758bc2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a35ae420-7817-44b6-95a8-003629338243", "AQAAAAEAACcQAAAAEKnH1lpoBTrATL9YQnDfiOl+OLJcUechv6gkwLXWVt9hwjdVnZMMqkLdwx+CIFY7+w==", "1cefef7c-88db-49ca-851f-7baea7e52297" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3211a8d-efde-4a19-8087-79cde4679276",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adba9e1d-4fcc-4bb4-9c77-ba7e6dd0c52f", "AQAAAAEAACcQAAAAEAvcIte2Itj0/JmN5zHZpSxyu2H/JUjRWJ/9qp5RWUhalTQUoMvo7gnT/laNLkn4qA==", "42c1127a-1d14-4608-a804-a88fb6a7cbed" });
        }
    }
}
