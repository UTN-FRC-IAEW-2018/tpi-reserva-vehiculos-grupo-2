using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tpapi.Migrations
{
    public partial class ReservasMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExtId = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    FechaDevolucion = table.Column<DateTime>(nullable: false),
                    FechaRetiro = table.Column<DateTime>(nullable: false),
                    LugarRetiro = table.Column<string>(nullable: true),
                    LugarDevolucion = table.Column<string>(nullable: true),
                    TotalReserva = table.Column<decimal>(nullable: false),
                    VehiculoXCiudadId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DNI = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");
        }
    }
}
