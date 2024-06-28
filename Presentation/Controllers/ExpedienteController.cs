using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("[controller]")]
public class ExpedienteController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public ExpedienteController(IMediator mediator)
    {
        _mediator = mediator;
    }
}