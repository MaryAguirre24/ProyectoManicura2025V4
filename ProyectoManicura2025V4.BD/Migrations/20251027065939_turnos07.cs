using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoManicura2025V4.BD.Migrations
{
    /// <inheritdoc />
    public partial class turnos07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdServicio",
                table: "Turnos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdServicio",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
