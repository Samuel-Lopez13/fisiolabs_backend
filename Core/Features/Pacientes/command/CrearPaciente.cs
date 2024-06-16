using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Services;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Pacientes.Command;

public record CrearPaciente : IRequest
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

public class CrearPacienteHandler : IRequestHandler<CrearPaciente>
{
    private readonly FisiolabsSofwaredbContext _context;
    private readonly IUploadFile _uploadFile;
    
    public CrearPacienteHandler(FisiolabsSofwaredbContext context, IUploadFile uploadFile)
    {
        _context = context;
        _uploadFile = uploadFile;
    }
    
    public async Task Handle(CrearPaciente request, CancellationToken cancellationToken)
    {
        var validar = await _context.Pacientes.
            AsNoTracking().
            FirstOrDefaultAsync(x => x.Telefono == request.Telefono);

        if (validar != null) {
            throw new BadRequestException("Ya existe un paciente con el numero telefonico ingresado");
        }

        var fotoPerfil = "";

        if (request.FotoPerfil == null)
            fotoPerfil = "https://res.cloudinary.com/doi0znv2t/image/upload/v1718432025/Utils/fotoPerfil.png";
        //else 
            //fotoPerfil = _uploadFile.UploadImages(request.FotoPerfil, validar.PacienteId + ": Paciente");
        
        
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
            FotoPerfil = fotoPerfil
        };

        await _context.Pacientes.AddAsync(paciente);
        await _context.SaveChangesAsync();
    }
}