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
                    EstadoCivilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EstadoCivil1 = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado_civil", x => x.EstadoCivilId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "fisioterapeuta",
                columns: table => new
                {
                    FisioterapeutaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Fisioterapeuta = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fisioterapeuta", x => x.FisioterapeutaId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "flujo_vaginal",
                columns: table => new
                {
                    FlujoVaginalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Flujo = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_flujo_vaginal", x => x.FlujoVaginalId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_anticonceptivo",
                columns: table => new
                {
                    TipoAnticonceptivoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Anticonceptivo = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_anticonceptivo", x => x.TipoAnticonceptivoId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(255)", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    Especialidad = table.Column<string>(type: "longtext", nullable: true),
                    Correo = table.Column<string>(type: "varchar(255)", nullable: true),
                    Telefono = table.Column<string>(type: "varchar(255)", nullable: true),
                    Nacionalidad = table.Column<string>(type: "longtext", nullable: true),
                    FotoPerfil = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.usuario_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "paciente",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Edad = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Sexo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Institucion = table.Column<string>(type: "longtext", nullable: false),
                    Domicilio = table.Column<string>(type: "longtext", nullable: false),
                    CodigoPostal = table.Column<int>(type: "int", nullable: false),
                    Ocupacion = table.Column<string>(type: "longtext", nullable: false),
                    Telefono = table.Column<string>(type: "longtext", nullable: false),
                    EstadoCivilId = table.Column<int>(type: "int", nullable: true),
                    Notas = table.Column<string>(type: "longtext", nullable: true),
                    FotoPerfil = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paciente", x => x.PacienteId);
                    table.ForeignKey(
                        name: "paciente_ibfk_1",
                        column: x => x.EstadoCivilId,
                        principalTable: "estado_civil",
                        principalColumn: "EstadoCivilId",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "citas",
                columns: table => new
                {
                    CitasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Motivo = table.Column<string>(type: "longtext", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citas", x => x.CitasId);
                    table.ForeignKey(
                        name: "citas_ibfk_1",
                        column: x => x.PacienteId,
                        principalTable: "paciente",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "expediente",
                columns: table => new
                {
                    ExpedienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TipoInterrogatorio = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Responsable = table.Column<string>(type: "longtext", nullable: false),
                    AntecedentesPatologicos = table.Column<string>(type: "longtext", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expediente", x => x.ExpedienteId);
                    table.ForeignKey(
                        name: "expediente_ibfk_1",
                        column: x => x.PacienteId,
                        principalTable: "paciente",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "diagnostico",
                columns: table => new
                {
                    DiagnosticoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MotivoAlta = table.Column<string>(type: "longtext", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Estatus = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Categoria = table.Column<string>(type: "longtext", nullable: true),
                    DiagnosticoInicial = table.Column<string>(type: "longtext", nullable: true),
                    DiagnosticoFinal = table.Column<string>(type: "longtext", nullable: true),
                    DiagnosticoPrevio = table.Column<string>(type: "longtext", nullable: true),
                    DiagnosticoFuncional = table.Column<string>(type: "longtext", nullable: true),
                    Diagnostico1 = table.Column<string>(type: "longtext", nullable: true),
                    FrecuenciaTratamiento = table.Column<string>(type: "longtext", nullable: true),
                    PadecimientoActual = table.Column<string>(type: "longtext", nullable: true),
                    Refiere = table.Column<string>(type: "longtext", nullable: true),
                    TerapeuticaEmpleada = table.Column<string>(type: "longtext", nullable: true),
                    Inspeccion = table.Column<string>(type: "longtext", nullable: true),
                    Palpitacion = table.Column<string>(type: "longtext", nullable: true),
                    Movibilidad = table.Column<string>(type: "longtext", nullable: true),
                    EstudiosComplementarios = table.Column<string>(type: "longtext", nullable: true),
                    DiagnosticoNosologico = table.Column<string>(type: "longtext", nullable: true),
                    ExpededienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnostico", x => x.DiagnosticoId);
                    table.ForeignKey(
                        name: "diagnostico_ibfk_1",
                        column: x => x.ExpededienteId,
                        principalTable: "expediente",
                        principalColumn: "ExpedienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gineco_obstetrico",
                columns: table => new
                {
                    GinecoObstetricoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Fum = table.Column<string>(type: "longtext", nullable: true),
                    Fpp = table.Column<string>(type: "longtext", nullable: true),
                    EdadGestional = table.Column<int>(type: "int", nullable: true),
                    Semanas = table.Column<int>(type: "int", nullable: true),
                    Menarca = table.Column<string>(type: "longtext", nullable: true),
                    Ritmo = table.Column<string>(type: "longtext", nullable: true),
                    Gestas = table.Column<int>(type: "int", nullable: true),
                    Partos = table.Column<int>(type: "int", nullable: true),
                    Cesareas = table.Column<int>(type: "int", nullable: true),
                    Abortos = table.Column<int>(type: "int", nullable: true),
                    Cirugias = table.Column<string>(type: "longtext", nullable: true),
                    FlujoVaginalId = table.Column<int>(type: "int", nullable: true),
                    TipoAnticonceptivoId = table.Column<int>(type: "int", nullable: true),
                    ExpedienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gineco_obstetrico", x => x.GinecoObstetricoId);
                    table.ForeignKey(
                        name: "gineco_obstetrico_ibfk_1",
                        column: x => x.FlujoVaginalId,
                        principalTable: "flujo_vaginal",
                        principalColumn: "FlujoVaginalId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "gineco_obstetrico_ibfk_2",
                        column: x => x.TipoAnticonceptivoId,
                        principalTable: "tipo_anticonceptivo",
                        principalColumn: "TipoAnticonceptivoId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "gineco_obstetrico_ibfk_3",
                        column: x => x.ExpedienteId,
                        principalTable: "expediente",
                        principalColumn: "ExpedienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "heredo_familiar",
                columns: table => new
                {
                    HeredoFamiliarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Padres = table.Column<int>(type: "int", nullable: false),
                    PadresVivos = table.Column<int>(type: "int", nullable: false),
                    PadresCausaMuerte = table.Column<string>(type: "longtext", nullable: true),
                    Hermanos = table.Column<int>(type: "int", nullable: false),
                    HermanosVivos = table.Column<int>(type: "int", nullable: false),
                    HermanosCausaMuerte = table.Column<string>(type: "longtext", nullable: true),
                    Hijos = table.Column<int>(type: "int", nullable: false),
                    HijosVivos = table.Column<int>(type: "int", nullable: false),
                    HijosCausaMuerte = table.Column<string>(type: "longtext", nullable: true),
                    Dm = table.Column<string>(type: "longtext", nullable: true),
                    Hta = table.Column<string>(type: "longtext", nullable: true),
                    Cancer = table.Column<string>(type: "longtext", nullable: true),
                    Alcoholismo = table.Column<string>(type: "longtext", nullable: true),
                    Tabaquismo = table.Column<string>(type: "longtext", nullable: true),
                    Drogas = table.Column<string>(type: "longtext", nullable: true),
                    ExpedienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_heredo_familiar", x => x.HeredoFamiliarId);
                    table.ForeignKey(
                        name: "heredo_familiar_ibfk_1",
                        column: x => x.ExpedienteId,
                        principalTable: "expediente",
                        principalColumn: "ExpedienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "no_patologico",
                columns: table => new
                {
                    NoPatologicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MedioLaboral = table.Column<string>(type: "longtext", nullable: false),
                    MedioSociocultural = table.Column<string>(type: "longtext", nullable: false),
                    MedioFisicoambiental = table.Column<string>(type: "longtext", nullable: false),
                    ExpedienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_no_patologico", x => x.NoPatologicoId);
                    table.ForeignKey(
                        name: "no_patologico_ibfk_1",
                        column: x => x.ExpedienteId,
                        principalTable: "expediente",
                        principalColumn: "ExpedienteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "exploracion_fisica",
                columns: table => new
                {
                    ExploracionFisicaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Temperatura = table.Column<float>(type: "float", nullable: true),
                    Fr = table.Column<int>(type: "int", nullable: true),
                    Fc = table.Column<int>(type: "int", nullable: true),
                    PresionArterial = table.Column<string>(type: "longtext", nullable: true),
                    Peso = table.Column<float>(type: "float", nullable: true),
                    Estatura = table.Column<float>(type: "float", nullable: true),
                    Imc = table.Column<float>(type: "float", nullable: true),
                    IndiceCinturaCadera = table.Column<float>(type: "float", nullable: true),
                    SaturacionOxigeno = table.Column<float>(type: "float", nullable: true),
                    DiagnosticoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exploracion_fisica", x => x.ExploracionFisicaId);
                    table.ForeignKey(
                        name: "exploracion_fisica_ibfk_1",
                        column: x => x.DiagnosticoId,
                        principalTable: "diagnostico",
                        principalColumn: "DiagnosticoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mapa_corporal",
                columns: table => new
                {
                    MapaCorporalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ValorX = table.Column<int>(type: "int", nullable: false),
                    ValorY = table.Column<int>(type: "int", nullable: false),
                    RangoDolor = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<string>(type: "longtext", nullable: false),
                    DiagnosticoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mapa_corporal", x => x.MapaCorporalId);
                    table.ForeignKey(
                        name: "mapa_corporal_ibfk_1",
                        column: x => x.DiagnosticoId,
                        principalTable: "diagnostico",
                        principalColumn: "DiagnosticoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "programa_fisioterapeutico",
                columns: table => new
                {
                    ProgramaFisioterapeuticoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CortoPlazo = table.Column<string>(type: "longtext", nullable: false),
                    MedianoPlazo = table.Column<string>(type: "longtext", nullable: false),
                    LargoPlazo = table.Column<string>(type: "longtext", nullable: false),
                    TratamientoFisioterapeutico = table.Column<string>(type: "longtext", nullable: false),
                    Sugerencias = table.Column<string>(type: "longtext", nullable: false),
                    Pronostico = table.Column<string>(type: "longtext", nullable: false),
                    DiagnosticoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programa_fisioterapeutico", x => x.ProgramaFisioterapeuticoId);
                    table.ForeignKey(
                        name: "programa_fisioterapeutico_ibfk_1",
                        column: x => x.DiagnosticoId,
                        principalTable: "diagnostico",
                        principalColumn: "DiagnosticoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "revision",
                columns: table => new
                {
                    RevisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Notas = table.Column<string>(type: "longtext", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FisioterapeutaId = table.Column<int>(type: "int", nullable: true),
                    DiagnosticoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_revision", x => x.RevisionId);
                    table.ForeignKey(
                        name: "revision_ibfk_1",
                        column: x => x.FisioterapeutaId,
                        principalTable: "fisioterapeuta",
                        principalColumn: "FisioterapeutaId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "revision_ibfk_2",
                        column: x => x.DiagnosticoId,
                        principalTable: "diagnostico",
                        principalColumn: "DiagnosticoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "paciente_id",
                table: "citas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "expediente_id",
                table: "diagnostico",
                column: "ExpededienteId");

            migrationBuilder.CreateIndex(
                name: "paciente_id1",
                table: "expediente",
                column: "PacienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "diagnostico_id",
                table: "exploracion_fisica",
                column: "DiagnosticoId");

            migrationBuilder.CreateIndex(
                name: "expediente_id1",
                table: "gineco_obstetrico",
                column: "ExpedienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "flujo_vaginal_id",
                table: "gineco_obstetrico",
                column: "FlujoVaginalId");

            migrationBuilder.CreateIndex(
                name: "tipo_anticonceptivo_id",
                table: "gineco_obstetrico",
                column: "TipoAnticonceptivoId");

            migrationBuilder.CreateIndex(
                name: "expediente_id2",
                table: "heredo_familiar",
                column: "ExpedienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "diagnostico_id1",
                table: "mapa_corporal",
                column: "DiagnosticoId");

            migrationBuilder.CreateIndex(
                name: "expediente_id3",
                table: "no_patologico",
                column: "ExpedienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "estado_civil_id",
                table: "paciente",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "diagnostico_id2",
                table: "programa_fisioterapeutico",
                column: "DiagnosticoId");

            migrationBuilder.CreateIndex(
                name: "diagnostico_id3",
                table: "revision",
                column: "DiagnosticoId");

            migrationBuilder.CreateIndex(
                name: "fisioterapeuta_id",
                table: "revision",
                column: "FisioterapeutaId");

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
                name: "IX_usuario_Username",
                table: "usuario",
                column: "Username",
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
