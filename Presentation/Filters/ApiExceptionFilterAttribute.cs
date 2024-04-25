using Core.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Filters;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    public readonly ILogger<ApiExceptionFilterAttribute> _Logger;

    public ApiExceptionFilterAttribute(ILogger<ApiExceptionFilterAttribute> logger)
    {
        _Logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case NotFoundException notFoundException:
                HandleNotFoundException(context, notFoundException);
                _Logger.LogDebug(context.Exception, "{message} en {@Result}", context.Exception.Message,
                    context.Result);
                break;
            case ConflictException conflictException:
                HandleConflictException(context, conflictException);
                _Logger.LogDebug(context.Exception, "{message} en {@Result}", context.Exception.Message,
                    context.Result);
                break;
            case BadRequestException badRequestException:
                HandleBadRequestException(context, badRequestException);
                _Logger.LogDebug(context.Exception, "{message} en {@Result}", context.Exception.Message,
                    context.Result);
                break;
            case ForbiddenAccessException:
                HandleForbiddenAccessException(context);
                _Logger.LogDebug(context.Exception, "{message} en {@Result}", context.Exception.Message,
                    context.Result);
                break;
        }

        base.OnException(context);
    }

    private void HandleNotFoundException(ExceptionContext context, NotFoundException exception)
    {
        var details = new ProblemDetails()
        {
            Title = "No se ha encontrado el recurso especificado",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Detail = exception.Message
        };

        context.Result = new NotFoundObjectResult(details);

        context.ExceptionHandled = true;
    }
    
    private void HandleConflictException(ExceptionContext context, ConflictException exception)
    {
        var details = new ProblemDetails()
        {
            Title = "Error de duplicidad",
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8",
            Detail = exception.Message
        };

        context.Result = new ConflictObjectResult(details);

        context.ExceptionHandled = true;
    }
    
    private void HandleBadRequestException(ExceptionContext context, BadRequestException exception)
    {
        var details = new ProblemDetails()
        {
            Title = "Los datos ingresados son incorrectos",
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            Detail = exception.Message
        };
    
        context.Result = new BadRequestObjectResult(details);
    
        context.ExceptionHandled = true;
    }
    
    private void HandleForbiddenAccessException(ExceptionContext context)
    {
        var details = new ProblemDetails
        {
            Status = StatusCodes.Status403Forbidden,
            Title = "Acceso denegado.",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3"
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status403Forbidden
        };

        context.ExceptionHandled = true;
    }
}