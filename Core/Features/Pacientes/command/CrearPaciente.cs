using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Services;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Pacientes.Command;

public record CrearPaciente : IRequest<CrearPacienteResponse>
{
    [Required]
    public string Nombre { get; set; }
    
    [Required]
    public DateTime Edad { get; set; } 

    [Required]
    public bool Sexo { get; set; }

    [Required]
    public string Institucion { get; set; }

    [Required]
    public string Domicilio { get; set; }
    
    [Required]
    public int CodigoPostal { get; set; }

    [Required]
    public string Ocupacion { get; set; }

    [Required]
    [MaxLength(10)]
    public string Telefono { get; set; }
    
    [Required]
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