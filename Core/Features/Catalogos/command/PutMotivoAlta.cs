using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Catalogos.command;

public record PutMotivoAlta : IRequest
{
    public string? Descripcion { get; set; }
    public bool? Status { get; set; }
}

public class PutMotivoAltaHandler : IRequestHandler<PutMotivoAlta>
{
    private readonly FisioContext _context;
    
    public PutMotivoAltaHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PutMotivoAlta request, CancellationToken cancellationToken)
    {
        var motivoAlta = await _context.MotivoAltas
            .SingleOrDefaultAsync(a => a.Descripcion == request.Descripcion);
        
        if (motivoAlta == null)
            throw new BadRequestException("No se encontro el campo solicitado");
        
        motivoAlta.Descripcion = request.Descripcion ?? motivoAlta.Descripcion;
        motivoAlta.Status = request.Status ?? motivoAlta.Status;
        
        _context.MotivoAltas.Update(motivoAlta);
        await _context.SaveChangesAsync();
    }
}