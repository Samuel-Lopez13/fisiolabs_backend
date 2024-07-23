using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public class Revision
{
    public int RevisionId { get; set; }

    public string Notas { get; set; } = null!;

    public DateTime Fecha { get; set; }
    
    public TimeSpan Hora { get; set; }
    
    public string ComprobantePago { get; set; }

    public int? FisioterapeutaId { get; set; }

    public int DiagnosticoId { get; set; }

    public virtual Diagnostico? Diagnostico { get; set; }
    public virtual Fisioterapeutum? Fisioterapeuta { get; set; }
}
