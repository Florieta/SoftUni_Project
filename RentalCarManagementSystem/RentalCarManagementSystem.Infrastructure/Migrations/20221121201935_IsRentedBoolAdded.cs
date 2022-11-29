using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCarManagementSystem.Infrastructure.Data.Migrations
{
    public partial class IsRentedBoolAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRented",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d86dba5034324ec481562264fecc1d3b",
                column: "ConcurrencyStamp",
                value: "08d61a34-8837-476c-9c65-051e74aaf273");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6e570fd-d889-4a67-a36a-0ecbe758bc2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48b4a2fd-3edc-4513-ac48-e8c2c69e4c7e", "AQAAAAEAACcQAAAAEBNJ/joU34rH6IfSeZGeK3Db97+B5agy0tuNiaoRgs/XHVcr6h6nVnjv7YWsjABYiQ==", "9516fd36-f5b9-4816-8483-8e92c426eb14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3211a8d-efde-4a19-8087-79cde4679276",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70c7cb1d-f6b1-4888-8924-06dd7bb08582", "AQAAAAEAACcQAAAAELLVz3OonzHrryFSil7qavk2JlJ4CoOQqyO8O86scr68e/ABRM4YNFgYh7+NihUrvQ==", "88db10c1-50ee-4579-b984-d54969e967d3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRented",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d86dba5034324ec481562264fecc1d3b",
                column: "ConcurrencyStamp",
                value: "1cd9dec8-e39a-4688-8b2e-fb88c888de53");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6e570fd-d889-4a67-a36a-0ecbe758bc2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23e07114-6567-49fb-9c07-f0b9d523850e", "AQAAAAEAACcQAAAAECn9BvIFIP0FM3SaJWXop0LQNZdiXJ7xRBgtcUfNZxDL3rnOkzmkKEKrtPeuVoC7ng==", "4984c448-3429-4637-b95e-086d26ed2815" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3211a8d-efde-4a19-8087-79cde4679276",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5d7b6ab-a665-4b5f-904e-40a857e5e64f", "AQAAAAEAACcQAAAAEOS0W3gqyHg4y10L+++lzH6JBhBl/6klVKZ2+8OwGGGVfSCfxjZ5Z5RVdinvNtNDsw==", "69571ed0-8ae3-4b5b-9f95-e9c6c6dc6401" });
        }
    }
}
