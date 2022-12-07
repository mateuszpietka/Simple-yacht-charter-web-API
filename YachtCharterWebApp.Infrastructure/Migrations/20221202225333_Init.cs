using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YachtCharterWebApp.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YachtTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YachtTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yachts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YachtTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    YearProduction = table.Column<short>(type: "smallint", nullable: false),
                    MaxPeople = table.Column<short>(type: "smallint", nullable: false),
                    RequiredPermission = table.Column<bool>(type: "bit", nullable: false),
                    HasEngine = table.Column<bool>(type: "bit", nullable: false),
                    EnginePower = table.Column<short>(type: "smallint", nullable: false),
                    NumberOfCabins = table.Column<short>(type: "smallint", nullable: false),
                    HomePort = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yachts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yachts_YachtTypes_YachtTypeId",
                        column: x => x.YachtTypeId,
                        principalTable: "YachtTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YachtId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Yachts_YachtId",
                        column: x => x.YachtId,
                        principalTable: "Yachts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_YachtId",
                table: "Reservations",
                column: "YachtId");

            migrationBuilder.CreateIndex(
                name: "IX_Yachts_YachtTypeId",
                table: "Yachts",
                column: "YachtTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Yachts");

            migrationBuilder.DropTable(
                name: "YachtTypes");
        }
    }
}
