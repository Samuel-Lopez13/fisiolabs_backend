using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Infraestructure.Persistance;
using MediatR;

namespace Core.Features.Catalogos.command;

public class PostFlujoVaginal : IRequest
{
    [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
    public string Descripcion { get; set; }
}

public class PostFlujoVaginalHandler : IRequestHandler<PostFlujoVaginal>
{
    private readonly FisioContext _context;
    
    public PostFlujoVaginalHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task Handle(PostFlujoVaginal request, CancellationToken cancellationToken)
    {
        var flujo = new Cat_FlujoVaginal()
        {
            Descripcion = request.Descripcion,
            Status = true
        };
        
        await _context.FlujoVaginals.AddAsync(flujo);
        await _context.SaveChangesAsync();
    }
}