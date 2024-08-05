using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Catalogos.command;

public record PutEspecialidades : IRequest
{
    public string? Descripcion { get; set; }
    public bool? Status { get; set; }
}

public class PutEspecialidadesHandler : IRequestHandler<PutEspecialidades>
{
    private readonly FisioContext _context;
    
    public PutEspecialidadesHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PutEspecialidades request, CancellationToken cancellationToken)
    {
        var especialidades = await _context.Especialidades
            .SingleOrDefaultAsync(a => a.Descripcion == request.Descripcion);
        
        if (especialidades == null)
            throw new BadRequestException("No se encontro el campo solicitado");
        
        especialidades.Descripcion = request.Descripcion ?? especialidades.Descripcion;
        especialidades.Status = request.Status ?? especialidades.Status;
        
        _context.Especialidades.Update(especialidades);
        await _context.SaveChangesAsync();
    }
}