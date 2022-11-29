using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCarManagementSystem.Infrastructure.Data.Migrations
{
    public partial class NotInUseColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NotInUse",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotInUse",
                table: "Cars");

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
    }
}
