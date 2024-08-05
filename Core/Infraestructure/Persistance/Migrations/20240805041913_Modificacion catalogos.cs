using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Infraestructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Modificacioncatalogos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "cat_tipo_anticonceptivo",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "cat_tipo_anticonceptivo",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "cat_servicios",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "cat_servicios",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "cat_motivo_alta",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "cat_motivo_alta",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "cat_flujo_vaginal",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "cat_flujo_vaginal",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "cat_estado_civil",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "cat_estado_civil",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "cat_especialidad",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "cat_especialidad",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_cat_tipo_anticonceptivo_Descripcion",
                table: "cat_tipo_anticonceptivo",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cat_servicios_Descripcion",
                table: "cat_servicios",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cat_motivo_alta_Descripcion",
                table: "cat_motivo_alta",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cat_flujo_vaginal_Descripcion",
                table: "cat_flujo_vaginal",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cat_estado_civil_Descripcion",
                table: "cat_estado_civil",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cat_especialidad_Descripcion",
                table: "cat_especialidad",
                column: "Descripcion",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_cat_tipo_anticonceptivo_Descripcion",
                table: "cat_tipo_anticonceptivo");

            migrationBuilder.DropIndex(
                name: "IX_cat_servicios_Descripcion",
                table: "cat_servicios");

            migrationBuilder.DropIndex(
                name: "IX_cat_motivo_alta_Descripcion",
                table: "cat_motivo_alta");

            migrationBuilder.DropIndex(
                name: "IX_cat_flujo_vaginal_Descripcion",
                table: "cat_flujo_vaginal");

            migrationBuilder.DropIndex(
                name: "IX_cat_estado_civil_Descripcion",
                table: "cat_estado_civil");

            migrationBuilder.DropIndex(
                name: "IX_cat_especialidad_Descripcion",
                table: "cat_especialidad");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "cat_tipo_anticonceptivo");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "cat_servicios");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "cat_motivo_alta");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "cat_flujo_vaginal");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "cat_estado_civil");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "cat_especialidad");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "cat_tipo_anticonceptivo",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "cat_servicios",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "cat_motivo_alta",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "cat_flujo_vaginal",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "cat_estado_civil",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "cat_especialidad",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");
        }
    }
}
