using System.Security.Cryptography;
using Core.Domain.Services;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Pacientes.queries;

public record Pacientes : IRequest<List<PacientesResponse>>
{
    public int Pagina { get; set; }
};

public class PacientesHandler : IRequestHandler<Pacientes, List<PacientesResponse>>
{
    private readonly FisiolabsSofwaredbContext _context;

    public PacientesHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }

    public async Task<List<PacientesResponse>> Handle(Pacientes request, CancellationToken cancellationToken)
    {
        var pacientes = await _context.Pacientes
            .AsNoTracking()
            .Include(x => x.Expedientes)
            .OrderBy(x => x.Nombre)
            .Skip((request.Pagina - 1) * 10)
            .Take(10)
            .Select(x => new PacientesResponse()
            {
                PacienteId = x.PacienteId,
                Nombre = x.Nombre + " " + x.Apellido,
                Edad = EdadPaciente(x.Edad.Date),
                Sexo = x.Sexo == true ? "Hombre" : "Mujer",
                Telefono = x.Telefono,
                Verificado = x.Expedientes.Any()
            }).ToListAsync();

        return pacientes;
    }

    public static int EdadPaciente(DateTime fecha){
        int edad = DateTime.Today.Year - fecha.Year;
        var restar = false;
            
        if(DateTime.Today.Month < fecha.Month){
            restar = true;
        } else if (DateTime.Today.Month == fecha.Month){
            if(DateTime.Today.Day <= fecha.Day) {
                restar = true;
            }
        }
        
        if(restar){
            edad -= 1;
        }
            
        return edad;
    }
}

public record PacientesResponse
{
    public int PacienteId { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Sexo { get; set; }
    public string Telefono { get; set; }
    public bool Verificado { get; set; }
}