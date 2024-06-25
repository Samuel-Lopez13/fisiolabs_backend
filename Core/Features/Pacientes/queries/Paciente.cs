using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Pacientes.queries;

public record Paciente : IRequest<PacienteResponse>
{
    public int PacienteId { get; set; }
}

public class PacienteHandler : IRequestHandler<Paciente, PacienteResponse>
{
    private readonly FisiolabsSofwaredbContext _context;

    public PacienteHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }
    
    public async Task<PacienteResponse> Handle(Paciente request, CancellationToken cancellationToken)
    {
        var paciente = await _context.Pacientes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.PacienteId == request.PacienteId);

        var response = new PacienteResponse()
        {
            Nombre = paciente.Nombre,
            Edad = paciente.Edad,
            Sexo = paciente.Sexo,
            Institucion = paciente.Institucion,
            Domicilio = paciente.Domicilio,
            CodigoPostal = paciente.CodigoPostal,
            Ocupacion = paciente.Ocupacion,
            Telefono = paciente.Telefono,
            EstadoCivilId = paciente.EstadoCivilId,
            FotoPerfil = paciente.FotoPerfil
        };

        return response;
    }
}

public record PacienteResponse
{
    public string Nombre { get; set; }
    public DateTime Edad { get; set; }
    public bool Sexo { get; set; }
    public string Institucion { get; set; }
    public string Domicilio { get; set; }
    public int CodigoPostal { get; set; }
    public string Ocupacion { get; set; }
    public string Telefono { get; set; }
    public int? EstadoCivilId { get; set; }
    public string? FotoPerfil { get; set; }
}