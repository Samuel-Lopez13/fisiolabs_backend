using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Catalogos.command;

public record PutServicios : IRequest
{
    public string? Descripcion { get; set; }
    public bool? Status { get; set; }
}

public class PutServiciosHandler : IRequestHandler<PutServicios>
{
    private readonly FisioContext _context;
    
    public PutServiciosHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PutServicios request, CancellationToken cancellationToken)
    {
        var servicios = await _context.Servicios
            .SingleOrDefaultAsync(a => a.Descripcion == request.Descripcion);
        
        if (servicios == null)
            throw new BadRequestException("No se encontro el campo solicitado");
        
        servicios.Descripcion = request.Descripcion ?? servicios.Descripcion;
        servicios.Status = request.Status ?? servicios.Status;
        
        _context.Servicios.Update(servicios);
        await _context.SaveChangesAsync();
    }
}