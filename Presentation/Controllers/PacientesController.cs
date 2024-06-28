using Core.Features.Pacientes.Command;
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

    /// <summary>
    /// Obtener Pacientes
    /// </summary>
    /// <param name="pagina"></param>
    /// <returns>Lista de Pacientes</returns>
    /// <remarks>
    /// Devuelve una lista de todos los pacientes, pasando como parametro la pagina
    /// </remarks>
    /// <response code="400">Error en la solicitud</response>
    [HttpGet()]
    public async Task<GetPacientesResponse> getPacientes([FromQuery] int pagina)
    {
        return await _mediator.Send(new GetPacientes() { Pagina = pagina });
    }
    
    /// <summary>
    /// Buscador Pacientes
    /// </summary>
    /// <param name="pagina">Pagina</param>
    /// <param name="nombre"></param>
    /// <returns>Buscador de Pacientes</returns>
    /// <remarks>
    /// Devuelve una lista de todos los pacientes que cumplan con el criterio de busqueda, pasando como parametro la pagina
    /// </remarks>
    [HttpGet("Buscador")]
    public async Task<BuscarPacienteResponse> getBuscador([FromQuery] int pagina, [FromQuery] string nombre)
    {
        return await _mediator.Send(new BuscarPaciente() { Pagina = pagina, Nombre = nombre});
    }
    
    [HttpGet("Paciente")]
    public async Task<PacienteResponse> getPaciente([FromQuery] int id)
    {
        return await _mediator.Send(new Paciente(){ PacienteId = id});
    }

    [HttpGet("Datos")]
    public async Task<DatosPacienteResponse> getDatos([FromQuery] int paciente)
    {
        return await _mediator.Send(new DatosPaciente() { PacienteId = paciente });
    }
    
    [HttpGet("Expediente")]
    public async Task<DatoExpedienteResponse> getExpediente([FromQuery] int paciente)
    {
        return await _mediator.Send(new DatoExpediente() { PacienteId = paciente });
    }
    
    [HttpGet("paginas")]
    public async Task<NumeroPaginasResponse> getPaginas()
    {
        return await _mediator.Send(new NumeroPaginas());
    }
    
    [HttpGet("UltimosRegistrados")]
    public async Task<List<UltimosPacientesResponse>> getUltimosPacientes()
    {
        return await _mediator.Send(new UltimosPacientes());
    }
    
    [HttpPost()]
    public async Task<CrearPacienteResponse> PostPaciente([FromBody] CrearPaciente command)
    {
        return await _mediator.Send(command);
    }
    
    [HttpPost("Interrogatorio")]
    public async Task<IActionResult> PostInterrogatorio([FromBody] InterrogatioPaciente command)
    {
        await _mediator.Send(command);
        return Ok("Se agregaron los datos correctamente");
    }
    
    [HttpDelete()]
    public async Task<IActionResult> DeletePaciente([FromQuery] int id)
    {
        await _mediator.Send(new EliminarPaciente() { PacienteId = id });
        return Ok("Se elimino el paciente correctamente");
    }
}