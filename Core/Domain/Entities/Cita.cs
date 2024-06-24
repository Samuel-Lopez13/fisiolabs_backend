namespace Core.Domain.Entities;

public class Cita
{
    public int CitasId { get; set; }

    public DateTime Fecha { get; set; }

    public string Motivo { get; set; } = null!;

    public int PacienteId { get; set; }

    public virtual Paciente? Paciente { get; set; }
}
