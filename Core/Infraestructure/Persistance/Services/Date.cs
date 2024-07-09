using Core.Domain.Services;
using Core.Infraestructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Usuario.Command;

public class Date : IDate
{
    private readonly FisiolabsSofwaredbContext _context;
    
    public Date(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }
    
    public async Task ModifyDate()
    {
        //1: Pendiente
        //2: Inasistencia
        //3: Cancelada
        //4: Concluida
        
        var citas = await _context.Citas
            .Where(x => x.Status == 1)
            .ToListAsync();
        
        // Obtener la fecha actual en UTC
        DateTime utcToday = DateTime.UtcNow.Date;
        
        foreach (var cita in citas)
        {
            if (cita.Fecha.Date <= DateTime.UtcNow)
            {
                if (cita.Hora <= DateTime.UtcNow.TimeOfDay)
                {
                    cita.Status = 2;
                    await _context.SaveChangesAsync();
                }
                
                if(cita.Fecha.Date < DateTime.UtcNow){
                    cita.Status = 2;
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}