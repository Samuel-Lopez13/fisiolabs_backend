using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Pacientes.queries;

public record BuscarPaciente : IRequest<BuscarPacienteResponse>
{
    public int Pagina { get; set; }
    public string Nombre { get; set; }
}

public class BuscarPacientesHandler : IRequestHandler<BuscarPaciente, BuscarPacienteResponse>
{
    private readonly FisiolabsSofwaredbContext _context;

    public BuscarPacientesHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }

    public async Task<BuscarPacienteResponse> Handle(BuscarPaciente request, CancellationToken cancellationToken)
    {
        // Obtener el número total de pacientes que cumplen con el criterio de búsqueda
        var totalPacientes = await _context.Pacientes
            .AsNoTracking()
            .Where(x => x.Nombre.Contains(request.Nombre))
            .ToListAsync();

        // Calcular el número de páginas
        int numPaginas = (int)Math.Ceiling((double)totalPacientes.Count / 10);
        
        var pacientes = await _context.Pacientes
            .AsNoTracking()
            .Where(x => x.Nombre.Contains(request.Nombre))
            .Include(x => x.Expedientes)
            .OrderBy(o => o.Nombre)
            .Skip((request.Pagina - 1) * 10)
            .Take(10)
            .Select(x => new PacientesModel()
            {
                PacienteId = x.PacienteId,
                Nombre = x.Nombre,
                Edad = EdadPaciente(x.Edad.Date),
                Sexo = x.Sexo == true ? "Hombre" : "Mujer",
                Telefono = x.Telefono,
                Verificado = x.Expedientes.Any()
            }).ToListAsync();
        
        // Crear el response
        var response = new BuscarPacienteResponse()
        {
            numPaginas = numPaginas,
            pacientes = pacientes
        };

        return response;
    }

    public static int EdadPaciente(DateTime fecha)
    {
        int edad = DateTime.Today.Year - fecha.Year;
        var restar = false;
        
        if (DateTime.Today.Month < fecha.Month)
            restar = true;
        else if (DateTime.Today.Month == fecha.Month)
        {
            if (DateTime.Today.Day <= fecha.Day)
                restar = true;
        }

        if (restar)
            edad -= 1;

        return edad;
    }
}

public record BuscarPacienteResponse
{
    public int numPaginas { get; set; }
    public List<PacientesModel> pacientes { get; set; }
}

public record PacientesModel
{
    public int PacienteId { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Sexo { get; set; }
    public string Telefono { get; set; }
    public bool Verificado { get; set; }
}