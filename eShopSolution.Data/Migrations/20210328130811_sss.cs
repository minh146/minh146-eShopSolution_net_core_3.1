using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class sss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e89652a3-c138-4039-82b9-46f13c9cf14d"),
                column: "ConcurrencyStamp",
                value: "69c081e4-1b7c-4848-aa70-d8b0acc2cba7");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("73099107-55d9-41ab-8514-e10648a2f80a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e6f75a29-eb50-4e26-bc8b-9afbca429262", "AQAAAAEAACcQAAAAENn1XzR1a0sYdAmRpfxN4B6KaDNv1HKV8FmHRbb6U3ZhMrquzZ+OYeMEY0JtPDZzcA==" });

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
    }
}
