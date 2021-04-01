using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class ChangeFileLengthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImage",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e89652a3-c138-4039-82b9-46f13c9cf14d"),
                column: "ConcurrencyStamp",
                value: "cbc44d57-e751-4994-9737-dd1c9cdbace6");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("73099107-55d9-41ab-8514-e10648a2f80a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "544c39ad-087c-4b92-b523-290d9b0d0648", "AQAAAAEAACcQAAAAEFgYol6kcMP6k/pJfsTvPt7Q3u4Z9MvAHuORK9Csfj2C8Z2BrypxXA8+XK0quYkA5A==" });

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
                values: new object[] { new DateTime(2021, 3, 29, 15, 17, 20, 525, DateTimeKind.Local).AddTicks(5222), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImage",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e89652a3-c138-4039-82b9-46f13c9cf14d"),
                column: "ConcurrencyStamp",
                value: "0d58d6d0-f1f8-4fc6-8396-db1a42e45a7c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("73099107-55d9-41ab-8514-e10648a2f80a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dabc9d81-b78e-4a3b-a439-65199245676d", "AQAAAAEAACcQAAAAEL76SH/4LjJBKMKo2hhMly8794qnItoxKazDzi9c62GHAD3JPY4DbCm37/QX4xqodw==" });

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
                values: new object[] { new DateTime(2021, 3, 28, 20, 8, 11, 348, DateTimeKind.Local).AddTicks(7748), 0 });
        }
    }
}
