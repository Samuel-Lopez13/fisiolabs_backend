using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Core.Features.Citas.command;

public record PostDate : IRequest
{
    public string PacienteId { get; set; }
    
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
        var patient = await _context.Pacientes.FindAsync(request.PacienteId.HashIdInt());
        
        if (patient == null)
            throw new NotFoundException("No se encontro el paciente");

        var dateValidation = await _context.Citas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.PacienteId == request.PacienteId.HashIdInt() && x.Fecha.Date == request.Fecha.Date && x.Hora < FormatHour.MoreHours(request.Hora) && x.Hora > FormatHour.LessHour(request.Hora));
        
        if (dateValidation != null)
            throw new BadRequestException("No se puede agendar la cita");
        
        var date = new Cita()
        {
            PacienteId = request.PacienteId.HashIdInt(),
            Fecha = request.Fecha,
            Hora = request.Hora,
            Motivo = request.Motivo,
            Status = 1
        };

        await _context.Citas.AddAsync(date);
        await _context.SaveChangesAsync();
    }
}