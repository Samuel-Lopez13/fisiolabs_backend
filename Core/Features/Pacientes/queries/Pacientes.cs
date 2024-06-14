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
            .OrderBy(x => x.Nombre)
            .Skip((request.Pagina - 1) * 10)
            .Take(10)
            .Select(x => new PacientesResponse()
            {
                PacienteId = x.PacienteId,
                Nombre = x.Nombre,
                Edad = DateTime.Today.Year - x.Edad.Value.Year,
                Sexo = x.Sexo == true ? "Hombre" : "Mujer",
                Telefono = x.Telefono
                
            }).ToListAsync();

        return pacientes;
    }
}

public record PacientesResponse
{
    public int PacienteId { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Sexo { get; set; }
    public string Telefono { get; set; }
}