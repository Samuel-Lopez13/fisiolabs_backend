using System.ComponentModel.DataAnnotations;

namespace Core.Features.Diagnostico.command;

public record ExplorationPost()
{
    [Required(ErrorMessage = "El campo Temperatura es obligatorio")]
    public float Temperatura { get; set; }
    
    [Required(ErrorMessage = "El campo Fr es obligatorio")]
    public int Fr { get; set; }
    
    [Required(ErrorMessage = "El campo Fc es obligatorio")]
    public int Fc { get; set; }
    
    [Required(ErrorMessage = "El campo PresionArterial es obligatorio")]
    public string PresionArterial { get; set; }
    
    [Required(ErrorMessage = "El campo Peso es obligatorio")]
    public float Peso { get; set; }
    
    [Required(ErrorMessage = "El campo Estatura es obligatorio")]
    public float Estatura { get; set; }
    
    [Required(ErrorMessage = "El campo Imc es obligatorio")]
    public float Imc { get; set; }
    
    [Required(ErrorMessage = "El campo IndiceCinturaCadera es obligatorio")]
    public float IndiceCinturaCadera { get; set; }
    
    [Required(ErrorMessage = "El campo SaturacionOxigeno es obligatorio")]
    public float SaturacionOxigeno { get; set; }
}

public record PostDiagnostic()
{
    
}

public record MapPost()
{
    
}

public record ProgramPost()
{
    
}

public record ReviewPost()
{
    
}

public record GeneralDiagnosticPost()
{
    public string ExpedienteId { get; set; }
}

public record PostDiagnosticResponse()
{
    
}