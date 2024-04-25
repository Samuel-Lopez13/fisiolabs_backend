using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class MapaCorporal
{
    public int MapaCorporalId { get; set; }

    public int? ValorX { get; set; }

    public int? ValorY { get; set; }

    public int? RangoDolor { get; set; }

    public string? Nota { get; set; }

    public int? DiagnosticoId { get; set; }

    public virtual Diagnostico? Diagnostico { get; set; }
}
