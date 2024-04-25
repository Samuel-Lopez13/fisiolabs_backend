using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class Cita
{
    public int CitasId { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Motivo { get; set; }

    public int? PacienteId { get; set; }

    public virtual Paciente? Paciente { get; set; }
}
