using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoManicura2025V4.BD.Migrations
{
    /// <inheritdoc />
    public partial class Turnos05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreCliente",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "NombreServicio",
                table: "Turnos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreCliente",
                table: "Turnos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreServicio",
                table: "Turnos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
