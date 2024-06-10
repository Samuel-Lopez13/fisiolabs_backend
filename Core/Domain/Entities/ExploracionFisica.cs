using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public class ExploracionFisica
{
    public int ExploracionFisicaId { get; set; }

    public float? Temperatura { get; set; }

    public int? Fr { get; set; }

    public int? Fc { get; set; }

    public string? PresionArterial { get; set; }

    public float? Peso { get; set; }

    public float? Estatura { get; set; }

    public float? Imc { get; set; }

    public float? IndiceCinturaCadera { get; set; }

    public float? SaturacionOxigeno { get; set; }

    public int? DiagnosticoId { get; set; }

    public virtual Diagnostico? Diagnostico { get; set; }
}
