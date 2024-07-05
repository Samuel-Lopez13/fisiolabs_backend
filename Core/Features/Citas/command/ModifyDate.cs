using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Citas.command;

public record ModifyDate : IRequest
{
    public int CitaId { get; set; }
    public int? Status { get; set; }
    public DateTime? Fecha { get; set; }
    public TimeSpan? Hora { get; set; }
    public string? Motivo { get; set; }
};

public class ModifyDateHandler : IRequestHandler<ModifyDate>
{
    private readonly FisiolabsSofwaredbContext _context;

    public ModifyDateHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(ModifyDate request, CancellationToken cancellationToken)
    {
        var date = await _context.Citas.FindAsync(request.CitaId);

        if (date == null)
            throw new NotFoundException("Cita no encontrada");

        // Actualizaremos solo los datos no nulos
        if (request.Status != null)
            date.Status = 3;

        if (request.Fecha.HasValue)
            date.Fecha = request.Fecha.Value;

        if (request.Hora.HasValue)
            date.Hora = request.Hora.Value;

        if (request.Motivo != null)
            date.Motivo = request.Motivo;
        
        _context.Citas.Update(date);
        await _context.SaveChangesAsync(cancellationToken);
    }
}