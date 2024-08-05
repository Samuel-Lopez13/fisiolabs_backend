using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Catalogos.command;

public record PutFlujoVaginal : IRequest
{
    public string? Descripcion { get; set; }
    public bool? Status { get; set; }
}

public class PutFlujoVaginalHandler : IRequestHandler<PutFlujoVaginal>
{
    private readonly FisioContext _context;
    
    public PutFlujoVaginalHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PutFlujoVaginal request, CancellationToken cancellationToken)
    {
        var flujo = await _context.FlujoVaginals
            .SingleOrDefaultAsync(a => a.Descripcion == request.Descripcion);
        
        if (flujo == null)
            throw new BadRequestException("No se encontro el campo solicitado");
        
        flujo.Descripcion = request.Descripcion ?? flujo.Descripcion;
        flujo.Status = request.Status ?? flujo.Status;
        
        _context.FlujoVaginals.Update(flujo);
        await _context.SaveChangesAsync();
    }
}