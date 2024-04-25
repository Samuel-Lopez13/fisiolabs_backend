using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Usuario;

public record ObtenerUsuariosPrueba : IRequest<UsuarioResponse>;

public class ObtenerUsuariosPruebaHandler : IRequestHandler<ObtenerUsuariosPrueba, UsuarioResponse>
{
    private readonly FisiolabsSofwaredbContext _context;

    public ObtenerUsuariosPruebaHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }

    public async Task<UsuarioResponse> Handle(ObtenerUsuariosPrueba request, CancellationToken cancellationToken)
    {
        var user = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.UsuarioId == 1);
        
        return new UsuarioResponse()
        {
            Nombre = user.Username
        };
    }
}

public record UsuarioResponse
{
    public string Nombre { get; set; }
}