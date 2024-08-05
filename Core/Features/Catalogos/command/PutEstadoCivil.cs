using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Catalogos.command;

public record PutEstadoCivil : IRequest
{
    public string? Descripcion { get; set; }
    public bool? Status { get; set; }
}

public class PutEstadoCivilHandler : IRequestHandler<PutEstadoCivil>
{
    private readonly FisioContext _context;
    
    public PutEstadoCivilHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PutEstadoCivil request, CancellationToken cancellationToken)
    {
        var estado = await _context.EstadoCivils
            .SingleOrDefaultAsync(a => a.Descripcion == request.Descripcion);
        
        if (estado == null)
            throw new BadRequestException("No se encontro el campo solicitado");
        
        estado.Descripcion = request.Descripcion ?? estado.Descripcion;
        estado.Status = request.Status ?? estado.Status;
        
        _context.EstadoCivils.Update(estado);
        await _context.SaveChangesAsync();
    }
}