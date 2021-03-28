using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("b3659c77-af0e-45ef-b1ea-6ba64a6af6d5"), "20b132f1-762b-4e7f-a03f-43c769589768", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("8cd00622-4da5-4b2f-a522-7d8a0733a389"), new Guid("b3659c77-af0e-45ef-b1ea-6ba64a6af6d5") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8cd00622-4da5-4b2f-a522-7d8a0733a389"), 0, "6e21a682-082d-4e45-b218-f6b0cca49d9a", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "duongquangminh0410@gmail.com", true, "Duong", "Minh", false, null, "duongquangminh0410@gmail.com", "admin", "AQAAAAEAACcQAAAAEOwKVkVNdF67WcO7WlDUo3wlL4AZmt5B/wQ6cm7StPvuIveuKWhVDsKdUJ9dJFrACg==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DateCreated", "ViewCount" },
                values: new object[] { new DateTime(2021, 3, 25, 15, 33, 55, 802, DateTimeKind.Local).AddTicks(7439), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3659c77-af0e-45ef-b1ea-6ba64a6af6d5"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("8cd00622-4da5-4b2f-a522-7d8a0733a389"), new Guid("b3659c77-af0e-45ef-b1ea-6ba64a6af6d5") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8cd00622-4da5-4b2f-a522-7d8a0733a389"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DateCreated", "ViewCount" },
                values: new object[] { new DateTime(2021, 3, 17, 16, 36, 11, 922, DateTimeKind.Local).AddTicks(4719), 0 });
        }
    }
}
