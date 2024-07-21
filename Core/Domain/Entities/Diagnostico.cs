namespace Core.Domain.Entities;

public class Diagnostico
{
    public Diagnostico()
    {
        ExploracionFisicas = new HashSet<ExploracionFisica>();
        MapaCorporals = new HashSet<MapaCorporal>();
        ProgramaFisioterapeuticos = new HashSet<ProgramaFisioterapeutico>();
        Revisions = new HashSet<Revision>();
    }
    
    public int DiagnosticoId { get; set; }

    public string? MotivoAlta { get; set; } //Se llena al finalizar el tratamiento

    public DateTime FechaInicio { get; set; }

    public DateTime? FechaAlta { get; set; } //Se llena al finalizar el tratamiento

    public bool Estatus { get; set; } // 1 Activo 0 Inactivo

    public string? Categoria { get; set; }

    public string? DiagnosticoInicial { get; set; } //Se llena al finalizar el tratamiento

    public string? DiagnosticoFinal { get; set; } //Se llena al finalizar el tratamiento

    public string? DiagnosticoPrevio { get; set; }

    public string? DiagnosticoFuncional { get; set; }

    public string? Diagnostico1 { get; set; }

    public string? FrecuenciaTratamiento { get; set; } //Se llena al finalizar el tratamiento

    public string? PadecimientoActual { get; set; }

    public string? Refiere { get; set; }

    public string? TerapeuticaEmpleada { get; set; }

    public string? Inspeccion { get; set; }

    public string? Palpitacion { get; set; }

    public string? Movibilidad { get; set; }

    public string? EstudiosComplementarios { get; set; }

    public string? DiagnosticoNosologico { get; set; }

    public int ExpededienteId { get; set; }

    public virtual Expediente? Expedediente { get; set; }

    public virtual ICollection<ExploracionFisica> ExploracionFisicas { get; set; } = new List<ExploracionFisica>();
    public virtual ICollection<MapaCorporal> MapaCorporals { get; set; } = new List<MapaCorporal>();
    public virtual ICollection<ProgramaFisioterapeutico> ProgramaFisioterapeuticos { get; set; } = new List<ProgramaFisioterapeutico>();
    public virtual ICollection<Revision> Revisions { get; set; } = new List<Revision>();
}
