using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Pacientes.queries;

public record DatoExpediente : IRequest<DatoExpedienteResponse>
{
    public int PacienteId { get; set; }
}

public class DatosExpedienteHandler : IRequestHandler<DatoExpediente, DatoExpedienteResponse>
{
    private readonly FisiolabsSofwaredbContext _context;

    public DatosExpedienteHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }
    
    public async Task<DatoExpedienteResponse> Handle(DatoExpediente request, CancellationToken cancellationToken)
    {
        var expediente = await _context.Expedientes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.PacienteId == request.PacienteId);
        
        if(expediente == null)
            throw new NotFoundException("No se encontro el expediente");

        var antecendetes = await _context.NoPatologicos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ExpedienteId == expediente.ExpedienteId);
        
        var heredo = await _context.HeredoFamiliars
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ExpedienteId == expediente.ExpedienteId);
        
        var gineco = await _context.GinecoObstetricos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ExpedienteId == expediente.ExpedienteId);
        
        var response = new DatoExpedienteResponse()
        {
            TipoInterrogatorio = expediente.TipoInterrogatorio,
            Responsable = expediente.Responsable,
            HeredoFamiliar = new HeredoFamiliaE()
            {
                Padres = heredo.Padres,
                PadresVivos = heredo.PadresVivos,
                PadresCausaMuerte = heredo?.PadresCausaMuerte ?? "Sin registro",
                Hermanos = heredo.Hermanos,
                HermanosVivos = heredo.HermanosVivos,
                HermanosCausaMuerte = heredo.HermanosCausaMuerte ?? "Sin registro",
                Hijos = heredo.Hijos,
                HijosVivos = heredo.HijosVivos,
                HijosCausaMuerte = heredo.HijosCausaMuerte ?? "Sin registro",
                Dm = heredo.Dm ?? "Sin registro",
                Hta = heredo.Hta ?? "Sin registro",
                Cancer = heredo.Cancer ?? "Sin registro",
                Alcoholismo = heredo.Alcoholismo ?? "Sin registro",
                Tabaquismo = heredo.Tabaquismo ?? "Sin registro",
                Drogas = heredo.Drogas ?? "Sin registro"
            },
            Antecedente = new AntecedentesE()
            {
                AntecedentesPatologicos = expediente.AntecedentesPatologicos,
                MedioLaboral = antecendetes.MedioLaboral,
                MedioSociocultural = antecendetes.MedioSociocultural,
                MedioFisicoambiental = antecendetes.MedioFisicoambiental
            },
            Ginecobstetricos = new GinecobstetricoE()
            {
                Fum = gineco?.Fum ?? "Sin registro",
                Fpp = gineco.Fpp ?? "Sin registro",
                EdadGestional = gineco.EdadGestional.ToString() ?? "Sin registro",
                Semanas = gineco.Semanas.ToString() ?? "Sin registro",
                Menarca = gineco.Menarca ?? "Sin registro",
                Ritmo = gineco.Ritmo ?? "Sin registro",
                Gestas = gineco.Gestas.ToString() ?? "Sin registro",
                Partos = gineco.Partos.ToString() ?? "Sin registro",
                Cesareas = gineco.Cesareas.ToString() ?? "Sin registro",
                Abortos = gineco.Abortos.ToString() ?? "Sin registro",
                Cirugias = gineco.Cirugias ?? "Sin registro",
                FlujoVaginalId = gineco.FlujoVaginalId,
                TipoAnticonceptivoId = gineco.TipoAnticonceptivoId
            }
        };

        return response;
    }
}

public record DatoExpedienteResponse
{
    public bool TipoInterrogatorio { get; set; }
    
    public string Responsable { get; set; }
    
    public HeredoFamiliaE HeredoFamiliar { get; set; }
    public AntecedentesE Antecedente { get; set; }
    public GinecobstetricoE Ginecobstetricos { get; set; }
};

public record HeredoFamiliaE
{
    public int Padres { get; set; }

    public int PadresVivos { get; set; }

    public string PadresCausaMuerte { get; set; }

    public int Hermanos { get; set; }

    public int HermanosVivos { get; set; }

    public string HermanosCausaMuerte { get; set; }

    public int Hijos { get; set; }

    public int HijosVivos { get; set; }

    public string HijosCausaMuerte { get; set; }

    public string Dm { get; set; }

    public string Hta { get; set; }

    public string Cancer { get; set; }

    public string Alcoholismo { get; set; }

    public string Tabaquismo { get; set; }

    public string Drogas { get; set; }
}

public record AntecedentesE
{
    public string AntecedentesPatologicos { get; set; }

    public string MedioLaboral { get; set; }

    public string MedioSociocultural { get; set; }

    public string MedioFisicoambiental { get; set; }
}

public record GinecobstetricoE
{
    public string? Fum { get; set; }

    public string? Fpp { get; set; }

    public string? EdadGestional { get; set; }

    public string? Semanas { get; set; }

    public string? Menarca { get; set; }

    public string? Ritmo { get; set; }

    public string? Gestas { get; set; }

    public string? Partos { get; set; }

    public string? Cesareas { get; set; }

    public string? Abortos { get; set; }

    public string? Cirugias { get; set; }

    public int? FlujoVaginalId { get; set; }
    
    public int? TipoAnticonceptivoId { get; set; }
}