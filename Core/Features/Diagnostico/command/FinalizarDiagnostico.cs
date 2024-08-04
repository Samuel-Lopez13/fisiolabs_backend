using System.ComponentModel.DataAnnotations;
using Core.Domain.Exceptions;
using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Diagnostico.command;

public record FinalizarDiagnostico : IRequest
{
    [Required(ErrorMessage = "El campo DiagnosticId es obligatorio")]
    public string DiagnosticId { get; set; }
    [Required(ErrorMessage = "El campo MotivoAlta es obligatorio")]
    public int MotivoAlta { get; set; }
    [Required(ErrorMessage = "El campo DiagnosticoInicial es obligatorio")]
    public string DiagnosticoInicial { get; set; }
    [Required(ErrorMessage = "El campo DiagnosticoFinal es obligatorio")]
    public string DiagnosticoFinal { get; set; }
    [Required(ErrorMessage = "El campo FrecuenciaTratamiento es obligatorio")]
    public string FrecuenciaTratamiento { get; set; }
}

public class FinalizarDiagnosticoHandler : IRequestHandler<FinalizarDiagnostico>
{
    private readonly FisioContext _context;
    
    public FinalizarDiagnosticoHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(FinalizarDiagnostico request, CancellationToken cancellationToken)
    {
        var diagnostic = await _context.Diagnosticos.FindAsync(request.DiagnosticId.HashIdInt());
        
        if (diagnostic == null)
            throw new NotFoundException("diagnostico no encontrado");
        
        diagnostic.MotivoAltaId = request.MotivoAlta;
        diagnostic.DiagnosticoInicial = request.DiagnosticoInicial;
        diagnostic.DiagnosticoFinal = request.DiagnosticoFinal;
        diagnostic.FrecuenciaTratamiento = request.FrecuenciaTratamiento;
        diagnostic.FechaAlta = FormatDate.DateLocal().Date;
        diagnostic.Estatus = false;
        
        _context.Diagnosticos.Update(diagnostic);
        await _context.SaveChangesAsync();
    }
}