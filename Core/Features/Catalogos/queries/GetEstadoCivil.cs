using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Catalogos.queries;

public class GetEstadoCivil: IRequest<List<GetEstadoCivilResponse>>
{
    public bool Activos { get; set; }
}

public class GetEstadoCivilHandler : IRequestHandler<GetEstadoCivil, List<GetEstadoCivilResponse>>
{
    private readonly FisioContext _context;

    public GetEstadoCivilHandler(FisioContext context)
    {
        _context = context;
    }

    public async Task<List<GetEstadoCivilResponse>> Handle(GetEstadoCivil request, CancellationToken cancellationToken)
    {
        if (request.Activos) {
            var estado = await _context.EstadoCivils
                .Where(x => x.Status)
                .Select(x => new GetEstadoCivilResponse
                {
                    EstadoCivilId = x.EstadoCivilId.HashId(),
                    Descripcion = x.Descripcion,
                    Status = x.Status
                })
                .ToListAsync(cancellationToken);
            
            return estado;
        } else {
            var estado = await _context.EstadoCivils
                .Select(x => new GetEstadoCivilResponse
                {
                    EstadoCivilId = x.EstadoCivilId.HashId(),
                    Descripcion = x.Descripcion,
                    Status = x.Status
                })
                .ToListAsync(cancellationToken);
            
            return estado;
        }
    }
}

public record GetEstadoCivilResponse
{
    public string EstadoCivilId { get; set; }
    public string Descripcion { get; set; }
    public bool Status { get; set; }
}