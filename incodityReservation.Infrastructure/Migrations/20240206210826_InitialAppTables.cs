using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace incodityReservation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialAppTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citys_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Villas_Citys_CityId",
                        column: x => x.CityId,
                        principalTable: "Citys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2024, 2, 7, 0, 38, 26, 390, DateTimeKind.Local).AddTicks(5716), null, false, "اصفهان", null });

            migrationBuilder.InsertData(
                table: "Citys",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Name", "ProvinceId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 7, 0, 38, 26, 390, DateTimeKind.Local).AddTicks(4675), null, false, "چادگان", 1, null },
                    { 2, new DateTime(2024, 2, 7, 0, 38, 26, 390, DateTimeKind.Local).AddTicks(4696), null, false, "باغ بهادران", 1, null },
                    { 3, new DateTime(2024, 2, 7, 0, 38, 26, 390, DateTimeKind.Local).AddTicks(4698), null, false, "سمیرم", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Address", "CityId", "CreatedAt", "DeletedAt", "Description", "Image", "IsDeleted", "Name", "Price", "UpdatedAt" },
                values: new object[] { 1, "داخل مجموعه دست چپ", 2, new DateTime(2024, 2, 7, 0, 38, 26, 390, DateTimeKind.Local).AddTicks(7131), null, null, null, false, "ویلای A", 1000.0, null });

            migrationBuilder.CreateIndex(
                name: "IX_Citys_ProvinceId",
                table: "Citys",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Villas_CityId",
                table: "Villas",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Villas");

            migrationBuilder.DropTable(
                name: "Citys");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
