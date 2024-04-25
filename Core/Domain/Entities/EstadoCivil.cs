using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class EstadoCivil
{
    public int EstadoCivilId { get; set; }

    public string? EstadoCivil1 { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
