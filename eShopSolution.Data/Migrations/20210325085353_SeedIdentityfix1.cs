using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedIdentityfix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("e89652a3-c138-4039-82b9-46f13c9cf14d"), "69c081e4-1b7c-4848-aa70-d8b0acc2cba7", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("73099107-55d9-41ab-8514-e10648a2f80a"), new Guid("e89652a3-c138-4039-82b9-46f13c9cf14d") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("73099107-55d9-41ab-8514-e10648a2f80a"), 0, "e6f75a29-eb50-4e26-bc8b-9afbca429262", new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "duongquangminh0410@gmail.com", true, "Duong", "Minh", false, null, "duongquangminh0410@gmail.com", "admin", "AQAAAAEAACcQAAAAENn1XzR1a0sYdAmRpfxN4B6KaDNv1HKV8FmHRbb6U3ZhMrquzZ+OYeMEY0JtPDZzcA==", null, false, "", false, "admin" });

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
                values: new object[] { new DateTime(2021, 3, 25, 15, 53, 53, 268, DateTimeKind.Local).AddTicks(2250), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e89652a3-c138-4039-82b9-46f13c9cf14d"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("73099107-55d9-41ab-8514-e10648a2f80a"), new Guid("e89652a3-c138-4039-82b9-46f13c9cf14d") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("73099107-55d9-41ab-8514-e10648a2f80a"));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("b3659c77-af0e-45ef-b1ea-6ba64a6af6d5"), "66ab48f5-eeb9-4788-b104-97c2e6958b67", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("8cd00622-4da5-4b2f-a522-7d8a0733a389"), new Guid("b3659c77-af0e-45ef-b1ea-6ba64a6af6d5") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8cd00622-4da5-4b2f-a522-7d8a0733a389"), 0, "9abd152f-cc86-410d-a20a-f3249282ffc5", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "duongquangminh0410@gmail.com", true, "Duong", "Minh", false, null, "duongquangminh0410@gmail.com", "admin", "AQAAAAEAACcQAAAAEB9MoQx+bEC7k5KNzJZesqZkYj+Wq6R29n7S3wsIEh+YFBbRfaE69nGm6ETFkfdLNQ==", null, false, "", false, "admin" });

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
                values: new object[] { new DateTime(2021, 3, 25, 15, 49, 41, 437, DateTimeKind.Local).AddTicks(6923), 0 });
        }
    }
}
