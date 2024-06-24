using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Infraestructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class todorelacionadoaexpediente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "expediente_ibfk_1",
                table: "expediente");

            migrationBuilder.DropForeignKey(
                name: "gineco_obstetrico_ibfk_1",
                table: "gineco_obstetrico");

            migrationBuilder.DropForeignKey(
                name: "gineco_obstetrico_ibfk_2",
                table: "gineco_obstetrico");

            migrationBuilder.DropForeignKey(
                name: "gineco_obstetrico_ibfk_3",
                table: "gineco_obstetrico");

            migrationBuilder.DropForeignKey(
                name: "heredo_familiar_ibfk_1",
                table: "heredo_familiar");

            migrationBuilder.DropForeignKey(
                name: "no_patologico_ibfk_1",
                table: "no_patologico");

            migrationBuilder.DropForeignKey(
                name: "paciente_ibfk_1",
                table: "paciente");

            migrationBuilder.DropIndex(
                name: "expedediente_id3",
                table: "no_patologico");

            migrationBuilder.DropIndex(
                name: "expedediente_id2",
                table: "heredo_familiar");

            migrationBuilder.DropIndex(
                name: "expedediente_id1",
                table: "gineco_obstetrico");

            migrationBuilder.DropIndex(
                name: "paciente_id1",
                table: "expediente");

            migrationBuilder.AlterColumn<string>(
                name: "tipo_anticonceptivo",
                table: "tipo_anticonceptivo",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "telefono",
                table: "paciente",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "sexo",
                table: "paciente",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ocupacion",
                table: "paciente",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "paciente",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "institucion",
                table: "paciente",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "estado_civil_id",
                table: "paciente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "edad",
                table: "paciente",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "domicilio",
                table: "paciente",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "codigo_postal",
                table: "paciente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "medio_sociocultural",
                table: "no_patologico",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "medio_laboral",
                table: "no_patologico",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "medio_fisicoambiental",
                table: "no_patologico",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "expedediente_id",
                table: "no_patologico",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "padres_vivos",
                table: "heredo_familiar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "padres",
                table: "heredo_familiar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "hijos_vivos",
                table: "heredo_familiar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "hijos",
                table: "heredo_familiar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "hermanos_vivos",
                table: "heredo_familiar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "hermanos",
                table: "heredo_familiar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "expedediente_id",
                table: "heredo_familiar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tipo_anticonceptivo_id",
                table: "gineco_obstetrico",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "expedediente_id",
                table: "gineco_obstetrico",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "flujo_vaginal",
                table: "flujo_vaginal",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "tipo_interrogatorio",
                table: "expediente",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "responsable",
                table: "expediente",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "paciente_id",
                table: "expediente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "antecedentes_patologicos",
                table: "expediente",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "estado_civil",
                table: "estado_civil",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "motivo",
                table: "citas",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "expedediente_id3",
                table: "no_patologico",
                column: "expedediente_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "expedediente_id2",
                table: "heredo_familiar",
                column: "expedediente_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "expedediente_id1",
                table: "gineco_obstetrico",
                column: "expedediente_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "paciente_id1",
                table: "expediente",
                column: "paciente_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "expediente_ibfk_1",
                table: "expediente",
                column: "paciente_id",
                principalTable: "paciente",
                principalColumn: "paciente_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "gineco_obstetrico_ibfk_1",
                table: "gineco_obstetrico",
                column: "flujo_vaginal_id",
                principalTable: "flujo_vaginal",
                principalColumn: "flujo_vaginal_id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "gineco_obstetrico_ibfk_2",
                table: "gineco_obstetrico",
                column: "tipo_anticonceptivo_id",
                principalTable: "tipo_anticonceptivo",
                principalColumn: "tipo_anticonceptivo_id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "gineco_obstetrico_ibfk_3",
                table: "gineco_obstetrico",
                column: "expedediente_id",
                principalTable: "expediente",
                principalColumn: "expediente_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "heredo_familiar_ibfk_1",
                table: "heredo_familiar",
                column: "expedediente_id",
                principalTable: "expediente",
                principalColumn: "expediente_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "no_patologico_ibfk_1",
                table: "no_patologico",
                column: "expedediente_id",
                principalTable: "expediente",
                principalColumn: "expediente_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "paciente_ibfk_1",
                table: "paciente",
                column: "estado_civil_id",
                principalTable: "estado_civil",
                principalColumn: "estado_civil_id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "expediente_ibfk_1",
                table: "expediente");

            migrationBuilder.DropForeignKey(
                name: "gineco_obstetrico_ibfk_1",
                table: "gineco_obstetrico");

            migrationBuilder.DropForeignKey(
                name: "gineco_obstetrico_ibfk_2",
                table: "gineco_obstetrico");

            migrationBuilder.DropForeignKey(
                name: "gineco_obstetrico_ibfk_3",
                table: "gineco_obstetrico");

            migrationBuilder.DropForeignKey(
                name: "heredo_familiar_ibfk_1",
                table: "heredo_familiar");

            migrationBuilder.DropForeignKey(
                name: "no_patologico_ibfk_1",
                table: "no_patologico");

            migrationBuilder.DropForeignKey(
                name: "paciente_ibfk_1",
                table: "paciente");

            migrationBuilder.DropIndex(
                name: "expedediente_id3",
                table: "no_patologico");

            migrationBuilder.DropIndex(
                name: "expedediente_id2",
                table: "heredo_familiar");

            migrationBuilder.DropIndex(
                name: "expedediente_id1",
                table: "gineco_obstetrico");

            migrationBuilder.DropIndex(
                name: "paciente_id1",
                table: "expediente");

            migrationBuilder.AlterColumn<string>(
                name: "tipo_anticonceptivo",
                table: "tipo_anticonceptivo",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "telefono",
                table: "paciente",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<bool>(
                name: "sexo",
                table: "paciente",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<string>(
                name: "ocupacion",
                table: "paciente",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "paciente",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "institucion",
                table: "paciente",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "estado_civil_id",
                table: "paciente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "edad",
                table: "paciente",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "domicilio",
                table: "paciente",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "codigo_postal",
                table: "paciente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "medio_sociocultural",
                table: "no_patologico",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "medio_laboral",
                table: "no_patologico",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "medio_fisicoambiental",
                table: "no_patologico",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<int>(
                name: "expedediente_id",
                table: "no_patologico",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "padres_vivos",
                table: "heredo_familiar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "padres",
                table: "heredo_familiar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "hijos_vivos",
                table: "heredo_familiar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "hijos",
                table: "heredo_familiar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "hermanos_vivos",
                table: "heredo_familiar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "hermanos",
                table: "heredo_familiar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "expedediente_id",
                table: "heredo_familiar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "tipo_anticonceptivo_id",
                table: "gineco_obstetrico",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "expedediente_id",
                table: "gineco_obstetrico",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "flujo_vaginal",
                table: "flujo_vaginal",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "tipo_interrogatorio",
                table: "expediente",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<string>(
                name: "responsable",
                table: "expediente",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "paciente_id",
                table: "expediente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "antecedentes_patologicos",
                table: "expediente",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "estado_civil",
                table: "estado_civil",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "motivo",
                table: "citas",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "expedediente_id3",
                table: "no_patologico",
                column: "expedediente_id");

            migrationBuilder.CreateIndex(
                name: "expedediente_id2",
                table: "heredo_familiar",
                column: "expedediente_id");

            migrationBuilder.CreateIndex(
                name: "expedediente_id1",
                table: "gineco_obstetrico",
                column: "expedediente_id");

            migrationBuilder.CreateIndex(
                name: "paciente_id1",
                table: "expediente",
                column: "paciente_id");

            migrationBuilder.AddForeignKey(
                name: "expediente_ibfk_1",
                table: "expediente",
                column: "paciente_id",
                principalTable: "paciente",
                principalColumn: "paciente_id");

            migrationBuilder.AddForeignKey(
                name: "gineco_obstetrico_ibfk_1",
                table: "gineco_obstetrico",
                column: "flujo_vaginal_id",
                principalTable: "flujo_vaginal",
                principalColumn: "flujo_vaginal_id");

            migrationBuilder.AddForeignKey(
                name: "gineco_obstetrico_ibfk_2",
                table: "gineco_obstetrico",
                column: "tipo_anticonceptivo_id",
                principalTable: "tipo_anticonceptivo",
                principalColumn: "tipo_anticonceptivo_id");

            migrationBuilder.AddForeignKey(
                name: "gineco_obstetrico_ibfk_3",
                table: "gineco_obstetrico",
                column: "expedediente_id",
                principalTable: "expediente",
                principalColumn: "expediente_id");

            migrationBuilder.AddForeignKey(
                name: "heredo_familiar_ibfk_1",
                table: "heredo_familiar",
                column: "expedediente_id",
                principalTable: "expediente",
                principalColumn: "expediente_id");

            migrationBuilder.AddForeignKey(
                name: "no_patologico_ibfk_1",
                table: "no_patologico",
                column: "expedediente_id",
                principalTable: "expediente",
                principalColumn: "expediente_id");

            migrationBuilder.AddForeignKey(
                name: "paciente_ibfk_1",
                table: "paciente",
                column: "estado_civil_id",
                principalTable: "estado_civil",
                principalColumn: "estado_civil_id");
        }
    }
}
