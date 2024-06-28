using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Core.Domain.Helpers;

namespace Core.Features.Pacientes.queries;

public record GetPacientes : IRequest<GetPacientesResponse>
{
    public int Pagina { get; set; }
};

public class GetPacientesHandler : IRequestHandler<GetPacientes, GetPacientesResponse>
{
    private readonly FisiolabsSofwaredbContext _context;

    public GetPacientesHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }

    public async Task<GetPacientesResponse> Handle(GetPacientes request, CancellationToken cancellationToken)
    {
        // Obtener el número total de paginas
        var totalPacientes = await _context.Pacientes
            .AsNoTracking()
            .ToListAsync();
        
        // Calculamos el número de páginas
        int numPaginas = (int)Math.Ceiling((double)totalPacientes.Count / 10);
        
        //Devuelve una lista de 10 pacientes
        var pacientes = await _context.Pacientes
            .AsNoTracking()
            .Include(x => x.Expedientes)
            .OrderBy(x => x.Nombre)
            .Skip((request.Pagina - 1) * 10)
            .Take(10)
            .Select(x => new GetPacientesModel()
            {
                PacienteId = x.PacienteId,
                Nombre = x.Nombre + " " + (x.Apellido ?? ""),
                Edad = ConvertDate.DateToYear(x.Edad.Date),
                Sexo = x.Sexo == true ? "Hombre" : "Mujer",
                Telefono = x.Telefono,
                Verificado = x.Expedientes.Any()
            }).ToListAsync();

        // Response
        var response = new GetPacientesResponse()
        {
            numPaginas = numPaginas,
            total = totalPacientes.Count,
            pacientes = pacientes
        };
        
        return response;
    }
}

public record GetPacientesResponse
{
    public int numPaginas { get; set; }
    public int total { get; set; }
    public List<GetPacientesModel> pacientes { get; set; }
}

public record GetPacientesModel
{
    public int PacienteId { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Sexo { get; set; }
    public string Telefono { get; set; }
    public bool Verificado { get; set; }
}