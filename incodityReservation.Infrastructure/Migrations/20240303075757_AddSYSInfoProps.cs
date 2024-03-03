using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace incodityReservation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSYSInfoProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "CreateByIpAddress",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByBrowser",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateByIpAddress",
                table: "Provinces",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByBrowser",
                table: "Provinces",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateByIpAddress",
                table: "ImageLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByBrowser",
                table: "ImageLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateByIpAddress",
                table: "Citys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByBrowser",
                table: "Citys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateByIpAddress",
                table: "Villas");

            migrationBuilder.DropColumn(
                name: "CreatedByBrowser",
                table: "Villas");

            migrationBuilder.DropColumn(
                name: "CreateByIpAddress",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "CreatedByBrowser",
                table: "Provinces");

            migrationBuilder.DropColumn(
                name: "CreateByIpAddress",
                table: "ImageLibraries");

            migrationBuilder.DropColumn(
                name: "CreatedByBrowser",
                table: "ImageLibraries");

            migrationBuilder.DropColumn(
                name: "CreateByIpAddress",
                table: "Citys");

            migrationBuilder.DropColumn(
                name: "CreatedByBrowser",
                table: "Citys");

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2024, 3, 1, 9, 51, 5, 670, DateTimeKind.Local).AddTicks(1284), null, false, "اصفهان", null });

            migrationBuilder.InsertData(
                table: "Citys",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "ImageUrl", "IsDeleted", "Name", "ProvinceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 1, 9, 51, 5, 669, DateTimeKind.Local).AddTicks(7024), null, null, null, false, "چادگان", 1, null },
                    { 2, new DateTime(2024, 3, 1, 9, 51, 5, 669, DateTimeKind.Local).AddTicks(7041), null, null, null, false, "باغ بهادران", 1, null },
                    { 3, new DateTime(2024, 3, 1, 9, 51, 5, 669, DateTimeKind.Local).AddTicks(7043), null, null, null, false, "سمیرم", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Address", "CityId", "CreatedAt", "DeletedAt", "Description", "ExpireDate", "ImageBytes", "IsDeleted", "Name", "Price", "StartDate", "UpdatedAt" },
                values: new object[] { 1, "داخل مجموعه دست چپ", 2, new DateTime(2024, 3, 1, 9, 51, 5, 670, DateTimeKind.Local).AddTicks(2647), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "ویلای A", 1000.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }
    }
}
