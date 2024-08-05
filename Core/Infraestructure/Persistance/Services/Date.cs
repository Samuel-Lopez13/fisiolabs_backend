using Core.Domain.Helpers;
using Core.Domain.Services;
using Core.Infraestructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Usuario.Command;

public class Date : IDate
{
    private readonly FisioContext _context;
    
    public Date(FisioContext context)
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
        
        //Recorre todas las citas en busca de las que ya pasaron
        foreach (var cita in citas)
        {
            if (cita.Fecha.Date <= FormatDate.DateLocal().Date)
            {
                if (FormatHour.More10Minutes(cita.Hora) <= FormatDate.DateLocal().TimeOfDay)
                {
                    cita.Status = 2;
                    await _context.SaveChangesAsync();
                }
                
                if(cita.Fecha.Date < FormatDate.DateLocal().Date){
                    cita.Status = 2;
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}