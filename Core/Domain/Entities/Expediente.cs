using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class Expediente
{
    public int ExpedienteId { get; set; }

    public bool? TipoInterrogatorio { get; set; }

    public string? Responsable { get; set; }

    public string? AntecedentesPatologicos { get; set; }

    public int? PacienteId { get; set; }

    public virtual ICollection<Diagnostico> Diagnosticos { get; set; } = new List<Diagnostico>();

    public virtual ICollection<GinecoObstetrico> GinecoObstetricos { get; set; } = new List<GinecoObstetrico>();

    public virtual ICollection<HeredoFamiliar> HeredoFamiliars { get; set; } = new List<HeredoFamiliar>();

    public virtual ICollection<NoPatologico> NoPatologicos { get; set; } = new List<NoPatologico>();

    public virtual Paciente? Paciente { get; set; }
}
