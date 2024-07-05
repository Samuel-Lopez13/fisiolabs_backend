using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Citas.command;

public record PostDate : IRequest
{
    public int PacienteId { get; set; }
    
    [Required(ErrorMessage = "El campo fecha es obligatorio")]
    public DateTime Fecha { get; set; }
    
    [Required(ErrorMessage = "El campo Hora es obligatorio")]
    public TimeSpan Hora { get; set; }
    
    [Required(ErrorMessage = "El campo Motivo es obligatorio")]
    public string Motivo { get; set; }
}

public class PostDateHandler : IRequestHandler<PostDate>
{
    private readonly FisiolabsSofwaredbContext _context;
    
    public PostDateHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PostDate request, CancellationToken cancellationToken)
    {
        var patient = await _context.Pacientes.FindAsync(request.PacienteId);

        if (patient == null)
            throw new NotFoundException("No se encontro el paciente");

        var date = new Cita()
        {
            PacienteId = request.PacienteId,
            Fecha = request.Fecha,
            Hora = request.Hora,
            Motivo = request.Motivo,
            Status = 1
        };

        await _context.Citas.AddAsync(date);
        await _context.SaveChangesAsync();
    }
}