using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace incodityReservation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDescPropToCityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Citys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2024, 2, 23, 10, 40, 55, 990, DateTimeKind.Local).AddTicks(4400), null });

            migrationBuilder.UpdateData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2024, 2, 23, 10, 40, 55, 990, DateTimeKind.Local).AddTicks(4419), null });

            migrationBuilder.UpdateData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2024, 2, 23, 10, 40, 55, 990, DateTimeKind.Local).AddTicks(4421), null });

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 23, 10, 40, 55, 990, DateTimeKind.Local).AddTicks(5535));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 23, 10, 40, 55, 990, DateTimeKind.Local).AddTicks(7027));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Citys");

            migrationBuilder.UpdateData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 23, 10, 38, 28, 152, DateTimeKind.Local).AddTicks(5468));

            migrationBuilder.UpdateData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 23, 10, 38, 28, 152, DateTimeKind.Local).AddTicks(5485));

            migrationBuilder.UpdateData(
                table: "Citys",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 2, 23, 10, 38, 28, 152, DateTimeKind.Local).AddTicks(5487));

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
    }
}
