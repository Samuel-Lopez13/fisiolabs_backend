using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Pacientes.queries;

public record UltimosPacientes : IRequest<List<UltimosPacientesResponse>>;

public class UltimosPacientesHandler : IRequestHandler<UltimosPacientes, List<UltimosPacientesResponse>>
{
    private readonly FisiolabsSofwaredbContext _context;

    public UltimosPacientesHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }

    public async Task<List<UltimosPacientesResponse>> Handle(UltimosPacientes request, CancellationToken cancellationToken)
    {
        var pacientes = await _context.Pacientes
            .AsNoTracking()
            .OrderByDescending(x => x.PacienteId)
            .Take(7)
            .Select(x => new UltimosPacientesResponse()
            {
                Nombre = x.Nombre + " " + x.Apellido,
                Edad = EdadPaciente(x.Edad.Date),
                Sexo = x.Sexo == true ? "Hombre" : "Mujer",
                Telefono = x.Telefono
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

public record UltimosPacientesResponse
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Sexo { get; set; }
    public string Telefono { get; set; }
}