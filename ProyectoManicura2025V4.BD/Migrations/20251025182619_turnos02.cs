using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoManicura2025V4.BD.Migrations
{
    /// <inheritdoc />
    public partial class turnos02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Servicios",
                newName: "NombreServicio");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Clientes",
                newName: "NombreCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreServicio",
                table: "Servicios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "NombreCliente",
                table: "Clientes",
                newName: "Nombre");
        }
    }
}
