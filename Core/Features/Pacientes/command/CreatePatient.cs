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
    [RegularExpression(@"^\d{1,10}$", ErrorMessage = "El campo Telefono solo puede contener números")]
    [MaxLength(10)]
    [MinLength(10)]
    public string Telefono { get; set; }
    
    public string? FotoPerfil { get; set; }
    
    public string? Notas { get; set; }
    
    [Required]
    public bool Sexo { get; set; }
    
    [Required]
    public bool TipoPaciente { get; set; }
    
    [Required(ErrorMessage = "El campo Edad es obligatorio")]
    public DateTime Edad { get; set; } 
    
    [Required(ErrorMessage = "El campo Codigo Postal es obligatorio")]
    public int CodigoPostal { get; set; }
    
    [Required(ErrorMessage = "El campo Estado Civil es obligatorio")]
    public int EstadoCivilId { get; set; }
    
    [Required(ErrorMessage = "El campo Fisioterapeuta es obligatorio")]
    public int FisioterapeutaId { get; set; }
    
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
        /*var validate = await _context.Pacientes.
            AsNoTracking().
            FirstOrDefaultAsync(x => x.Telefono == request.Telefono);

        if (validate != null) {
            throw new BadRequestException("Ya existe un paciente con el numero telefonico ingresado");
        }*/
        
        var patient = new Paciente() {
            Nombre = request.Nombre,
            Apellido = request.Apellido,
            Institucion = request.Institucion,
            Domicilio = request.Domicilio,
            Ocupacion = request.Ocupacion,
            Telefono = request.Telefono,
            FotoPerfil = request.FotoPerfil == null ? "https://res.cloudinary.com/doi0znv2t/image/upload/v1718432025/Utils/fotoPerfil.png" : request.FotoPerfil,
            Notas = request.Notas,
            Sexo = request.Sexo,
            TipoPaciente = request.TipoPaciente,
            Status = true, //Activo
            Edad = request.Edad,
            CodigoPostal = request.CodigoPostal,
            EstadoCivilId = request.EstadoCivilId,
            FisioterapeutaId = request.FisioterapeutaId
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