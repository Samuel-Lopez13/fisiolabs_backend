using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public class GinecoObstetrico
{
    public int GinecoObstetricoId { get; set; }

    public string? Fum { get; set; }

    public string? Fpp { get; set; }

    public int? EdadGestional { get; set; }

    public int? Semanas { get; set; }

    public string? Menarca { get; set; }

    public string? Ritmo { get; set; }

    public int? Gestas { get; set; }

    public int? Partos { get; set; }

    public int? Cesareas { get; set; }

    public int? Abortos { get; set; }

    public string? Cirugias { get; set; }

    public int? FlujoVaginalId { get; set; }

    public int TipoAnticonceptivoId { get; set; }
    
    public int ExpedienteId { get; set; }

    public virtual Expediente? Expediente { get; set; }
    public virtual FlujoVaginal? FlujoVaginal { get; set; }
    public virtual TipoAnticonceptivo? TipoAnticonceptivo { get; set; }
}
