using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Pacientes.queries;

public record EliminarPaciente : IRequest
{
    public int PacienteId { get; set; }
}

public class EliminarPacienteHandle : IRequestHandler<EliminarPaciente>
{
    private readonly FisiolabsSofwaredbContext _context;
    
    public EliminarPacienteHandle(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(EliminarPaciente request, CancellationToken cancellationToken)
    {
        var paciente = _context.Pacientes.Find(request.PacienteId);
        
        if(paciente == null)
            throw new NotFoundException("No se encontro el paciente");
        
        _context.Pacientes.Remove(paciente);
        await _context.SaveChangesAsync();
    }
}

