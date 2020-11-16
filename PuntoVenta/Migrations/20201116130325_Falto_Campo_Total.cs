using Microsoft.EntityFrameworkCore.Migrations;

namespace PuntoVenta.Migrations
{
    public partial class Falto_Campo_Total : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "SaleDetail",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "SaleDetail");
        }
    }
}
