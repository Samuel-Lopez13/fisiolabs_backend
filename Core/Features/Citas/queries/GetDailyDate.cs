using Core.Domain.Services;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Citas.queries;

public record GetDailyDate : IRequest<List<GetDailyDateResponse>>;

public class GetDailyDateHandler : IRequestHandler<GetDailyDate, List<GetDailyDateResponse>>
{
    private readonly FisiolabsSofwaredbContext _context;
    private readonly IDate _date;

    public GetDailyDateHandler(FisiolabsSofwaredbContext context, IDate date)
    {
        _context = context;
        _date = date;
    }
    
    public async Task<List<GetDailyDateResponse>> Handle(GetDailyDate request, CancellationToken cancellationToken)
    {
        await _date.ModifyDate();
        
        var dates = await _context.Citas
            .AsNoTracking()
            .Include(x => x.Paciente)
            .Where(x => x.Fecha.Date == DateTime.Today && x.Status == 1)
            .OrderBy(x => x.Hora)
            .Select(x => new GetDailyDateResponse()
            {
                CitasId = x.CitasId,
                PacienteId = x.Paciente.PacienteId,
                Nombre = x.Paciente.Nombre + " " + x.Paciente.Apellido,
                Motivo = x.Motivo,
                Foto = x.Paciente.FotoPerfil,
                Telefono = x.Paciente.Telefono,
                Fecha = x.Fecha,
                Hora = x.Hora,
                prueba = DateTime.Now
            }).ToListAsync();

        return dates;
    }
}

public record GetDailyDateResponse
{
    public int CitasId { get; set; }
    public int PacienteId { get; set; }
    public string Nombre { get; set; }
    public string Motivo { get; set; }
    public string Foto { get; set; }
    public string Telefono { get; set; }
    public DateTime prueba { get; set; }
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
}