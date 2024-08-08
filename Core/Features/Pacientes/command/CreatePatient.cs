using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Pacientes.Command;

public record CreatePatient : IRequest<CreatePatientResponse>
{
    [Required(ErrorMessage = "El campo Nombre es obligatorio")]
    public string Nombre { get; set; }
    
    [Required(ErrorMessage = "El campo Apellido es obligatorio")]
    public string Apellido { get; set; }
    
    [Required(ErrorMessage = "El campo Institución es obligatorio")]
    public string Institucion { get; set; }

    [Required(ErrorMessage = "El campo Domicilio es obligatorio")]
    public string Domicilio { get; set; }
    
    [Required(ErrorMessage = "El campo Ocupación es obligatorio")]
    public string Ocupacion { get; set; }

    [Required(ErrorMessage = "El campo Telefono es obligatorio")]
    [Phone(ErrorMessage = "El campo Telefono no es valido")]
    public string Telefono { get; set; }
    
    public string? FotoPerfil { get; set; }
    
    public string? Notas { get; set; }
    
    [Required(ErrorMessage = "El campo Sexo es obligatorio")]
    public bool Sexo { get; set; }
    
    [Required(ErrorMessage = "El campo TipoPaciente es obligatorio")]
    public bool TipoPaciente { get; set; }
    
    [Required(ErrorMessage = "El campo Edad es obligatorio")]
    public DateTime Edad { get; set; } 
    
    [Required(ErrorMessage = "El campo Codigo Postal es obligatorio")]
    public int CodigoPostal { get; set; }
    
    [Required(ErrorMessage = "El campo Estado Civil es obligatorio")]
    public string EstadoCivilId { get; set; }
    
    [Required(ErrorMessage = "El campo Fisioterapeuta es obligatorio")]
    public string FisioterapeutaId { get; set; }
    
}

public class CreatePatientHandler : IRequestHandler<CreatePatient, CreatePatientResponse>
{
    private readonly FisioContext _context;
    
    public CreatePatientHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task<CreatePatientResponse> Handle(CreatePatient request, CancellationToken cancellationToken)
    {
        var patient = new Paciente() {
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            Institucion = request.Institucion,
            Domicilio = request.Domicilio,
            Ocupacion = request.Ocupacion,
            Telefono = request.Telefono,
            FotoPerfil = request.FotoPerfil ?? "https://res.cloudinary.com/doi0znv2t/image/upload/v1718432025/Utils/fotoPerfil.png",
            Notas = request.Notas,
            Sexo = request.Sexo,
            TipoPaciente = request.TipoPaciente,
            Status = true, //Activo
            Edad = request.Edad,
            CodigoPostal = request.CodigoPostal,
            EstadoCivilId = request.EstadoCivilId.HashIdInt(),
            FisioterapeutaId = request.FisioterapeutaId.HashIdInt()
        };

        await _context.Pacientes.AddAsync(patient);
        await _context.SaveChangesAsync();

        var response = new CreatePatientResponse()
        {
            PacienteId = patient.PacienteId.HashId()
        };

        return response;
    }
}

public record CreatePatientResponse
{
    public string PacienteId { get; set; }
}