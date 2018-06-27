using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tpapi.Migrations
{
    public partial class FechaCancelacionReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCancelacion",
                table: "Reservas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCancelacion",
                table: "Reservas");
        }
    }
}
