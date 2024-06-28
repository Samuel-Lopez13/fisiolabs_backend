using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

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
        
        var pacientesList = await _context.Pacientes
            .AsNoTracking()
            .Where(x => x.Nombre.Contains(request.Nombre))
            .Include(x => x.Expedientes)
            .ToListAsync();

        // Ordenar los pacientes según cada letra en la cadena de búsqueda
        pacientesList = pacientesList
            .OrderBy(p => 
            {
                //Convertimos el nombre a minuscular
                string nombre = p.Nombre.ToLower();
                //Esto es lo que estamos buscando
                string criterio = request.Nombre.ToLower();
                //Obtener los índices de cada letra en el nombre
                int[] indices = new int[criterio.Length];
                
                for (int i = 0; i < criterio.Length; i++)
                {
                    indices[i] = nombre.IndexOf(criterio[i]);
                    if (indices[i] == -1)
                    {
                        indices[i] = int.MaxValue;
                    }
                }

                // Convertir los índices a una cadena para usarla en la comparación
                return string.Join(",", indices);
            })
            .ThenBy(p => p.Nombre)
            .ToList();

        // Aplicar paginación
        var pacientes = pacientesList
            .Skip((request.Pagina - 1) * 10)
            .Take(10)
            .Select(x => new PacientesModel()
            {
                PacienteId = x.PacienteId,
                Nombre = x.Nombre + " " + (x.Apellido ?? ""),
                Edad = ConvertDate.DateToYear(x.Edad.Date),
                Sexo = x.Sexo == true ? "Hombre" : "Mujer",
                Telefono = x.Telefono,
                Verificado = x.Expedientes.Any()
            })
            .ToList();
        
        // Response
        var response = new BuscarPacienteResponse()
        {
            numPaginas = numPaginas,
            total = totalPacientes.Count,
            pacientes = pacientes
        };

        return response;
    }
}

public record BuscarPacienteResponse
{
    public int numPaginas { get; set; }
    public int total { get; set; }
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