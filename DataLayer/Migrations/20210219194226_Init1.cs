using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    T = table.Column<double>(type: "float", nullable: false),
                    Humidity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Td = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pressure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WindDir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WindSpeed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cloudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    H = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conditions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data");
        }
    }
}
