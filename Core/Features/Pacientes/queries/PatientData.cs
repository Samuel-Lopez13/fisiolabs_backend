using Core.Domain.Exceptions;
using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Pacientes.queries;

public record PatientData : IRequest<PatientDataResponse>
{
    public int PacienteId { get; set; }
}

public class DataPatientHandler : IRequestHandler<PatientData, PatientDataResponse>
{
    private readonly FisiolabsSofwaredbContext _context;

    public DataPatientHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }
    
    public async Task<PatientDataResponse> Handle(PatientData request, CancellationToken cancellationToken)
    {
        //Intentamos buscar al paciente
        var patient = await _context.Pacientes
            .AsNoTracking()
            .Include(u => u.Expedientes)
            .FirstOrDefaultAsync(x => x.PacienteId == request.PacienteId);

        //Si no se encuentra, mandar un 404 (Not Found)
        if (patient == null)
            throw new NotFoundException("El paciente no existe");
        
        //Response
        var response = new PatientDataResponse()
        {
            PacienteId = patient.PacienteId,
            Nombre = patient.Nombre,
            Apellido = patient.Apellido ?? "",
            Edad = FormatDate.DateToYear(patient.Edad.Date),
            FechaNacimiento = patient.Edad,
            Sexo = patient.Sexo,
            Verificado = patient.Expedientes.Any(),
            Institucion = patient.Institucion,
            Domicilio = patient.Domicilio,
            CodigoPostal = patient.CodigoPostal,
            Ocupacion = patient.Ocupacion,
            Telefono = patient.Telefono,
            EstadoCivilId = patient.EstadoCivilId,
            FotoPerfil = patient.FotoPerfil
        };

        return response;
    }
}

public record PatientDataResponse
{
    public int PacienteId { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public bool Sexo { get; set; }
    public bool Verificado { get; set; }
    public string Institucion { get; set; }
    public string Domicilio { get; set; }
    public int CodigoPostal { get; set; }
    public string Ocupacion { get; set; }
    public string Telefono { get; set; }
    public int? EstadoCivilId { get; set; }
    public string? FotoPerfil { get; set; }
}