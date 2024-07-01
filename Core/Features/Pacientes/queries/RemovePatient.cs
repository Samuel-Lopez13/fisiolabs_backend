using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Pacientes.queries;

public record RemovePatient : IRequest
{
    public int PacienteId { get; set; }
}

public class RemovePatientHandle : IRequestHandler<RemovePatient>
{
    private readonly FisiolabsSofwaredbContext _context;
    
    public RemovePatientHandle(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(RemovePatient request, CancellationToken cancellationToken)
    {
        var patient = _context.Pacientes.Find(request.PacienteId);
        
        if(patient == null)
            throw new NotFoundException("No se encontro el paciente");
        
        _context.Pacientes.Remove(patient);
        await _context.SaveChangesAsync();
    }
}

