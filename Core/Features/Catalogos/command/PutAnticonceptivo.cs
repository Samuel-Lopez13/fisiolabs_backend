using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Catalogos.command;

public record PutAnticonceptivo : IRequest
{
    public string? Descripcion { get; set; }
    public bool? Status { get; set; }
}

public class PutAnticonceptivoHandler : IRequestHandler<PutAnticonceptivo>
{
    private readonly FisioContext _context;
    
    public PutAnticonceptivoHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PutAnticonceptivo request, CancellationToken cancellationToken)
    {
        var anticonceptivo = await _context.TipoAnticonceptivos
            .SingleOrDefaultAsync(a => a.Descripcion == request.Descripcion);
        
        if (anticonceptivo == null)
            throw new BadRequestException("No se encontro el campo solicitado");
        
        anticonceptivo.Descripcion = request.Descripcion ?? anticonceptivo.Descripcion;
        anticonceptivo.Status = request.Status ?? anticonceptivo.Status;
        
        _context.TipoAnticonceptivos.Update(anticonceptivo);
        await _context.SaveChangesAsync();
    }
}