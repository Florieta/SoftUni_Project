using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCarManagementSystem.Infrastructure.Data.Migrations
{
    public partial class RoleAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d86dba5034324ec481562264fecc1d3b", "1cd9dec8-e39a-4688-8b2e-fb88c888de53", "Admin", "ADMIN" });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d86dba5034324ec481562264fecc1d3b", "d3211a8d-efde-4a19-8087-79cde4679276" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d86dba5034324ec481562264fecc1d3b", "d3211a8d-efde-4a19-8087-79cde4679276" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d86dba5034324ec481562264fecc1d3b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6e570fd-d889-4a67-a36a-0ecbe758bc2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3171c8cc-1520-47c8-9247-97103c134342", "AQAAAAEAACcQAAAAEOwbGjTZJepRxz8rET0jJHdMGFPX58Ay4L00UOOptr52cgrapNMz+lmDt1I0owsKrQ==", "0d5455f4-76a7-4d98-b3a8-e758a0a83f02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3211a8d-efde-4a19-8087-79cde4679276",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89e447bb-e5f4-45f6-aef9-62eb4d260084", "AQAAAAEAACcQAAAAEPdxwqa1r+urkB7eAZ5avJT9RkWddub6fj6tew2ZMwkHMvE9QTFV5CSMHQG5E8YYvg==", "f4c88227-6584-4eb4-b402-590b63d28183" });
        }
    }
}
