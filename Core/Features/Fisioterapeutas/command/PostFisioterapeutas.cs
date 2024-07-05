using Core.Domain.Entities;
using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Fisioterapeutas.command;

public record PostFisioterapeutas : IRequest
{
    public string Nombre { get; set; }
    
    public string Correo { get; set; }
    
    public string Telefono { get; set; }
    
    public string Especialidad { get; set; }
    
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
        var fisio = new Fisioterapeutum()
        {
            Fisioterapeuta = request.Nombre,
            Correo = request.Correo,
            Telefono = request.Telefono,
            Especialidad = request.Especialidad,
            Foto = request.Foto == null ? "https://res.cloudinary.com/doi0znv2t/image/upload/v1718432025/Utils/fotoPerfil.png" : request.Foto
        };

        await _context.Fisioterapeuta.AddAsync(fisio);
        await _context.SaveChangesAsync();
    }
}