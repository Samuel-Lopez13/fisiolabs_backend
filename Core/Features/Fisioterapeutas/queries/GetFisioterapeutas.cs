using Core.Domain.Helpers;
using Core.Features.Citas.queries;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features;

public record GetFisioterapeutas() : IRequest<List<GetFisioterapeutaResponse>>;

public class GetFisioterapeutaHandler : IRequestHandler<GetFisioterapeutas, List<GetFisioterapeutaResponse>>
{
    private readonly FisiolabsSofwaredbContext _context;

    public GetFisioterapeutaHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }
    
    public Task<List<GetFisioterapeutaResponse>> Handle(GetFisioterapeutas request, CancellationToken cancellationToken)
    {
        var fisios = _context.Fisioterapeuta
            .AsNoTracking()
            .Select(x => new GetFisioterapeutaResponse()
            {
                FisioterapeutaId = x.FisioterapeutaId.HashId(),
                Nombre = x.Fisioterapeuta,
                CedulaProfesional = x.CedulaProfesional,
                Correo = x.Correo,
                Telefono = x.Telefono,
                Especialidad = x.Especialidad,
                Foto = x.Foto
            }).ToListAsync();

        return fisios;
    }
}

public record GetFisioterapeutaResponse{
    public string FisioterapeutaId { get; set; }
    public string Nombre { get; set; }
    
    public string CedulaProfesional { get; set; }
    
    public string Correo { get; set; }
    
    public string Telefono { get; set; }
    
    public string Especialidad { get; set; }
    
    public string Foto { get; set; }
}