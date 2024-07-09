﻿using Core.Domain.Services;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Citas.queries;

public record GetDate : IRequest<List<GetDateResponse>>
{
    public int PacienteId { get; set; }
}

public class GetDateHandler : IRequestHandler<GetDate, List<GetDateResponse>>
{
    private readonly FisiolabsSofwaredbContext _context;
    private readonly IDate _date;

    public GetDateHandler(FisiolabsSofwaredbContext context, IDate date)
    {
        _context = context;
        _date = date;
    }
    
    public async Task<List<GetDateResponse>> Handle(GetDate request, CancellationToken cancellationToken)
    {
        await _date.ModifyDate();
        
        var dates = await _context.Citas
            .AsNoTracking()
            .Include(x => x.Paciente)
            .Where(x => x.PacienteId == request.PacienteId && x.Status == 1)
            .OrderBy(x => x.Fecha)
            .ThenBy(x => x.Hora)
            .Select(x => new GetDateResponse()
            {
                Nombre = x.Paciente.Nombre + " " + x.Paciente.Apellido,
                Fecha = x.Fecha,
                Hora = x.Hora,
                Motivo = x.Motivo
            }).ToListAsync();

        return dates;
    }
}

public record GetDateResponse
{
    public string Nombre { get; set; }
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public string Motivo { get; set; }
}