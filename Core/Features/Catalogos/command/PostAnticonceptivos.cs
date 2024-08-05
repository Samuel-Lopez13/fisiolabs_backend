using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Catalogos.command;

public record PostAnticonceptivos : IRequest
{
    public string Descripcion { get; set; }
}

public class PostAnticonceptivosHandler : IRequestHandler<PostAnticonceptivos>
{
    private readonly FisioContext _context;
    
    public PostAnticonceptivosHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PostAnticonceptivos request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}