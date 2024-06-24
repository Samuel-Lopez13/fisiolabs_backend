using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public class ProgramaFisioterapeutico
{
    public int ProgramaFisioterapeuticoId { get; set; }

    public string CortoPlazo { get; set; } = null!;

    public string MedianoPlazo { get; set; } = null!;

    public string LargoPlazo { get; set; } = null!;

    public string TratamientoFisioterapeutico { get; set; } = null!;

    public string Sugerencias { get; set; } = null!;

    public string Pronostico { get; set; } = null!;

    public int DiagnosticoId { get; set; }

    public virtual Diagnostico? Diagnostico { get; set; }
}
