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
        
        // Obtener la hora actual en UTC
        DateTime utcNow = DateTime.UtcNow;
        
        // Obtener la hora local en Campeche (Central Standard Time)
        //TimeZoneInfo campecheTimeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Mexico_City");
        TimeZoneInfo campecheTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
        DateTime campecheTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, campecheTimeZone);
        
        foreach (var cita in citas)
        {
            if (cita.Fecha.Date <= campecheTime)
            {
                if (cita.Hora <= campecheTime.TimeOfDay)
                {
                    cita.Status = 2;
                    await _context.SaveChangesAsync();
                }
                
                if(cita.Fecha.Date < campecheTime.Date){
                    cita.Status = 2;
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}