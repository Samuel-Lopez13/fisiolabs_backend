using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public class HeredoFamiliar
{
    public int HeredoFamiliarId { get; set; }

    public int Padres { get; set; }

    public int PadresVivos { get; set; }

    public string? PadresCausaMuerte { get; set; }

    public int Hermanos { get; set; }

    public int HermanosVivos { get; set; }

    public string? HermanosCausaMuerte { get; set; }

    public int Hijos { get; set; }

    public int HijosVivos { get; set; }

    public string? HijosCausaMuerte { get; set; }

    public string? Dm { get; set; }

    public string? Hta { get; set; }

    public string? Cancer { get; set; }

    public string? Alcoholismo { get; set; }

    public string? Tabaquismo { get; set; }

    public string? Drogas { get; set; }
    
    public int ExpedienteId { get; set; }

    public virtual Expediente? Expediente { get; set; }
    
}
