using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class ProgramaFisioterapeutico
{
    public int ProgramaFisioterapeuticoId { get; set; }

    public string? CortoPlazo { get; set; }

    public string? MedianoPlazo { get; set; }

    public string? LargoPlazo { get; set; }

    public string? TratamientoFisioterapeutico { get; set; }

    public string? Sugerencias { get; set; }

    public string? Pronostico { get; set; }

    public int? DiagnosticoId { get; set; }

    public virtual Diagnostico? Diagnostico { get; set; }
}
