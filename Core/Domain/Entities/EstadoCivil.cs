using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public class EstadoCivil
{
    public EstadoCivil()
    {
        Pacientes = new HashSet<Paciente>();
    }
    
    public int EstadoCivilId { get; set; }

    public string? EstadoCivil1 { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
