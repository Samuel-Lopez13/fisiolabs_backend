﻿namespace Core.Domain.Entities;

public class Usuario
{
    public int UsuarioId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}