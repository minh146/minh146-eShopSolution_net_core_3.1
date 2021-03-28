using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedIdentityfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3659c77-af0e-45ef-b1ea-6ba64a6af6d5"),
                column: "ConcurrencyStamp",
                value: "66ab48f5-eeb9-4788-b104-97c2e6958b67");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8cd00622-4da5-4b2f-a522-7d8a0733a389"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "9abd152f-cc86-410d-a20a-f3249282ffc5", "duongquangminh0410@gmail.com", "duongquangminh0410@gmail.com", "AQAAAAEAACcQAAAAEB9MoQx+bEC7k5KNzJZesqZkYj+Wq6R29n7S3wsIEh+YFBbRfaE69nGm6ETFkfdLNQ==" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3659c77-af0e-45ef-b1ea-6ba64a6af6d5"),
                column: "ConcurrencyStamp",
                value: "20b132f1-762b-4e7f-a03f-43c769589768");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("8cd00622-4da5-4b2f-a522-7d8a0733a389"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "6e21a682-082d-4e45-b218-f6b0cca49d9a", "tedu.international@gmail.com", "tedu.international@gmail.com", "AQAAAAEAACcQAAAAEOwKVkVNdF67WcO7WlDUo3wlL4AZmt5B/wQ6cm7StPvuIveuKWhVDsKdUJ9dJFrACg==" });

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
    }
}
