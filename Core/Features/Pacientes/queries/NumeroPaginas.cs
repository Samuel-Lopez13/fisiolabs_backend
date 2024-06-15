using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Pacientes.queries;

public record NumeroPaginas : IRequest<NumeroPaginasResponse>;

public class NumeroPaginasHandler : IRequestHandler<NumeroPaginas, NumeroPaginasResponse>
{
    private readonly FisiolabsSofwaredbContext _context;

    public NumeroPaginasHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }

    public async Task<NumeroPaginasResponse> Handle(NumeroPaginas request, CancellationToken cancellationToken)
    {
        var pacientes = await _context.Pacientes.ToListAsync();
        
        var response = new NumeroPaginasResponse()
        {
            numeroPaginas = (int)Math.Ceiling((double)pacientes.Count / 10)
        };

        return response;
    }
}

public record NumeroPaginasResponse
{
    public int numeroPaginas { get; set; }
}