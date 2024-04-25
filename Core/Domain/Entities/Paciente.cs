using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class Paciente
{
    public int PacienteId { get; set; }

    public string? Nombre { get; set; }

    public int? Edad { get; set; }

    public bool? Sexo { get; set; }

    public string? Institucion { get; set; }

    public string? Domicilio { get; set; }

    public int? CodigoPostal { get; set; }

    public string? Ocupacion { get; set; }

    public string? Telefono { get; set; }

    public int? EstadoCivilId { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual EstadoCivil? EstadoCivil { get; set; }

    public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
}
