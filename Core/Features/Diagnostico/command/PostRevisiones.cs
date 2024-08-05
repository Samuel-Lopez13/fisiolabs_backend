using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Diagnostico.command;

public record PostRevisiones() : IRequest
{
    [Required(ErrorMessage = "El campo DiagnosticoId es obligatorio")]
    public string DiagnosticoId { get; set; }
    [Required(ErrorMessage = "El campo FisioterapeutaId es obligatorio")]
    public string FisioterapeutaId { get; set; }
    [Required(ErrorMessage = "El campo Notas es obligatorio")]
    public string Notas { get; set; }
    [Required(ErrorMessage = "El campo ComprobantePago es obligatorio")]
    public string ComprobantePago { get; set; }
}

public class PostRevisionHandler : IRequestHandler<PostRevisiones>
{
    private readonly FisioContext _context;
    
    public PostRevisionHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PostRevisiones request, CancellationToken cancellationToken)
    {
        var revision = new Revision
        {
            DiagnosticoId = request.DiagnosticoId.HashIdInt(),
            Notas = request.Notas,
            FolioPago = request.ComprobantePago,
            Fecha = FormatDate.DateLocal(),
            Hora = new TimeSpan(FormatDate.DateLocal().Hour, FormatDate.DateLocal().Minute, 0)
        };
        
        await _context.Revisions.AddAsync(revision);
        await _context.SaveChangesAsync();
    }
}