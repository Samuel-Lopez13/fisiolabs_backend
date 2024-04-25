using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class Fisioterapeutum
{
    public int FisioterapeutaId { get; set; }

    public string? Fisioterapeuta { get; set; }

    public virtual ICollection<Revision> Revisions { get; set; } = new List<Revision>();
}
