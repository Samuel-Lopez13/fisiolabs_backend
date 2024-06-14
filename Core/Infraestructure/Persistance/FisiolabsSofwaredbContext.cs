using System;
using System.Collections.Generic;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Infraestructure.Persistance;

public partial class FisiolabsSofwaredbContext : DbContext
{
    public FisiolabsSofwaredbContext() { }

    public FisiolabsSofwaredbContext(DbContextOptions<FisiolabsSofwaredbContext> options)
        : base(options) { }

    public virtual DbSet<Cita> Citas { get; set; }
    public virtual DbSet<Diagnostico> Diagnosticos { get; set; }
    public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }
    public virtual DbSet<Expediente> Expedientes { get; set; }
    public virtual DbSet<ExploracionFisica> ExploracionFisicas { get; set; }
    public virtual DbSet<Fisioterapeutum> Fisioterapeuta { get; set; }
    public virtual DbSet<FlujoVaginal> FlujoVaginals { get; set; }
    public virtual DbSet<GinecoObstetrico> GinecoObstetricos { get; set; }
    public virtual DbSet<HeredoFamiliar> HeredoFamiliars { get; set; }
    public virtual DbSet<MapaCorporal> MapaCorporals { get; set; }
    public virtual DbSet<NoPatologico> NoPatologicos { get; set; }
    public virtual DbSet<Paciente> Pacientes { get; set; }
    public virtual DbSet<ProgramaFisioterapeutico> ProgramaFisioterapeuticos { get; set; }
    public virtual DbSet<Revision> Revisions { get; set; }
    public virtual DbSet<TipoAnticonceptivo> TipoAnticonceptivos { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.CitasId).HasName("PRIMARY");

            entity.ToTable("citas");

            entity.HasIndex(e => e.PacienteId, "paciente_id");

            entity.Property(e => e.CitasId).HasColumnName("citas_id");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Motivo)
                .HasMaxLength(100)
                .HasColumnName("motivo");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Citas)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("citas_ibfk_1");
        });

        modelBuilder.Entity<Diagnostico>(entity =>
        {
            entity.HasKey(e => e.DiagnosticoId).HasName("PRIMARY");

            entity.ToTable("diagnostico");

            entity.HasIndex(e => e.ExpededienteId, "expedediente_id");

            entity.Property(e => e.DiagnosticoId).HasColumnName("diagnostico_id");
            entity.Property(e => e.Categoria)
                .HasMaxLength(15)
                .HasColumnName("categoria");
            entity.Property(e => e.Diagnostico1)
                .HasMaxLength(300)
                .HasColumnName("diagnostico");
            entity.Property(e => e.DiagnosticoFinal)
                .HasMaxLength(300)
                .HasColumnName("diagnostico_final");
            entity.Property(e => e.DiagnosticoFuncional)
                .HasMaxLength(300)
                .HasColumnName("diagnostico_funcional");
            entity.Property(e => e.DiagnosticoInicial)
                .HasMaxLength(300)
                .HasColumnName("diagnostico_inicial");
            entity.Property(e => e.DiagnosticoNosologico)
                .HasMaxLength(300)
                .HasColumnName("diagnostico_nosologico");
            entity.Property(e => e.DiagnosticoPrevio)
                .HasMaxLength(300)
                .HasColumnName("diagnostico_previo");
            entity.Property(e => e.EstudiosComplementarios)
                .HasMaxLength(300)
                .HasColumnName("estudios_complementarios");
            entity.Property(e => e.ExpededienteId).HasColumnName("expedediente_id");
            entity.Property(e => e.FechaAlta)
                .HasColumnType("date")
                .HasColumnName("fecha_alta");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.FrecuenciaTratamiento)
                .HasMaxLength(50)
                .HasColumnName("frecuencia_tratamiento");
            entity.Property(e => e.Inspeccion)
                .HasMaxLength(300)
                .HasColumnName("inspeccion");
            entity.Property(e => e.MotivoAlta)
                .HasMaxLength(200)
                .HasColumnName("motivo_alta");
            entity.Property(e => e.Movibilidad)
                .HasMaxLength(300)
                .HasColumnName("movibilidad");
            entity.Property(e => e.PadecimientoActual)
                .HasMaxLength(300)
                .HasColumnName("padecimiento_actual");
            entity.Property(e => e.Palpitacion)
                .HasMaxLength(300)
                .HasColumnName("palpitacion");
            entity.Property(e => e.Refiere)
                .HasMaxLength(50)
                .HasColumnName("refiere");
            entity.Property(e => e.TerapeuticaEmpleada)
                .HasMaxLength(300)
                .HasColumnName("terapeutica_empleada");

            entity.HasOne(d => d.Expedediente).WithMany(p => p.Diagnosticos)
                .HasForeignKey(d => d.ExpededienteId)
                .HasConstraintName("diagnostico_ibfk_1");
        });

        modelBuilder.Entity<EstadoCivil>(entity =>
        {
            entity.HasKey(e => e.EstadoCivilId).HasName("PRIMARY");

            entity.ToTable("estado_civil");

            entity.Property(e => e.EstadoCivilId).HasColumnName("estado_civil_id");
            entity.Property(e => e.EstadoCivil1)
                .HasMaxLength(10)
                .HasColumnName("estado_civil");
        });

        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.HasKey(e => e.ExpedienteId).HasName("PRIMARY");

            entity.ToTable("expediente");

            entity.HasIndex(e => e.PacienteId, "paciente_id");

            entity.Property(e => e.ExpedienteId).HasColumnName("expediente_id");
            entity.Property(e => e.AntecedentesPatologicos)
                .HasMaxLength(300)
                .HasColumnName("antecedentes_patologicos");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.Responsable)
                .HasMaxLength(20)
                .HasColumnName("responsable");
            entity.Property(e => e.TipoInterrogatorio).HasColumnName("tipo_interrogatorio");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("expediente_ibfk_1");
        });

        modelBuilder.Entity<ExploracionFisica>(entity =>
        {
            entity.HasKey(e => e.ExploracionFisicaId).HasName("PRIMARY");

            entity.ToTable("exploracion_fisica");

            entity.HasIndex(e => e.DiagnosticoId, "diagnostico_id");

            entity.Property(e => e.ExploracionFisicaId).HasColumnName("exploracion_fisica_id");
            entity.Property(e => e.DiagnosticoId).HasColumnName("diagnostico_id");
            entity.Property(e => e.Estatura).HasColumnName("estatura");
            entity.Property(e => e.Fc).HasColumnName("FC");
            entity.Property(e => e.Fr).HasColumnName("FR");
            entity.Property(e => e.Imc).HasColumnName("IMC");
            entity.Property(e => e.IndiceCinturaCadera).HasColumnName("indice_cintura_cadera");
            entity.Property(e => e.Peso).HasColumnName("peso");
            entity.Property(e => e.PresionArterial)
                .HasMaxLength(50)
                .HasColumnName("presion_arterial");
            entity.Property(e => e.SaturacionOxigeno).HasColumnName("saturacion_oxigeno");
            entity.Property(e => e.Temperatura).HasColumnName("temperatura");

            entity.HasOne(d => d.Diagnostico).WithMany(p => p.ExploracionFisicas)
                .HasForeignKey(d => d.DiagnosticoId)
                .HasConstraintName("exploracion_fisica_ibfk_1");
        });

        modelBuilder.Entity<Fisioterapeutum>(entity =>
        {
            entity.HasKey(e => e.FisioterapeutaId).HasName("PRIMARY");

            entity.ToTable("fisioterapeuta");

            entity.Property(e => e.FisioterapeutaId).HasColumnName("fisioterapeuta_id");
            entity.Property(e => e.Fisioterapeuta)
                .HasMaxLength(50)
                .HasColumnName("fisioterapeuta");
        });

        modelBuilder.Entity<FlujoVaginal>(entity =>
        {
            entity.HasKey(e => e.FlujoVaginalId).HasName("PRIMARY");

            entity.ToTable("flujo_vaginal");

            entity.Property(e => e.FlujoVaginalId).HasColumnName("flujo_vaginal_id");
            entity.Property(e => e.FlujoVaginal1)
                .HasMaxLength(50)
                .HasColumnName("flujo_vaginal");
        });

        modelBuilder.Entity<GinecoObstetrico>(entity =>
        {
            entity.HasKey(e => e.GinecoObstetricoId).HasName("PRIMARY");

            entity.ToTable("gineco_obstetrico");

            entity.HasIndex(e => e.ExpededienteId, "expedediente_id");

            entity.HasIndex(e => e.FlujoVaginalId, "flujo_vaginal_id");

            entity.HasIndex(e => e.TipoAnticonceptivoId, "tipo_anticonceptivo_id");

            entity.Property(e => e.GinecoObstetricoId).HasColumnName("gineco_obstetrico_id");
            entity.Property(e => e.Abortos).HasColumnName("abortos");
            entity.Property(e => e.Cesareas).HasColumnName("cesareas");
            entity.Property(e => e.Cirugias)
                .HasMaxLength(100)
                .HasColumnName("cirugias");
            entity.Property(e => e.EdadGestional).HasColumnName("edad_gestional");
            entity.Property(e => e.ExpededienteId).HasColumnName("expedediente_id");
            entity.Property(e => e.FlujoVaginalId).HasColumnName("flujo_vaginal_id");
            entity.Property(e => e.Fpp)
                .HasMaxLength(50)
                .HasColumnName("FPP");
            entity.Property(e => e.Fum)
                .HasMaxLength(50)
                .HasColumnName("FUM");
            entity.Property(e => e.Gestas).HasColumnName("gestas");
            entity.Property(e => e.Menarca)
                .HasMaxLength(50)
                .HasColumnName("menarca");
            entity.Property(e => e.Partos).HasColumnName("partos");
            entity.Property(e => e.Ritmo)
                .HasMaxLength(50)
                .HasColumnName("ritmo");
            entity.Property(e => e.Semanas).HasColumnName("semanas");
            entity.Property(e => e.TipoAnticonceptivoId).HasColumnName("tipo_anticonceptivo_id");

            entity.HasOne(d => d.Expedediente).WithMany(p => p.GinecoObstetricos)
                .HasForeignKey(d => d.ExpededienteId)
                .HasConstraintName("gineco_obstetrico_ibfk_3");

            entity.HasOne(d => d.FlujoVaginal).WithMany(p => p.GinecoObstetricos)
                .HasForeignKey(d => d.FlujoVaginalId)
                .HasConstraintName("gineco_obstetrico_ibfk_1");

            entity.HasOne(d => d.TipoAnticonceptivo).WithMany(p => p.GinecoObstetricos)
                .HasForeignKey(d => d.TipoAnticonceptivoId)
                .HasConstraintName("gineco_obstetrico_ibfk_2");
        });

        modelBuilder.Entity<HeredoFamiliar>(entity =>
        {
            entity.HasKey(e => e.HeredoFamiliarId).HasName("PRIMARY");

            entity.ToTable("heredo_familiar");

            entity.HasIndex(e => e.ExpededienteId, "expedediente_id");

            entity.Property(e => e.HeredoFamiliarId).HasColumnName("heredo_familiar_id");
            entity.Property(e => e.Alcoholismo)
                .HasMaxLength(100)
                .HasColumnName("alcoholismo");
            entity.Property(e => e.Cancer)
                .HasMaxLength(100)
                .HasColumnName("cancer");
            entity.Property(e => e.Dm)
                .HasMaxLength(100)
                .HasColumnName("dm");
            entity.Property(e => e.Drogas)
                .HasMaxLength(100)
                .HasColumnName("drogas");
            entity.Property(e => e.ExpededienteId).HasColumnName("expedediente_id");
            entity.Property(e => e.Hermanos).HasColumnName("hermanos");
            entity.Property(e => e.HermanosCausaMuerte)
                .HasMaxLength(300)
                .HasColumnName("hermanos_causa_muerte");
            entity.Property(e => e.HermanosVivos).HasColumnName("hermanos_vivos");
            entity.Property(e => e.Hijos).HasColumnName("hijos");
            entity.Property(e => e.HijosCausaMuerte)
                .HasMaxLength(300)
                .HasColumnName("hijos_causa_muerte");
            entity.Property(e => e.HijosVivos).HasColumnName("hijos_vivos");
            entity.Property(e => e.Hta)
                .HasMaxLength(100)
                .HasColumnName("hta");
            entity.Property(e => e.Padres).HasColumnName("padres");
            entity.Property(e => e.PadresCausaMuerte)
                .HasMaxLength(300)
                .HasColumnName("padres_causa_muerte");
            entity.Property(e => e.PadresVivos).HasColumnName("padres_vivos");
            entity.Property(e => e.Tabaquismo)
                .HasMaxLength(100)
                .HasColumnName("tabaquismo");

            entity.HasOne(d => d.Expedediente).WithMany(p => p.HeredoFamiliars)
                .HasForeignKey(d => d.ExpededienteId)
                .HasConstraintName("heredo_familiar_ibfk_1");
        });

        modelBuilder.Entity<MapaCorporal>(entity =>
        {
            entity.HasKey(e => e.MapaCorporalId).HasName("PRIMARY");

            entity.ToTable("mapa_corporal");

            entity.HasIndex(e => e.DiagnosticoId, "diagnostico_id");

            entity.Property(e => e.MapaCorporalId).HasColumnName("mapa_corporal_id");
            entity.Property(e => e.DiagnosticoId).HasColumnName("diagnostico_id");
            entity.Property(e => e.Nota)
                .HasMaxLength(100)
                .HasColumnName("nota");
            entity.Property(e => e.RangoDolor).HasColumnName("rango_dolor");
            entity.Property(e => e.ValorX).HasColumnName("valor_x");
            entity.Property(e => e.ValorY).HasColumnName("valor_y");

            entity.HasOne(d => d.Diagnostico).WithMany(p => p.MapaCorporals)
                .HasForeignKey(d => d.DiagnosticoId)
                .HasConstraintName("mapa_corporal_ibfk_1");
        });

        modelBuilder.Entity<NoPatologico>(entity =>
        {
            entity.HasKey(e => e.NoPatologicoId).HasName("PRIMARY");

            entity.ToTable("no_patologico");

            entity.HasIndex(e => e.ExpededienteId, "expedediente_id");

            entity.Property(e => e.NoPatologicoId).HasColumnName("no_patologico_id");
            entity.Property(e => e.ExpededienteId).HasColumnName("expedediente_id");
            entity.Property(e => e.MedioFisicoambiental)
                .HasMaxLength(300)
                .HasColumnName("medio_fisicoambiental");
            entity.Property(e => e.MedioLaboral)
                .HasMaxLength(300)
                .HasColumnName("medio_laboral");
            entity.Property(e => e.MedioSociocultural)
                .HasMaxLength(300)
                .HasColumnName("medio_sociocultural");

            entity.HasOne(d => d.Expedediente).WithMany(p => p.NoPatologicos)
                .HasForeignKey(d => d.ExpededienteId)
                .HasConstraintName("no_patologico_ibfk_1");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.PacienteId).HasName("PRIMARY");

            entity.ToTable("paciente");

            entity.HasIndex(e => e.EstadoCivilId, "estado_civil_id");

            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.CodigoPostal).HasColumnName("codigo_postal");
            entity.Property(e => e.Domicilio)
                .HasMaxLength(50)
                .HasColumnName("domicilio");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.EstadoCivilId).HasColumnName("estado_civil_id");
            entity.Property(e => e.Institucion)
                .HasMaxLength(50)
                .HasColumnName("institucion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Ocupacion)
                .HasMaxLength(50)
                .HasColumnName("ocupacion");
            entity.Property(e => e.Sexo).HasColumnName("sexo");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .HasColumnName("telefono");

            entity.HasOne(d => d.EstadoCivil).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.EstadoCivilId)
                .HasConstraintName("paciente_ibfk_1");
        });

        modelBuilder.Entity<ProgramaFisioterapeutico>(entity =>
        {
            entity.HasKey(e => e.ProgramaFisioterapeuticoId).HasName("PRIMARY");

            entity.ToTable("programa_fisioterapeutico");

            entity.HasIndex(e => e.DiagnosticoId, "diagnostico_id");

            entity.Property(e => e.ProgramaFisioterapeuticoId).HasColumnName("programa_fisioterapeutico_id");
            entity.Property(e => e.CortoPlazo)
                .HasMaxLength(200)
                .HasColumnName("corto_plazo");
            entity.Property(e => e.DiagnosticoId).HasColumnName("diagnostico_id");
            entity.Property(e => e.LargoPlazo)
                .HasMaxLength(200)
                .HasColumnName("largo_plazo");
            entity.Property(e => e.MedianoPlazo)
                .HasMaxLength(200)
                .HasColumnName("mediano_plazo");
            entity.Property(e => e.Pronostico)
                .HasMaxLength(200)
                .HasColumnName("pronostico");
            entity.Property(e => e.Sugerencias)
                .HasMaxLength(200)
                .HasColumnName("sugerencias");
            entity.Property(e => e.TratamientoFisioterapeutico)
                .HasMaxLength(200)
                .HasColumnName("tratamiento_fisioterapeutico");

            entity.HasOne(d => d.Diagnostico).WithMany(p => p.ProgramaFisioterapeuticos)
                .HasForeignKey(d => d.DiagnosticoId)
                .HasConstraintName("programa_fisioterapeutico_ibfk_1");
        });

        modelBuilder.Entity<Revision>(entity =>
        {
            entity.HasKey(e => e.RevisionId).HasName("PRIMARY");

            entity.ToTable("revision");

            entity.HasIndex(e => e.DiagnosticoId, "diagnostico_id");

            entity.HasIndex(e => e.FisioterapeutaId, "fisioterapeuta_id");

            entity.Property(e => e.RevisionId).HasColumnName("revision_id");
            entity.Property(e => e.DiagnosticoId).HasColumnName("diagnostico_id");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.FisioterapeutaId).HasColumnName("fisioterapeuta_id");
            entity.Property(e => e.Revision1)
                .HasMaxLength(300)
                .HasColumnName("revision");

            entity.HasOne(d => d.Diagnostico).WithMany(p => p.Revisions)
                .HasForeignKey(d => d.DiagnosticoId)
                .HasConstraintName("revision_ibfk_2");

            entity.HasOne(d => d.Fisioterapeuta).WithMany(p => p.Revisions)
                .HasForeignKey(d => d.FisioterapeutaId)
                .HasConstraintName("revision_ibfk_1");
        });

        modelBuilder.Entity<TipoAnticonceptivo>(entity =>
        {
            entity.HasKey(e => e.TipoAnticonceptivoId).HasName("PRIMARY");

            entity.ToTable("tipo_anticonceptivo");

            entity.Property(e => e.TipoAnticonceptivoId).HasColumnName("tipo_anticonceptivo_id");
            entity.Property(e => e.Anticonceptivo)
                .HasMaxLength(50)
                .HasColumnName("tipo_anticonceptivo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.HasIndex(e => e.Username).IsUnique();
            entity.HasIndex(e => e.Correo).IsUnique();
            entity.HasIndex(e => e.Telefono).IsUnique();
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
