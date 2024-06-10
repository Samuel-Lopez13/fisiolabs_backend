using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public class NoPatologico
{
    public int NoPatologicoId { get; set; }

    public string? MedioLaboral { get; set; }

    public string? MedioSociocultural { get; set; }

    public string? MedioFisicoambiental { get; set; }

    public int? ExpededienteId { get; set; }

    public virtual Expediente? Expedediente { get; set; }
}
