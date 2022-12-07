using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCarManagementSystem.Infrastructure.Data.Migrations
{
    public partial class AddIsActiveForLocationAndInsurance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Locations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Insurances",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "InsuranceCode",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Insurances",
                keyColumn: "InsuranceCode",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Insurances");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d86dba5034324ec481562264fecc1d3b",
                column: "ConcurrencyStamp",
                value: "1227c39d-9f2b-4eda-bbaa-aff2b61dd135");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6e570fd-d889-4a67-a36a-0ecbe758bc2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c0204cd-5c7d-4288-beed-6744280c1ff5", "AQAAAAEAACcQAAAAEEFl1Oox1OtTHiZDi4VgHS922kk8Ag/vQaK5Bmgrk/kK1ChyQJWFnN0Z+dp9iU2aAA==", "879bbb4c-7760-4401-83fe-1d89eea05765" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3211a8d-efde-4a19-8087-79cde4679276",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ed2b685-7f3c-4dfa-bca1-a0a690a8351a", "AQAAAAEAACcQAAAAEL5fEY4YbuEpzr+GJxvZ5PABD/vjBAaFbzaJeTNs+LZHXKGEbs35jebBk7Cr/MRUkQ==", "9acd49ac-5837-4739-b60c-994076bcc0df" });
        }
    }
}
