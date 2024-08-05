using Core.Domain.Helpers;
using Core.Features.Citas.queries;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features;

public record GetFisioterapeutas() : IRequest<List<GetFisioterapeutaResponse>>;

public class GetFisioterapeutaHandler : IRequestHandler<GetFisioterapeutas, List<GetFisioterapeutaResponse>>
{
    private readonly FisioContext _context;

    public GetFisioterapeutaHandler(FisioContext context)
    {
        _context = context;
    }
    
    public Task<List<GetFisioterapeutaResponse>> Handle(GetFisioterapeutas request, CancellationToken cancellationToken)
    {
        var fisios = _context.Fisioterapeuta
            .AsNoTracking()
            .Include(x => x.Especialidades)
            .Select(x => new GetFisioterapeutaResponse()
            {
                FisioterapeutaId = x.FisioterapeutaId.HashId(),
                Nombre = x.Nombre,
                CedulaProfesional = x.CedulaProfesional,
                Correo = x.Correo,
                Telefono = x.Telefono,
                Especialidad = x.Especialidades.Descripcion,
                Foto = x.Foto
            }).ToListAsync();

        return fisios;
    }
}

public record GetFisioterapeutaResponse{
    public string FisioterapeutaId { get; set; }
    public string Nombre { get; set; }
    
    public string Correo { get; set; }
    
    public string Telefono { get; set; }
    
    public string CedulaProfesional { get; set; }
    
    public string Foto { get; set; }
    
    public string Especialidad { get; set; }
}