using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public class FlujoVaginal
{
    public FlujoVaginal()
    {
        GinecoObstetricos = new HashSet<GinecoObstetrico>();
    }
    
    public int FlujoVaginalId { get; set; }

    public string Flujo { get; set; } = null!;

    public virtual ICollection<GinecoObstetrico> GinecoObstetricos { get; set; } = new List<GinecoObstetrico>();
}
