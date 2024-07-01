using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public class Fisioterapeutum
{
    public Fisioterapeutum()
    {
        Revisions = new HashSet<Revision>();
    }
    
    public int FisioterapeutaId { get; set; }

    public string Fisioterapeuta { get; set; } = null!;
    
    //Especialidad 
    //Foto

    public virtual ICollection<Revision> Revisions { get; set; } = new List<Revision>();
}
