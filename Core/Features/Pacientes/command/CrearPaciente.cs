using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Services;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core.Features.Pacientes.Command;

public record CrearPaciente : IRequest<CrearPacienteResponse>
{
    [Required(ErrorMessage = "El campo Nombre es obligatorio")]
    public string Nombre { get; set; }
    
    [Required(ErrorMessage = "El campo Edad es obligatorio")]
    public DateTime Edad { get; set; } 

    [Required]
    public bool Sexo { get; set; }

    [Required(ErrorMessage = "El campo Institución es obligatorio")]
    public string Institucion { get; set; }

    [Required(ErrorMessage = "El campo Domicilio es obligatorio")]
    public string Domicilio { get; set; }
    
    [Required(ErrorMessage = "El campo Codigo Postal es obligatorio")]
    public int CodigoPostal { get; set; }

    [Required(ErrorMessage = "El campo Ocupación es obligatorio")]
    public string Ocupacion { get; set; }

    [Required(ErrorMessage = "El campo Telefono es obligatorio")]
    [RegularExpression(@"^\d{1,10}$", ErrorMessage = "El campo Telefono solo puede contener números")]
    [MaxLength(10)]
    [MinLength(10)]
    public string Telefono { get; set; }
    
    [Required(ErrorMessage = "El campo Estado Civil es obligatorio")]
    public int EstadoCivilId { get; set; }
    
    public string? FotoPerfil { get; set; }
}

public class CrearPacienteHandler : IRequestHandler<CrearPaciente, CrearPacienteResponse>
{
    private readonly FisiolabsSofwaredbContext _context;
    
    public CrearPacienteHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }
    
    public async Task<CrearPacienteResponse> Handle(CrearPaciente request, CancellationToken cancellationToken)
    {
        var validar = await _context.Pacientes.
            AsNoTracking().
            FirstOrDefaultAsync(x => x.Telefono == request.Telefono);
        
        if (validar != null) {
            throw new BadRequestException("Ya existe un paciente con el numero telefonico ingresado");
        }
        
        var paciente = new Paciente() {
            Nombre = request.Nombre,
            Edad = request.Edad,
            Sexo = request.Sexo,
            Institucion = request.Institucion,
            Domicilio = request.Domicilio,
            CodigoPostal = request.CodigoPostal,
            Ocupacion = request.Ocupacion,
            Telefono = request.Telefono,
            EstadoCivilId = request.EstadoCivilId,
            FotoPerfil = request.FotoPerfil == null ? "https://res.cloudinary.com/doi0znv2t/image/upload/v1718432025/Utils/fotoPerfil.png" : request.FotoPerfil
        };

        await _context.Pacientes.AddAsync(paciente);
        await _context.SaveChangesAsync();

        var response = new CrearPacienteResponse()
        {
            PacienteId = paciente.PacienteId
        };

        return response;
    }
}

public record CrearPacienteResponse
{
    public int PacienteId { get; set; }
}