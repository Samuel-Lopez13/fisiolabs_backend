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
    private readonly IWebHostEnvironment _environment;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PacientesController(IMediator mediator, IWebHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        _environment = environment;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet("Pacientes")]
    public async Task<List<PacientesResponse>> getPacientes([FromQuery] int pagina)
    {
        return await _mediator.Send(new Pacientes() { Pagina = pagina });
    }
    
    [HttpGet("paginas")]
    public async Task<NumeroPaginasResponse> getPaginas()
    {
        return await _mediator.Send(new NumeroPaginas());
    }
    
    [HttpGet("UltimosPacientes")]
    public async Task<List<UltimosPacientesResponse>> getUltimosPacientes()
    {
        return await _mediator.Send(new UltimosPacientes());
    }
    
    [HttpPost("CrearPaciente")]
    public async Task<IActionResult> PostPaciente([FromForm] CrearPaciente command)
    {
        await _mediator.Send(command);
        return Ok("El paciente se registro correctamente");
    }
    
    [HttpPost]
    [Route("upload")]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No se ha subido ningún archivo.");

        var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var fileName = Path.GetFileName(file.FileName);
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Construir la URL completa para la imagen
        var request = _httpContextAccessor.HttpContext.Request;
        var baseUrl = $"{request.Scheme}://{request.Host}";
        var relativePath = Path.Combine("uploads", fileName);
        var fullPath = Path.Combine(baseUrl, relativePath);

        return Ok(new { message = "Imagen subida correctamente", path = fullPath });
    }
}