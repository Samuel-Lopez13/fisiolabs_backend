using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public class Paciente
{
    public Paciente()
    {
        Citas = new HashSet<Cita>();
        Expedientes = new HashSet<Expediente>();
    }
    
    public int PacienteId { get; set; }

    public string Nombre { get; set; } = null!;
    
    public DateTime Edad { get; set; }
    
    public string? Apellido { get; set; }

    public bool Sexo { get; set; }

    public string Institucion { get; set; } = null!;

    public string Domicilio { get; set; } = null!;

    public int CodigoPostal { get; set; }

    public string Ocupacion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public int? EstadoCivilId { get; set; }
    
    public string? Notas { get; set; }
    
    public string? FotoPerfil {get; set;}

    public virtual EstadoCivil? EstadoCivil { get; set; }
    
    public virtual ICollection<Cita> Citas { get; set; } = new List<Cita>();
    public virtual ICollection<Expediente> Expedientes { get; set; } = new List<Expediente>();
}
