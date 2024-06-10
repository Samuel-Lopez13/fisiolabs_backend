using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class Revision
{
    public int RevisionId { get; set; }

    public string? Revision1 { get; set; }

    public DateTime? Fecha { get; set; }

    public int? FisioterapeutaId { get; set; }

    public int? DiagnosticoId { get; set; }

    public virtual Diagnostico? Diagnostico { get; set; }
    public virtual Fisioterapeutum? Fisioterapeuta { get; set; }
}
