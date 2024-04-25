using System;
using System.Collections.Generic;

namespace Core.Domain.Entities;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
}
