using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Infraestructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class imgpacienteyusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoPerfil",
                table: "usuario",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "FotoPerfil",
                table: "paciente",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "paciente");
        }
    }
}
