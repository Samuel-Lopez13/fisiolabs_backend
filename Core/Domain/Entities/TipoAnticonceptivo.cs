using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public class TipoAnticonceptivo
{
    public TipoAnticonceptivo()
    {
        GinecoObstetricos = new HashSet<GinecoObstetrico>();
    }
    
    public int TipoAnticonceptivoId { get; set; }

    public string? Anticonceptivo { get; set; }

    public virtual ICollection<GinecoObstetrico> GinecoObstetricos { get; set; } = new List<GinecoObstetrico>();
}
