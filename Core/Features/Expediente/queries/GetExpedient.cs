using Core.Domain.Exceptions;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Pacientes.queries;

public record GetExpedient : IRequest<GetExpedientResponse>
{
    public int PacienteId { get; set; }
}

public class GetExpedientHandler : IRequestHandler<GetExpedient, GetExpedientResponse>
{
    private readonly FisiolabsSofwaredbContext _context;

    public GetExpedientHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }
    
    public async Task<GetExpedientResponse> Handle(GetExpedient request, CancellationToken cancellationToken)
    {
        //Buscamos si el usuario cuenta ya con un expediente
        var expedient = await _context.Expedientes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.PacienteId == request.PacienteId);
        
        if(expedient == null)
            throw new NotFoundException("No se encontro el expediente");

        //Buscamos sus datos
        var antecedents = await _context.NoPatologicos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ExpedienteId == expedient.ExpedienteId);
        
        var familyHistory = await _context.HeredoFamiliars
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ExpedienteId == expedient.ExpedienteId);
        
        var gineco = await _context.GinecoObstetricos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ExpedienteId == expedient.ExpedienteId);
        
        var response = new GetExpedientResponse()
        {
            TipoInterrogatorio = expedient.TipoInterrogatorio,
            Responsable = expedient.Responsable,
            HeredoFamiliar = new FamilyHistoryGet()
            {
                Padres = familyHistory.Padres,
                PadresVivos = familyHistory.PadresVivos,
                PadresCausaMuerte = familyHistory?.PadresCausaMuerte ?? "Sin registro",
                Hermanos = familyHistory.Hermanos,
                HermanosVivos = familyHistory.HermanosVivos,
                HermanosCausaMuerte = familyHistory.HermanosCausaMuerte ?? "Sin registro",
                Hijos = familyHistory.Hijos,
                HijosVivos = familyHistory.HijosVivos,
                HijosCausaMuerte = familyHistory.HijosCausaMuerte ?? "Sin registro",
                Dm = familyHistory.Dm ?? "Sin registro",
                Hta = familyHistory.Hta ?? "Sin registro",
                Cancer = familyHistory.Cancer ?? "Sin registro",
                Alcoholismo = familyHistory.Alcoholismo ?? "Sin registro",
                Tabaquismo = familyHistory.Tabaquismo ?? "Sin registro",
                Drogas = familyHistory.Drogas ?? "Sin registro"
            },
            Antecedente = new AntecedentsGet()
            {
                AntecedentesPatologicos = expedient.AntecedentesPatologicos,
                MedioLaboral = antecedents.MedioLaboral,
                MedioSociocultural = antecedents.MedioSociocultural,
                MedioFisicoambiental = antecedents.MedioFisicoambiental
            },
            Ginecobstetricos = new GinecobstetricoGet()
            {
                Fum = gineco == null ? "" : gineco?.Fum ?? "Sin registro",
                Fpp = gineco == null ? "" : gineco.Fpp ?? "Sin registro",
                EdadGestional = gineco == null ? "" : gineco.EdadGestional.ToString() ?? "Sin registro",
                Semanas = gineco == null ? "" : gineco.Semanas.ToString() ?? "Sin registro",
                Menarca = gineco == null ? "" : gineco.Menarca ?? "Sin registro",
                Ritmo = gineco == null ? "" : gineco.Ritmo ?? "Sin registro",
                Gestas = gineco == null ? "" : gineco.Gestas.ToString() ?? "Sin registro",
                Partos = gineco == null ? "" : gineco.Partos.ToString() ?? "Sin registro",
                Cesareas = gineco == null ? "" : gineco.Cesareas.ToString() ?? "Sin registro",
                Abortos = gineco == null ? "" : gineco.Abortos.ToString() ?? "Sin registro",
                Cirugias = gineco == null ? "" : gineco.Cirugias ?? "Sin registro",
                FlujoVaginalId = gineco == null ? 0 : gineco.FlujoVaginalId,
                TipoAnticonceptivoId = gineco == null ? 0 : gineco.TipoAnticonceptivoId
            }
        };

        return response;
    }
}

public record GetExpedientResponse
{
    public bool TipoInterrogatorio { get; set; }
    
    public string Responsable { get; set; }
    
    public FamilyHistoryGet HeredoFamiliar { get; set; }
    public AntecedentsGet Antecedente { get; set; }
    public GinecobstetricoGet Ginecobstetricos { get; set; }
};

public record FamilyHistoryGet
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

public record AntecedentsGet
{
    public string AntecedentesPatologicos { get; set; }

    public string MedioLaboral { get; set; }

    public string MedioSociocultural { get; set; }

    public string MedioFisicoambiental { get; set; }
}

public record GinecobstetricoGet
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