using System;
using System.Collections.Generic;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
            entity.HasKey(e => e.CitasId);

            entity.ToTable("citas");

            entity.HasIndex(e => e.PacienteId, "paciente_id");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Citas)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("citas_ibfk_1");
        });

        modelBuilder.Entity<Diagnostico>(entity =>
        {
            entity.HasKey(e => e.DiagnosticoId);

            entity.ToTable("diagnostico");

            entity.HasIndex(e => e.ExpededienteId, "expediente_id");

            entity.HasOne(d => d.Expedediente).WithMany(p => p.Diagnosticos)
                .HasForeignKey(d => d.ExpededienteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("diagnostico_ibfk_1");
        });

        modelBuilder.Entity<EstadoCivil>(entity =>
        {
            entity.HasKey(e => e.EstadoCivilId);

            entity.ToTable("estado_civil");
        });

        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.HasKey(e => e.ExpedienteId);

            entity.ToTable("expediente");

            entity.HasIndex(e => e.PacienteId, "paciente_id").IsUnique();

            entity.HasOne(d => d.paciente).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("expediente_ibfk_1");
        });

        modelBuilder.Entity<ExploracionFisica>(entity =>
        {
            entity.HasKey(e => e.ExploracionFisicaId);

            entity.ToTable("exploracion_fisica");

            entity.HasIndex(e => e.DiagnosticoId, "diagnostico_id");
            
            entity.HasOne(d => d.Diagnostico).WithMany(p => p.ExploracionFisicas)
                .HasForeignKey(d => d.DiagnosticoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("exploracion_fisica_ibfk_1");
        });

        modelBuilder.Entity<Fisioterapeutum>(entity =>
        {
            entity.HasKey(e => e.FisioterapeutaId);

            entity.ToTable("fisioterapeuta");
        });

        modelBuilder.Entity<FlujoVaginal>(entity =>
        {
            entity.HasKey(e => e.FlujoVaginalId);

            entity.ToTable("flujo_vaginal");
        });

        modelBuilder.Entity<GinecoObstetrico>(entity =>
        {
            entity.HasKey(e => e.GinecoObstetricoId);

            entity.ToTable("gineco_obstetrico");

            entity.HasIndex(e => e.ExpedienteId, "expediente_id").IsUnique();

            entity.HasIndex(e => e.FlujoVaginalId, "flujo_vaginal_id");

            entity.HasIndex(e => e.TipoAnticonceptivoId, "tipo_anticonceptivo_id");

            entity.HasOne(d => d.Expediente).WithMany(p => p.GinecoObstetricos)
                .HasForeignKey(d => d.ExpedienteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("gineco_obstetrico_ibfk_3");

            entity.HasOne(d => d.FlujoVaginal).WithMany(p => p.GinecoObstetricos)
                .HasForeignKey(d => d.FlujoVaginalId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("gineco_obstetrico_ibfk_1");

            entity.HasOne(d => d.TipoAnticonceptivo).WithMany(p => p.GinecoObstetricos)
                .HasForeignKey(d => d.TipoAnticonceptivoId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("gineco_obstetrico_ibfk_2");
        });

        modelBuilder.Entity<HeredoFamiliar>(entity =>
        {
            entity.HasKey(e => e.HeredoFamiliarId);

            entity.ToTable("heredo_familiar");

            entity.HasIndex(e => e.ExpedienteId, "expediente_id").IsUnique();

            entity.HasOne(d => d.Expediente).WithMany(p => p.HeredoFamiliars)
                .HasForeignKey(d => d.ExpedienteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("heredo_familiar_ibfk_1");
        });

        modelBuilder.Entity<MapaCorporal>(entity =>
        {
            entity.HasKey(e => e.MapaCorporalId);

            entity.ToTable("mapa_corporal");

            entity.HasIndex(e => e.DiagnosticoId, "diagnostico_id");

            entity.Property(e => e.ValorX)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<int>>(v)
                );
            
            entity.Property(e => e.RangoDolor)
                .HasConversion(
                    x => JsonConvert.SerializeObject(x),
                    x => JsonConvert.DeserializeObject<List<int>>(x)
                );
            
            entity.HasOne(d => d.Diagnostico).WithMany(p => p.MapaCorporals)
                .HasForeignKey(d => d.DiagnosticoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mapa_corporal_ibfk_1");
        });

        modelBuilder.Entity<NoPatologico>(entity =>
        {
            entity.HasKey(e => e.NoPatologicoId);

            entity.ToTable("no_patologico");

            entity.HasIndex(e => e.ExpedienteId, "expediente_id").IsUnique();

            entity.HasOne(d => d.Expediente).WithMany(p => p.NoPatologicos)
                .HasForeignKey(d => d.ExpedienteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("no_patologico_ibfk_1");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.PacienteId);

            entity.ToTable("paciente");

            entity.HasIndex(e => e.EstadoCivilId, "estado_civil_id");
            
            entity.HasOne(d => d.EstadoCivil).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.EstadoCivilId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("paciente_ibfk_1");
        });

        modelBuilder.Entity<ProgramaFisioterapeutico>(entity =>
        {
            entity.HasKey(e => e.ProgramaFisioterapeuticoId);

            entity.ToTable("programa_fisioterapeutico");

            entity.HasIndex(e => e.DiagnosticoId, "diagnostico_id");

            entity.HasOne(d => d.Diagnostico).WithMany(p => p.ProgramaFisioterapeuticos)
                .HasForeignKey(d => d.DiagnosticoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("programa_fisioterapeutico_ibfk_1");
        });

        modelBuilder.Entity<Revision>(entity =>
        {
            entity.HasKey(e => e.RevisionId);

            entity.ToTable("revision");

            entity.HasIndex(e => e.DiagnosticoId, "diagnostico_id");

            entity.HasIndex(e => e.FisioterapeutaId, "fisioterapeuta_id");

            entity.HasOne(d => d.Diagnostico).WithMany(p => p.Revisions)
                .HasForeignKey(d => d.DiagnosticoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("revision_ibfk_2");

            entity.HasOne(d => d.Fisioterapeuta).WithMany(p => p.Revisions)
                .HasForeignKey(d => d.FisioterapeutaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("revision_ibfk_1");
        });

        modelBuilder.Entity<TipoAnticonceptivo>(entity =>
        {
            entity.HasKey(e => e.TipoAnticonceptivoId);

            entity.ToTable("tipo_anticonceptivo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId);

            entity.ToTable("usuario");

            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.HasIndex(e => e.Correo).IsUnique();
            entity.HasIndex(e => e.Telefono).IsUnique();
            entity.HasIndex(e => e.Username).IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
