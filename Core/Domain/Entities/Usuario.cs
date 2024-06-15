namespace Core.Domain.Entities;

public class Usuario
{
    public int UsuarioId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
    
    public string? Especialidad { get; set; }
    
    public string? Correo { get; set; }
    
    public string? Telefono { get; set; }

    public string? Nacionalidad { get; set; }
    
    public string? FotoPerfil {get; set;}
}