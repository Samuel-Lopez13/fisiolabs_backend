using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Fisioterapeutas.command;

public record PostFisioterapeutas : IRequest
{
    [Required(ErrorMessage = "El campo Nombre es obligatorio")]
    public string Nombre { get; set; }
    
    [Required(ErrorMessage = "El campo Correo es obligatorio")]
    public string Correo { get; set; }
    
    [Required(ErrorMessage = "El campo Telefono es obligatorio")]
    public string Telefono { get; set; }
    
    [Required(ErrorMessage = "El campo Especialidad es obligatorio")]
    public string Especialidad { get; set; }
    
    [Required(ErrorMessage = "El campo Cedula es obligatorio")]
    public string Cedula { get; set; }
    
    public string? Foto { get; set; }
}

public class PostFisioterapeutasHandler : IRequestHandler<PostFisioterapeutas>
{
    private readonly FisiolabsSofwaredbContext _context;

    public PostFisioterapeutasHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PostFisioterapeutas request, CancellationToken cancellationToken)
    {
        var fisioterapeuta = _context.Fisioterapeuta.FirstOrDefault(x => x.Correo == request.Correo 
                                                                         || x.CedulaProfesional == request.Cedula
                                                                         || x.Telefono == request.Telefono);
        
        if(request.Correo == fisioterapeuta.Correo)
            throw new BadRequestException("El correo ya esta registrado");

        if (request.Cedula == fisioterapeuta.CedulaProfesional)
            throw new BadRequestException("La cedula ya esta registrada");
        
        if (request.Telefono == fisioterapeuta.Telefono)
            throw new BadRequestException("El telefono ya esta registrado");
        
        var fisio = new Fisioterapeutum()
        {
            Fisioterapeuta = request.Nombre,
            Correo = request.Correo,
            Telefono = request.Telefono,
            Especialidad = request.Especialidad,
            CedulaProfesional = request.Cedula,
            Foto = request.Foto == null ? "https://res.cloudinary.com/doi0znv2t/image/upload/v1718432025/Utils/fotoPerfil.png" : request.Foto
        };

        await _context.Fisioterapeuta.AddAsync(fisio);
        await _context.SaveChangesAsync();
    }
}