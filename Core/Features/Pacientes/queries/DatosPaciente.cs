using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Pacientes.queries;

public record DatosPaciente : IRequest<DatosPacienteResponse>
{
    public int PacienteId { get; set; }
};

public class DatosPacienteHandler : IRequestHandler<DatosPaciente, DatosPacienteResponse>
{
    private readonly FisiolabsSofwaredbContext _context;

    public DatosPacienteHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }

    public async Task<DatosPacienteResponse> Handle(DatosPaciente request, CancellationToken cancellationToken)
    {
        var paciente = await _context.Pacientes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.PacienteId == request.PacienteId);

        if (paciente == null)
            throw new NotFoundException("No se encontro el paciente");
        
        var response = new DatosPacienteResponse()
        {
            PacienteId = paciente.PacienteId,
            Nombre = paciente.Nombre,
            Sexo = paciente.Sexo == true ? "Hombre" : "Mujer"
        };

        return response;
    }
}

public record DatosPacienteResponse
{
    public int PacienteId { get; set; }
    public string Nombre { get; set; }
    public string Sexo { get; set; }
}