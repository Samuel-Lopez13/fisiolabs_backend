using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Core.Infraestructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estado_civil",
                columns: table => new
                {
                    estado_civil_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    estado_civil = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.estado_civil_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "fisioterapeuta",
                columns: table => new
                {
                    fisioterapeuta_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    fisioterapeuta = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.fisioterapeuta_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "flujo_vaginal",
                columns: table => new
                {
                    flujo_vaginal_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    flujo_vaginal = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.flujo_vaginal_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_anticonceptivo",
                columns: table => new
                {
                    tipo_anticonceptivo_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tipo_anticonceptivo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tipo_anticonceptivo_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Especialidad = table.Column<string>(type: "longtext", nullable: true),
                    Correo = table.Column<string>(type: "varchar(255)", nullable: true),
                    Telefono = table.Column<string>(type: "varchar(255)", nullable: true),
                    Nacionalidad = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.usuario_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "paciente",
                columns: table => new
                {
                    paciente_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    edad = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    sexo = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    institucion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    domicilio = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    codigo_postal = table.Column<int>(type: "int", nullable: true),
                    ocupacion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    telefono = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    estado_civil_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.paciente_id);
                    table.ForeignKey(
                        name: "paciente_ibfk_1",
                        column: x => x.estado_civil_id,
                        principalTable: "estado_civil",
                        principalColumn: "estado_civil_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "citas",
                columns: table => new
                {
                    citas_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    fecha = table.Column<DateTime>(type: "date", nullable: false),
                    motivo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    paciente_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.citas_id);
                    table.ForeignKey(
                        name: "citas_ibfk_1",
                        column: x => x.paciente_id,
                        principalTable: "paciente",
                        principalColumn: "paciente_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "expediente",
                columns: table => new
                {
                    expediente_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    tipo_interrogatorio = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    responsable = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    antecedentes_patologicos = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    paciente_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.expediente_id);
                    table.ForeignKey(
                        name: "expediente_ibfk_1",
                        column: x => x.paciente_id,
                        principalTable: "paciente",
                        principalColumn: "paciente_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "diagnostico",
                columns: table => new
                {
                    diagnostico_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    motivo_alta = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    fecha_inicio = table.Column<DateTime>(type: "date", nullable: true),
                    fecha_alta = table.Column<DateTime>(type: "date", nullable: true),
                    Estatus = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    categoria = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    diagnostico_inicial = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    diagnostico_final = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    diagnostico_previo = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    diagnostico_funcional = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    diagnostico = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    frecuencia_tratamiento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    padecimiento_actual = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    refiere = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    terapeutica_empleada = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    inspeccion = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    palpitacion = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    movibilidad = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    estudios_complementarios = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    diagnostico_nosologico = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    expedediente_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.diagnostico_id);
                    table.ForeignKey(
                        name: "diagnostico_ibfk_1",
                        column: x => x.expedediente_id,
                        principalTable: "expediente",
                        principalColumn: "expediente_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gineco_obstetrico",
                columns: table => new
                {
                    gineco_obstetrico_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FUM = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    FPP = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    edad_gestional = table.Column<int>(type: "int", nullable: true),
                    semanas = table.Column<int>(type: "int", nullable: true),
                    menarca = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ritmo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    gestas = table.Column<int>(type: "int", nullable: true),
                    partos = table.Column<int>(type: "int", nullable: true),
                    cesareas = table.Column<int>(type: "int", nullable: true),
                    abortos = table.Column<int>(type: "int", nullable: true),
                    cirugias = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    flujo_vaginal_id = table.Column<int>(type: "int", nullable: true),
                    tipo_anticonceptivo_id = table.Column<int>(type: "int", nullable: true),
                    expedediente_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.gineco_obstetrico_id);
                    table.ForeignKey(
                        name: "gineco_obstetrico_ibfk_1",
                        column: x => x.flujo_vaginal_id,
                        principalTable: "flujo_vaginal",
                        principalColumn: "flujo_vaginal_id");
                    table.ForeignKey(
                        name: "gineco_obstetrico_ibfk_2",
                        column: x => x.tipo_anticonceptivo_id,
                        principalTable: "tipo_anticonceptivo",
                        principalColumn: "tipo_anticonceptivo_id");
                    table.ForeignKey(
                        name: "gineco_obstetrico_ibfk_3",
                        column: x => x.expedediente_id,
                        principalTable: "expediente",
                        principalColumn: "expediente_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "heredo_familiar",
                columns: table => new
                {
                    heredo_familiar_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    padres = table.Column<int>(type: "int", nullable: true),
                    padres_vivos = table.Column<int>(type: "int", nullable: true),
                    padres_causa_muerte = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    hermanos = table.Column<int>(type: "int", nullable: true),
                    hermanos_vivos = table.Column<int>(type: "int", nullable: true),
                    hermanos_causa_muerte = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    hijos = table.Column<int>(type: "int", nullable: true),
                    hijos_vivos = table.Column<int>(type: "int", nullable: true),
                    hijos_causa_muerte = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    dm = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    hta = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    cancer = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    alcoholismo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    tabaquismo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    drogas = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    expedediente_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.heredo_familiar_id);
                    table.ForeignKey(
                        name: "heredo_familiar_ibfk_1",
                        column: x => x.expedediente_id,
                        principalTable: "expediente",
                        principalColumn: "expediente_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "no_patologico",
                columns: table => new
                {
                    no_patologico_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    medio_laboral = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    medio_sociocultural = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    medio_fisicoambiental = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    expedediente_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.no_patologico_id);
                    table.ForeignKey(
                        name: "no_patologico_ibfk_1",
                        column: x => x.expedediente_id,
                        principalTable: "expediente",
                        principalColumn: "expediente_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "exploracion_fisica",
                columns: table => new
                {
                    exploracion_fisica_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    temperatura = table.Column<float>(type: "float", nullable: true),
                    FR = table.Column<int>(type: "int", nullable: true),
                    FC = table.Column<int>(type: "int", nullable: true),
                    presion_arterial = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    peso = table.Column<float>(type: "float", nullable: true),
                    estatura = table.Column<float>(type: "float", nullable: true),
                    IMC = table.Column<float>(type: "float", nullable: true),
                    indice_cintura_cadera = table.Column<float>(type: "float", nullable: true),
                    saturacion_oxigeno = table.Column<float>(type: "float", nullable: true),
                    diagnostico_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.exploracion_fisica_id);
                    table.ForeignKey(
                        name: "exploracion_fisica_ibfk_1",
                        column: x => x.diagnostico_id,
                        principalTable: "diagnostico",
                        principalColumn: "diagnostico_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mapa_corporal",
                columns: table => new
                {
                    mapa_corporal_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    valor_x = table.Column<int>(type: "int", nullable: true),
                    valor_y = table.Column<int>(type: "int", nullable: true),
                    rango_dolor = table.Column<int>(type: "int", nullable: true),
                    nota = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    diagnostico_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.mapa_corporal_id);
                    table.ForeignKey(
                        name: "mapa_corporal_ibfk_1",
                        column: x => x.diagnostico_id,
                        principalTable: "diagnostico",
                        principalColumn: "diagnostico_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "programa_fisioterapeutico",
                columns: table => new
                {
                    programa_fisioterapeutico_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    corto_plazo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    mediano_plazo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    largo_plazo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    tratamiento_fisioterapeutico = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    sugerencias = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    pronostico = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    diagnostico_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.programa_fisioterapeutico_id);
                    table.ForeignKey(
                        name: "programa_fisioterapeutico_ibfk_1",
                        column: x => x.diagnostico_id,
                        principalTable: "diagnostico",
                        principalColumn: "diagnostico_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "revision",
                columns: table => new
                {
                    revision_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    revision = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    fecha = table.Column<DateTime>(type: "date", nullable: true),
                    fisioterapeuta_id = table.Column<int>(type: "int", nullable: true),
                    diagnostico_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.revision_id);
                    table.ForeignKey(
                        name: "revision_ibfk_1",
                        column: x => x.fisioterapeuta_id,
                        principalTable: "fisioterapeuta",
                        principalColumn: "fisioterapeuta_id");
                    table.ForeignKey(
                        name: "revision_ibfk_2",
                        column: x => x.diagnostico_id,
                        principalTable: "diagnostico",
                        principalColumn: "diagnostico_id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "paciente_id",
                table: "citas",
                column: "paciente_id");

            migrationBuilder.CreateIndex(
                name: "expedediente_id",
                table: "diagnostico",
                column: "expedediente_id");

            migrationBuilder.CreateIndex(
                name: "paciente_id1",
                table: "expediente",
                column: "paciente_id");

            migrationBuilder.CreateIndex(
                name: "diagnostico_id",
                table: "exploracion_fisica",
                column: "diagnostico_id");

            migrationBuilder.CreateIndex(
                name: "expedediente_id1",
                table: "gineco_obstetrico",
                column: "expedediente_id");

            migrationBuilder.CreateIndex(
                name: "flujo_vaginal_id",
                table: "gineco_obstetrico",
                column: "flujo_vaginal_id");

            migrationBuilder.CreateIndex(
                name: "tipo_anticonceptivo_id",
                table: "gineco_obstetrico",
                column: "tipo_anticonceptivo_id");

            migrationBuilder.CreateIndex(
                name: "expedediente_id2",
                table: "heredo_familiar",
                column: "expedediente_id");

            migrationBuilder.CreateIndex(
                name: "diagnostico_id1",
                table: "mapa_corporal",
                column: "diagnostico_id");

            migrationBuilder.CreateIndex(
                name: "expedediente_id3",
                table: "no_patologico",
                column: "expedediente_id");

            migrationBuilder.CreateIndex(
                name: "estado_civil_id",
                table: "paciente",
                column: "estado_civil_id");

            migrationBuilder.CreateIndex(
                name: "diagnostico_id2",
                table: "programa_fisioterapeutico",
                column: "diagnostico_id");

            migrationBuilder.CreateIndex(
                name: "diagnostico_id3",
                table: "revision",
                column: "diagnostico_id");

            migrationBuilder.CreateIndex(
                name: "fisioterapeuta_id",
                table: "revision",
                column: "fisioterapeuta_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_Correo",
                table: "usuario",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_Telefono",
                table: "usuario",
                column: "Telefono",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_username",
                table: "usuario",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "citas");

            migrationBuilder.DropTable(
                name: "exploracion_fisica");

            migrationBuilder.DropTable(
                name: "gineco_obstetrico");

            migrationBuilder.DropTable(
                name: "heredo_familiar");

            migrationBuilder.DropTable(
                name: "mapa_corporal");

            migrationBuilder.DropTable(
                name: "no_patologico");

            migrationBuilder.DropTable(
                name: "programa_fisioterapeutico");

            migrationBuilder.DropTable(
                name: "revision");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "flujo_vaginal");

            migrationBuilder.DropTable(
                name: "tipo_anticonceptivo");

            migrationBuilder.DropTable(
                name: "fisioterapeuta");

            migrationBuilder.DropTable(
                name: "diagnostico");

            migrationBuilder.DropTable(
                name: "expediente");

            migrationBuilder.DropTable(
                name: "paciente");

            migrationBuilder.DropTable(
                name: "estado_civil");
        }
    }
}
