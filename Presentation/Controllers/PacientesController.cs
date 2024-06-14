﻿using Core.Features.Pacientes.Command;
using Core.Features.Pacientes.queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("[controller]")]

public class PacientesController: ControllerBase
{
    private readonly IMediator _mediator;

    public PacientesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("Pacientes/{pagina}")]
    public async Task<List<PacientesResponse>> getPacientes(int pagina)
    {
        return await _mediator.Send(new Pacientes() { Pagina = pagina });
    }
    
    [HttpGet("UltimosPacientes")]
    public async Task<List<UltimosPacientesResponse>> getUltimosPacientes()
    {
        return await _mediator.Send(new UltimosPacientes());
    }
    
    [HttpPost("CrearPaciente")]
    public async Task<IActionResult> PostPaciente([FromBody] CrearPaciente command)
    {
        await _mediator.Send(command);
        return Ok("El paciente se registro correctamente");
    }
}