using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class TipoAnticonceptivo
{
    public int TipoAnticonceptivoId { get; set; }

    public string? TipoAnticonceptivo1 { get; set; }

    public virtual ICollection<GinecoObstetrico> GinecoObstetricos { get; set; } = new List<GinecoObstetrico>();
}
