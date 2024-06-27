using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public class NoPatologico
{
    public int NoPatologicoId { get; set; }

    public string MedioLaboral { get; set; } = null!;

    public string MedioSociocultural { get; set; } = null!;

    public string MedioFisicoambiental { get; set; } = null!;
    
    public int ExpedienteId { get; set; }
    
    public virtual Expediente? Expediente { get; set; }
}
