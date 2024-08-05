using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Catalogos.queries;

public class GetFlujoVaginal: IRequest<List<GetFlujoVaginalResponse>>
{
    public bool Activos { get; set; }
}

public class GetFlujoVaginalHandler : IRequestHandler<GetFlujoVaginal, List<GetFlujoVaginalResponse>>
{
    private readonly FisioContext _context;

    public GetFlujoVaginalHandler(FisioContext context)
    {
        _context = context;
    }

    public async Task<List<GetFlujoVaginalResponse>> Handle(GetFlujoVaginal request, CancellationToken cancellationToken)
    {
        if (request.Activos) {
            var flujo = await _context.FlujoVaginals
                .Where(x => x.Status)
                .Select(x => new GetFlujoVaginalResponse
                {
                    FlujoVaginalId = x.FlujoVaginalId.HashId(),
                    Descripcion = x.Descripcion,
                    Status = x.Status
                })
                .ToListAsync(cancellationToken);
            
            return flujo;
        } else {
            var flujo = await _context.FlujoVaginals
                .Select(x => new GetFlujoVaginalResponse
                {
                    FlujoVaginalId = x.FlujoVaginalId.HashId(),
                    Descripcion = x.Descripcion,
                    Status = x.Status
                })
                .ToListAsync(cancellationToken);
            
            return flujo;
        }
    }
}

public record GetFlujoVaginalResponse
{
    public string FlujoVaginalId { get; set; }
    public string Descripcion { get; set; }
    public bool Status { get; set; }
}