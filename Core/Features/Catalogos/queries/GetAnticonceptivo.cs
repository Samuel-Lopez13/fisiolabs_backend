using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Catalogos.queries;

public record GetAnticonceptivo : IRequest<List<GetAnticonceptivoResponse>>
{
    public bool Activos { get; set; }
}

public class GetAnticonceptivoHandler : IRequestHandler<GetAnticonceptivo, List<GetAnticonceptivoResponse>>
{
    private readonly FisioContext _context;

    public GetAnticonceptivoHandler(FisioContext context)
    {
        _context = context;
    }

    public async Task<List<GetAnticonceptivoResponse>> Handle(GetAnticonceptivo request, CancellationToken cancellationToken)
    {
        if (request.Activos) {
            var anticonceptivos = await _context.TipoAnticonceptivos
                .Where(x => x.Status)
                .Select(x => new GetAnticonceptivoResponse
                {
                    AnticonceptivoId = x.TipoAnticonceptivoId.HashId(),
                    Descripcion = x.Descripcion,
                    Status = x.Status
                })
                .ToListAsync(cancellationToken);
            
            return anticonceptivos;
        } else {
            var anticonceptivos = await _context.TipoAnticonceptivos
                .Select(x => new GetAnticonceptivoResponse
                {
                    AnticonceptivoId = x.TipoAnticonceptivoId.HashId(),
                    Descripcion = x.Descripcion,
                    Status = x.Status
                })
                .ToListAsync(cancellationToken);
            
            return anticonceptivos;
        }
    }
}

public record GetAnticonceptivoResponse
{
    public string AnticonceptivoId { get; set; }
    public string Descripcion { get; set; }
    public bool Status { get; set; }
}