using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.Features.Pacientes.queries;

public record SearchPatients : IRequest<SearchPatientResponse>
{
    public int Pagina { get; set; }
    public string Nombre { get; set; }
}

public class SearchPatientsHandler : IRequestHandler<SearchPatients, SearchPatientResponse>
{
    private readonly FisiolabsSofwaredbContext _context;

    public SearchPatientsHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }

    public async Task<SearchPatientResponse> Handle(SearchPatients request, CancellationToken cancellationToken)
    {
        // Obtener el número total de pacientes que cumplen con el criterio de búsqueda
        var totalPatients = await _context.Pacientes
            .AsNoTracking()
            .Where(x => x.Nombre.Contains(request.Nombre))
            .ToListAsync();

        // Calcular el número de páginas
        int numPages = (int)Math.Ceiling((double)totalPatients.Count / 10);
        
        var patientsList = await _context.Pacientes
            .AsNoTracking()
            .Where(x => x.Nombre.Contains(request.Nombre))
            .Include(x => x.Expedientes)
            .ToListAsync();

        // Ordenar los pacientes según cada letra en la cadena de búsqueda
        patientsList = patientsList
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
        var patients = patientsList
            .Skip((request.Pagina - 1) * 10)
            .Take(10)
            .Select(x => new PatientModelSearch()
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
        var response = new SearchPatientResponse()
        {
            numPaginas = numPages,
            total = totalPatients.Count,
            pacientes = patients
        };

        return response;
    }
}

public record SearchPatientResponse
{
    public int numPaginas { get; set; }
    public int total { get; set; }
    public List<PatientModelSearch> pacientes { get; set; }
}

public record PatientModelSearch
{
    public int PacienteId { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Sexo { get; set; }
    public string Telefono { get; set; }
    public bool Verificado { get; set; }
}