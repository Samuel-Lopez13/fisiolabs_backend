using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Diagnostico.queries;

public record GetRevisiones() : IRequest<List<GetRevisionesResponse>>
{
    public string DiagnosticoId { get; set; }
}

public class GetRevisionesHandler : IRequestHandler<GetRevisiones, List<GetRevisionesResponse>>
{
    private readonly FisioContext _context;
    
    public GetRevisionesHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task<List<GetRevisionesResponse>> Handle(GetRevisiones request, CancellationToken cancellationToken)
    {
        var revisiones = await _context.Revisions
            .AsNoTracking()
            .OrderBy(x => x.Fecha)
            .ThenBy(x => x.Hora)
            .Where(x => x.DiagnosticoId == request.DiagnosticoId.HashIdInt())
            .ToListAsync();

        return await Task.FromResult(revisiones.Select(x => new GetRevisionesResponse()
        {
            Notas = x.Notas,
            Fecha = x.Fecha,
            Hora = x.Hora,
            ComprobantePago = x.FolioPago
        }).ToList()); 
    }
}

public record GetRevisionesResponse()
{
    public string Notas { get; set; }

    public DateTime Fecha { get; set; }
    
    public TimeSpan Hora { get; set; }
    
    public string ComprobantePago { get; set; }

    public string Fisioterapeuta { get; set; }
}