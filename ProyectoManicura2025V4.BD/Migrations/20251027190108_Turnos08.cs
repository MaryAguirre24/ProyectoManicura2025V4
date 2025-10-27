using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoManicura2025V4.BD.Migrations
{
    /// <inheritdoc />
    public partial class Turnos08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaTurno",
                table: "Turnos",
                newName: "FechaHora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaHora",
                table: "Turnos",
                newName: "FechaTurno");
        }
    }
}
