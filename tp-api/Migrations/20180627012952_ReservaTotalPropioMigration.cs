using Microsoft.EntityFrameworkCore.Migrations;

namespace tpapi.Migrations
{
    public partial class ReservaTotalPropioMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalReservaPropia",
                table: "Reservas",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalReservaPropia",
                table: "Reservas");
        }
    }
}
