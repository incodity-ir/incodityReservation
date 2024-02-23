using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace incodityReservation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeCityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Citys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2024, 2, 23, 10, 38, 28, 152, DateTimeKind.Local).AddTicks(5468), null });

            migrationBuilder.UpdateData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2024, 2, 23, 10, 38, 28, 152, DateTimeKind.Local).AddTicks(5485), null });

            migrationBuilder.UpdateData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl" },
                values: new object[] { new DateTime(2024, 2, 23, 10, 38, 28, 152, DateTimeKind.Local).AddTicks(5487), null });

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 23, 10, 38, 28, 152, DateTimeKind.Local).AddTicks(6632));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 23, 10, 38, 28, 152, DateTimeKind.Local).AddTicks(8041));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Citys");

            migrationBuilder.UpdateData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 16, 10, 57, 58, 439, DateTimeKind.Local).AddTicks(6471));

            migrationBuilder.UpdateData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 16, 10, 57, 58, 439, DateTimeKind.Local).AddTicks(6499));

            migrationBuilder.UpdateData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 16, 10, 57, 58, 439, DateTimeKind.Local).AddTicks(6501));

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 16, 10, 57, 58, 439, DateTimeKind.Local).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 16, 10, 57, 58, 440, DateTimeKind.Local).AddTicks(568));
        }
    }
}
