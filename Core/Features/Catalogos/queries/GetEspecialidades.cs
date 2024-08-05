﻿using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Catalogos.queries;

public class GetEspecialidades : IRequest<List<GetEspecialidadesResponse>>
{
    public bool Activos { get; set; }
}

public class GetEspecialidadesHandler : IRequestHandler<GetEspecialidades, List<GetEspecialidadesResponse>>
{
    private readonly FisioContext _context;

    public GetEspecialidadesHandler(FisioContext context)
    {
        _context = context;
    }

    public async Task<List<GetEspecialidadesResponse>> Handle(GetEspecialidades request, CancellationToken cancellationToken)
    {
        if (request.Activos) {
            var especialidades = await _context.Especialidades
                .Where(x => x.Status)
                .Select(x => new GetEspecialidadesResponse
                {
                    EspecialidadId = x.EspecialidadesId.HashId(),
                    Descripcion = x.Descripcion,
                    Status = x.Status
                })
                .ToListAsync(cancellationToken);
            
            return especialidades;
        } else {
            var especialidades = await _context.Especialidades
                .Select(x => new GetEspecialidadesResponse
                {
                    EspecialidadId = x.EspecialidadesId.HashId(),
                    Descripcion = x.Descripcion,
                    Status = x.Status
                })
                .ToListAsync(cancellationToken);
            
            return especialidades;
        }
    }
}

public record GetEspecialidadesResponse
{
    public string EspecialidadId { get; set; }
    public string Descripcion { get; set; }
    public bool Status { get; set; }
}