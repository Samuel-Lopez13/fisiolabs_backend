﻿// <auto-generated />
using System;
using Core.Infraestructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Core.Infraestructure.Persistance.Migrations
{
    [DbContext(typeof(FisiolabsSofwaredbContext))]
    [Migration("20240615063842_img paciente y usuario a null")]
    partial class imgpacienteyusuarioanull
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Domain.Entities.Cita", b =>
                {
                    b.Property<int>("CitasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("citas_id");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("fecha");

                    b.Property<string>("Motivo")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("motivo");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int")
                        .HasColumnName("paciente_id");

                    b.HasKey("CitasId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "PacienteId" }, "paciente_id");

                    b.ToTable("citas", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.Diagnostico", b =>
                {
                    b.Property<int>("DiagnosticoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("diagnostico_id");

                    b.Property<string>("Categoria")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("categoria");

                    b.Property<string>("Diagnostico1")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("diagnostico");

                    b.Property<string>("DiagnosticoFinal")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("diagnostico_final");

                    b.Property<string>("DiagnosticoFuncional")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("diagnostico_funcional");

                    b.Property<string>("DiagnosticoInicial")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("diagnostico_inicial");

                    b.Property<string>("DiagnosticoNosologico")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("diagnostico_nosologico");

                    b.Property<string>("DiagnosticoPrevio")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("diagnostico_previo");

                    b.Property<bool?>("Estatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("EstudiosComplementarios")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("estudios_complementarios");

                    b.Property<int?>("ExpededienteId")
                        .HasColumnType("int")
                        .HasColumnName("expedediente_id");

                    b.Property<DateTime?>("FechaAlta")
                        .HasColumnType("date")
                        .HasColumnName("fecha_alta");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("date")
                        .HasColumnName("fecha_inicio");

                    b.Property<string>("FrecuenciaTratamiento")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("frecuencia_tratamiento");

                    b.Property<string>("Inspeccion")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("inspeccion");

                    b.Property<string>("MotivoAlta")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("motivo_alta");

                    b.Property<string>("Movibilidad")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("movibilidad");

                    b.Property<string>("PadecimientoActual")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("padecimiento_actual");

                    b.Property<string>("Palpitacion")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("palpitacion");

                    b.Property<string>("Refiere")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("refiere");

                    b.Property<string>("TerapeuticaEmpleada")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("terapeutica_empleada");

                    b.HasKey("DiagnosticoId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ExpededienteId" }, "expedediente_id");

                    b.ToTable("diagnostico", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.EstadoCivil", b =>
                {
                    b.Property<int>("EstadoCivilId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("estado_civil_id");

                    b.Property<string>("EstadoCivil1")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("estado_civil");

                    b.HasKey("EstadoCivilId")
                        .HasName("PRIMARY");

                    b.ToTable("estado_civil", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.Expediente", b =>
                {
                    b.Property<int>("ExpedienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("expediente_id");

                    b.Property<string>("AntecedentesPatologicos")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("antecedentes_patologicos");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int")
                        .HasColumnName("paciente_id");

                    b.Property<string>("Responsable")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("responsable");

                    b.Property<bool?>("TipoInterrogatorio")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("tipo_interrogatorio");

                    b.HasKey("ExpedienteId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "PacienteId" }, "paciente_id")
                        .HasDatabaseName("paciente_id1");

                    b.ToTable("expediente", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.ExploracionFisica", b =>
                {
                    b.Property<int>("ExploracionFisicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("exploracion_fisica_id");

                    b.Property<int?>("DiagnosticoId")
                        .HasColumnType("int")
                        .HasColumnName("diagnostico_id");

                    b.Property<float?>("Estatura")
                        .HasColumnType("float")
                        .HasColumnName("estatura");

                    b.Property<int?>("Fc")
                        .HasColumnType("int")
                        .HasColumnName("FC");

                    b.Property<int?>("Fr")
                        .HasColumnType("int")
                        .HasColumnName("FR");

                    b.Property<float?>("Imc")
                        .HasColumnType("float")
                        .HasColumnName("IMC");

                    b.Property<float?>("IndiceCinturaCadera")
                        .HasColumnType("float")
                        .HasColumnName("indice_cintura_cadera");

                    b.Property<float?>("Peso")
                        .HasColumnType("float")
                        .HasColumnName("peso");

                    b.Property<string>("PresionArterial")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("presion_arterial");

                    b.Property<float?>("SaturacionOxigeno")
                        .HasColumnType("float")
                        .HasColumnName("saturacion_oxigeno");

                    b.Property<float?>("Temperatura")
                        .HasColumnType("float")
                        .HasColumnName("temperatura");

                    b.HasKey("ExploracionFisicaId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "DiagnosticoId" }, "diagnostico_id");

                    b.ToTable("exploracion_fisica", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.Fisioterapeutum", b =>
                {
                    b.Property<int>("FisioterapeutaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fisioterapeuta_id");

                    b.Property<string>("Fisioterapeuta")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("fisioterapeuta");

                    b.HasKey("FisioterapeutaId")
                        .HasName("PRIMARY");

                    b.ToTable("fisioterapeuta", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.FlujoVaginal", b =>
                {
                    b.Property<int>("FlujoVaginalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("flujo_vaginal_id");

                    b.Property<string>("FlujoVaginal1")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("flujo_vaginal");

                    b.HasKey("FlujoVaginalId")
                        .HasName("PRIMARY");

                    b.ToTable("flujo_vaginal", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.GinecoObstetrico", b =>
                {
                    b.Property<int>("GinecoObstetricoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("gineco_obstetrico_id");

                    b.Property<int?>("Abortos")
                        .HasColumnType("int")
                        .HasColumnName("abortos");

                    b.Property<int?>("Cesareas")
                        .HasColumnType("int")
                        .HasColumnName("cesareas");

                    b.Property<string>("Cirugias")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("cirugias");

                    b.Property<int?>("EdadGestional")
                        .HasColumnType("int")
                        .HasColumnName("edad_gestional");

                    b.Property<int?>("ExpededienteId")
                        .HasColumnType("int")
                        .HasColumnName("expedediente_id");

                    b.Property<int?>("FlujoVaginalId")
                        .HasColumnType("int")
                        .HasColumnName("flujo_vaginal_id");

                    b.Property<string>("Fpp")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("FPP");

                    b.Property<string>("Fum")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("FUM");

                    b.Property<int?>("Gestas")
                        .HasColumnType("int")
                        .HasColumnName("gestas");

                    b.Property<string>("Menarca")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("menarca");

                    b.Property<int?>("Partos")
                        .HasColumnType("int")
                        .HasColumnName("partos");

                    b.Property<string>("Ritmo")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ritmo");

                    b.Property<int?>("Semanas")
                        .HasColumnType("int")
                        .HasColumnName("semanas");

                    b.Property<int?>("TipoAnticonceptivoId")
                        .HasColumnType("int")
                        .HasColumnName("tipo_anticonceptivo_id");

                    b.HasKey("GinecoObstetricoId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ExpededienteId" }, "expedediente_id")
                        .HasDatabaseName("expedediente_id1");

                    b.HasIndex(new[] { "FlujoVaginalId" }, "flujo_vaginal_id");

                    b.HasIndex(new[] { "TipoAnticonceptivoId" }, "tipo_anticonceptivo_id");

                    b.ToTable("gineco_obstetrico", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.HeredoFamiliar", b =>
                {
                    b.Property<int>("HeredoFamiliarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("heredo_familiar_id");

                    b.Property<string>("Alcoholismo")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("alcoholismo");

                    b.Property<string>("Cancer")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("cancer");

                    b.Property<string>("Dm")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("dm");

                    b.Property<string>("Drogas")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("drogas");

                    b.Property<int?>("ExpededienteId")
                        .HasColumnType("int")
                        .HasColumnName("expedediente_id");

                    b.Property<int?>("Hermanos")
                        .HasColumnType("int")
                        .HasColumnName("hermanos");

                    b.Property<string>("HermanosCausaMuerte")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("hermanos_causa_muerte");

                    b.Property<int?>("HermanosVivos")
                        .HasColumnType("int")
                        .HasColumnName("hermanos_vivos");

                    b.Property<int?>("Hijos")
                        .HasColumnType("int")
                        .HasColumnName("hijos");

                    b.Property<string>("HijosCausaMuerte")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("hijos_causa_muerte");

                    b.Property<int?>("HijosVivos")
                        .HasColumnType("int")
                        .HasColumnName("hijos_vivos");

                    b.Property<string>("Hta")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("hta");

                    b.Property<int?>("Padres")
                        .HasColumnType("int")
                        .HasColumnName("padres");

                    b.Property<string>("PadresCausaMuerte")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("padres_causa_muerte");

                    b.Property<int?>("PadresVivos")
                        .HasColumnType("int")
                        .HasColumnName("padres_vivos");

                    b.Property<string>("Tabaquismo")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("tabaquismo");

                    b.HasKey("HeredoFamiliarId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ExpededienteId" }, "expedediente_id")
                        .HasDatabaseName("expedediente_id2");

                    b.ToTable("heredo_familiar", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.MapaCorporal", b =>
                {
                    b.Property<int>("MapaCorporalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("mapa_corporal_id");

                    b.Property<int?>("DiagnosticoId")
                        .HasColumnType("int")
                        .HasColumnName("diagnostico_id");

                    b.Property<string>("Nota")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nota");

                    b.Property<int?>("RangoDolor")
                        .HasColumnType("int")
                        .HasColumnName("rango_dolor");

                    b.Property<int?>("ValorX")
                        .HasColumnType("int")
                        .HasColumnName("valor_x");

                    b.Property<int?>("ValorY")
                        .HasColumnType("int")
                        .HasColumnName("valor_y");

                    b.HasKey("MapaCorporalId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "DiagnosticoId" }, "diagnostico_id")
                        .HasDatabaseName("diagnostico_id1");

                    b.ToTable("mapa_corporal", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.NoPatologico", b =>
                {
                    b.Property<int>("NoPatologicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("no_patologico_id");

                    b.Property<int?>("ExpededienteId")
                        .HasColumnType("int")
                        .HasColumnName("expedediente_id");

                    b.Property<string>("MedioFisicoambiental")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("medio_fisicoambiental");

                    b.Property<string>("MedioLaboral")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("medio_laboral");

                    b.Property<string>("MedioSociocultural")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("medio_sociocultural");

                    b.HasKey("NoPatologicoId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ExpededienteId" }, "expedediente_id")
                        .HasDatabaseName("expedediente_id3");

                    b.ToTable("no_patologico", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.Paciente", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("paciente_id");

                    b.Property<int?>("CodigoPostal")
                        .HasColumnType("int")
                        .HasColumnName("codigo_postal");

                    b.Property<string>("Domicilio")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("domicilio");

                    b.Property<DateTime?>("Edad")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("edad");

                    b.Property<int?>("EstadoCivilId")
                        .HasColumnType("int")
                        .HasColumnName("estado_civil_id");

                    b.Property<string>("FotoPerfil")
                        .HasColumnType("longtext");

                    b.Property<string>("Institucion")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("institucion");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<string>("Ocupacion")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("ocupacion");

                    b.Property<bool?>("Sexo")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("sexo");

                    b.Property<string>("Telefono")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("telefono");

                    b.HasKey("PacienteId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "EstadoCivilId" }, "estado_civil_id");

                    b.ToTable("paciente", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.ProgramaFisioterapeutico", b =>
                {
                    b.Property<int>("ProgramaFisioterapeuticoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("programa_fisioterapeutico_id");

                    b.Property<string>("CortoPlazo")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("corto_plazo");

                    b.Property<int?>("DiagnosticoId")
                        .HasColumnType("int")
                        .HasColumnName("diagnostico_id");

                    b.Property<string>("LargoPlazo")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("largo_plazo");

                    b.Property<string>("MedianoPlazo")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("mediano_plazo");

                    b.Property<string>("Pronostico")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("pronostico");

                    b.Property<string>("Sugerencias")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("sugerencias");

                    b.Property<string>("TratamientoFisioterapeutico")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("tratamiento_fisioterapeutico");

                    b.HasKey("ProgramaFisioterapeuticoId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "DiagnosticoId" }, "diagnostico_id")
                        .HasDatabaseName("diagnostico_id2");

                    b.ToTable("programa_fisioterapeutico", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.Revision", b =>
                {
                    b.Property<int>("RevisionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("revision_id");

                    b.Property<int?>("DiagnosticoId")
                        .HasColumnType("int")
                        .HasColumnName("diagnostico_id");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("fecha");

                    b.Property<int?>("FisioterapeutaId")
                        .HasColumnType("int")
                        .HasColumnName("fisioterapeuta_id");

                    b.Property<string>("Revision1")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("revision");

                    b.HasKey("RevisionId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "DiagnosticoId" }, "diagnostico_id")
                        .HasDatabaseName("diagnostico_id3");

                    b.HasIndex(new[] { "FisioterapeutaId" }, "fisioterapeuta_id");

                    b.ToTable("revision", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.TipoAnticonceptivo", b =>
                {
                    b.Property<int>("TipoAnticonceptivoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("tipo_anticonceptivo_id");

                    b.Property<string>("Anticonceptivo")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("tipo_anticonceptivo");

                    b.HasKey("TipoAnticonceptivoId")
                        .HasName("PRIMARY");

                    b.ToTable("tipo_anticonceptivo", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("usuario_id");

                    b.Property<string>("Correo")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Especialidad")
                        .HasColumnType("longtext");

                    b.Property<string>("FotoPerfil")
                        .HasColumnType("longtext");

                    b.Property<string>("Nacionalidad")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("Telefono")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username");

                    b.HasKey("UsuarioId")
                        .HasName("PRIMARY");

                    b.HasIndex("Correo")
                        .IsUnique();

                    b.HasIndex("Telefono")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.Cita", b =>
                {
                    b.HasOne("Core.Domain.Entities.Paciente", "Paciente")
                        .WithMany("Citas")
                        .HasForeignKey("PacienteId")
                        .HasConstraintName("citas_ibfk_1");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Core.Domain.Entities.Diagnostico", b =>
                {
                    b.HasOne("Core.Domain.Entities.Expediente", "Expedediente")
                        .WithMany("Diagnosticos")
                        .HasForeignKey("ExpededienteId")
                        .HasConstraintName("diagnostico_ibfk_1");

                    b.Navigation("Expedediente");
                });

            modelBuilder.Entity("Core.Domain.Entities.Expediente", b =>
                {
                    b.HasOne("Core.Domain.Entities.Paciente", "Paciente")
                        .WithMany("Expedientes")
                        .HasForeignKey("PacienteId")
                        .HasConstraintName("expediente_ibfk_1");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Core.Domain.Entities.ExploracionFisica", b =>
                {
                    b.HasOne("Core.Domain.Entities.Diagnostico", "Diagnostico")
                        .WithMany("ExploracionFisicas")
                        .HasForeignKey("DiagnosticoId")
                        .HasConstraintName("exploracion_fisica_ibfk_1");

                    b.Navigation("Diagnostico");
                });

            modelBuilder.Entity("Core.Domain.Entities.GinecoObstetrico", b =>
                {
                    b.HasOne("Core.Domain.Entities.Expediente", "Expedediente")
                        .WithMany("GinecoObstetricos")
                        .HasForeignKey("ExpededienteId")
                        .HasConstraintName("gineco_obstetrico_ibfk_3");

                    b.HasOne("Core.Domain.Entities.FlujoVaginal", "FlujoVaginal")
                        .WithMany("GinecoObstetricos")
                        .HasForeignKey("FlujoVaginalId")
                        .HasConstraintName("gineco_obstetrico_ibfk_1");

                    b.HasOne("Core.Domain.Entities.TipoAnticonceptivo", "TipoAnticonceptivo")
                        .WithMany("GinecoObstetricos")
                        .HasForeignKey("TipoAnticonceptivoId")
                        .HasConstraintName("gineco_obstetrico_ibfk_2");

                    b.Navigation("Expedediente");

                    b.Navigation("FlujoVaginal");

                    b.Navigation("TipoAnticonceptivo");
                });

            modelBuilder.Entity("Core.Domain.Entities.HeredoFamiliar", b =>
                {
                    b.HasOne("Core.Domain.Entities.Expediente", "Expedediente")
                        .WithMany("HeredoFamiliars")
                        .HasForeignKey("ExpededienteId")
                        .HasConstraintName("heredo_familiar_ibfk_1");

                    b.Navigation("Expedediente");
                });

            modelBuilder.Entity("Core.Domain.Entities.MapaCorporal", b =>
                {
                    b.HasOne("Core.Domain.Entities.Diagnostico", "Diagnostico")
                        .WithMany("MapaCorporals")
                        .HasForeignKey("DiagnosticoId")
                        .HasConstraintName("mapa_corporal_ibfk_1");

                    b.Navigation("Diagnostico");
                });

            modelBuilder.Entity("Core.Domain.Entities.NoPatologico", b =>
                {
                    b.HasOne("Core.Domain.Entities.Expediente", "Expedediente")
                        .WithMany("NoPatologicos")
                        .HasForeignKey("ExpededienteId")
                        .HasConstraintName("no_patologico_ibfk_1");

                    b.Navigation("Expedediente");
                });

            modelBuilder.Entity("Core.Domain.Entities.Paciente", b =>
                {
                    b.HasOne("Core.Domain.Entities.EstadoCivil", "EstadoCivil")
                        .WithMany("Pacientes")
                        .HasForeignKey("EstadoCivilId")
                        .HasConstraintName("paciente_ibfk_1");

                    b.Navigation("EstadoCivil");
                });

            modelBuilder.Entity("Core.Domain.Entities.ProgramaFisioterapeutico", b =>
                {
                    b.HasOne("Core.Domain.Entities.Diagnostico", "Diagnostico")
                        .WithMany("ProgramaFisioterapeuticos")
                        .HasForeignKey("DiagnosticoId")
                        .HasConstraintName("programa_fisioterapeutico_ibfk_1");

                    b.Navigation("Diagnostico");
                });

            modelBuilder.Entity("Core.Domain.Entities.Revision", b =>
                {
                    b.HasOne("Core.Domain.Entities.Diagnostico", "Diagnostico")
                        .WithMany("Revisions")
                        .HasForeignKey("DiagnosticoId")
                        .HasConstraintName("revision_ibfk_2");

                    b.HasOne("Core.Domain.Entities.Fisioterapeutum", "Fisioterapeuta")
                        .WithMany("Revisions")
                        .HasForeignKey("FisioterapeutaId")
                        .HasConstraintName("revision_ibfk_1");

                    b.Navigation("Diagnostico");

                    b.Navigation("Fisioterapeuta");
                });

            modelBuilder.Entity("Core.Domain.Entities.Diagnostico", b =>
                {
                    b.Navigation("ExploracionFisicas");

                    b.Navigation("MapaCorporals");

                    b.Navigation("ProgramaFisioterapeuticos");

                    b.Navigation("Revisions");
                });

            modelBuilder.Entity("Core.Domain.Entities.EstadoCivil", b =>
                {
                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("Core.Domain.Entities.Expediente", b =>
                {
                    b.Navigation("Diagnosticos");

                    b.Navigation("GinecoObstetricos");

                    b.Navigation("HeredoFamiliars");

                    b.Navigation("NoPatologicos");
                });

            modelBuilder.Entity("Core.Domain.Entities.Fisioterapeutum", b =>
                {
                    b.Navigation("Revisions");
                });

            modelBuilder.Entity("Core.Domain.Entities.FlujoVaginal", b =>
                {
                    b.Navigation("GinecoObstetricos");
                });

            modelBuilder.Entity("Core.Domain.Entities.Paciente", b =>
                {
                    b.Navigation("Citas");

                    b.Navigation("Expedientes");
                });

            modelBuilder.Entity("Core.Domain.Entities.TipoAnticonceptivo", b =>
                {
                    b.Navigation("GinecoObstetricos");
                });
#pragma warning restore 612, 618
        }
    }
}
