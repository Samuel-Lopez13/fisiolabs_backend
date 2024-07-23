using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Diagnostico.queries;

public record DiagnosticGet : IRequest<GeneralDiagnosticResponse>
{
    
}

public record DiagnosticGetHandler : IRequestHandler<DiagnosticGet, GeneralDiagnosticResponse>
{
    private readonly FisiolabsSofwaredbContext _context;
    
    public DiagnosticGetHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }
    
    public Task<GeneralDiagnosticResponse> Handle(DiagnosticGet request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new GeneralDiagnosticResponse
        {
            Message = "Hello from DiagnosticGetHandler"
        });
    }
}

public record GeneralDiagnosticResponse
{
    public string Message { get; set; }
}