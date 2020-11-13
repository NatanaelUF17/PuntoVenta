using Microsoft.EntityFrameworkCore.Migrations;

namespace PuntoVenta.Migrations
{
    public partial class Cambio_Nombre_Campos_Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SaleDate",
                table: "Sale",
                newName: "Date");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "SaleDetail",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "SaleDetail");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Sale",
                newName: "SaleDate");
        }
    }
}
