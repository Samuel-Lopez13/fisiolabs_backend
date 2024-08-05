using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class Cat_Especialidades
{
    public Cat_Especialidades()
    {
        Fisioterapeutas = new HashSet<Fisioterapeuta>();
    }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EspecialidadesId { get; set; }

    public string Descripcion { get; set; } = null!;
    
    public bool Status { get; set; }
    
    // Configuración de relación uno a muchos
    public virtual ICollection<Fisioterapeuta> Fisioterapeutas { get; set; } = new List<Fisioterapeuta>();
}