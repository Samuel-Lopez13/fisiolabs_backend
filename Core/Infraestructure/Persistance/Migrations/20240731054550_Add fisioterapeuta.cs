using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Core.Infraestructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Addfisioterapeuta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ValorX",
                table: "mapa_corporal",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RangoDolor",
                table: "mapa_corporal",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CedulaProfesional",
                table: "fisioterapeuta",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "fisioterapeuta",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EspecialidadId",
                table: "fisioterapeuta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "fisioterapeuta",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "fisioterapeuta",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MotivoAlta",
                table: "diagnostico",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    EspecialidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EspecialidadTxt = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.EspecialidadId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "correo",
                table: "fisioterapeuta",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "especialidad_id",
                table: "fisioterapeuta",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "paciente_id2",
                table: "fisioterapeuta",
                column: "CedulaProfesional",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "telefono",
                table: "fisioterapeuta",
                column: "Telefono",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "especialidad_ibfk_1",
                table: "fisioterapeuta",
                column: "EspecialidadId",
                principalTable: "Especialidad",
                principalColumn: "EspecialidadId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "especialidad_ibfk_1",
                table: "fisioterapeuta");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropIndex(
                name: "correo",
                table: "fisioterapeuta");

            migrationBuilder.DropIndex(
                name: "especialidad_id",
                table: "fisioterapeuta");

            migrationBuilder.DropIndex(
                name: "paciente_id2",
                table: "fisioterapeuta");

            migrationBuilder.DropIndex(
                name: "telefono",
                table: "fisioterapeuta");

            migrationBuilder.DropColumn(
                name: "CedulaProfesional",
                table: "fisioterapeuta");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "fisioterapeuta");

            migrationBuilder.DropColumn(
                name: "EspecialidadId",
                table: "fisioterapeuta");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "fisioterapeuta");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "fisioterapeuta");

            migrationBuilder.AlterColumn<int>(
                name: "ValorX",
                table: "mapa_corporal",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<int>(
                name: "RangoDolor",
                table: "mapa_corporal",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "MotivoAlta",
                table: "diagnostico",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);
        }
    }
}
