using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities;

public class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UsuarioId { get; set; }

    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Clave { get; set; } = null!;
    public string FotoPerfil { get; set; } = null!;
    public string? Especialidad { get; set; }
    public string? Correo { get; set; }
    public string? Telefono { get; set; }
}