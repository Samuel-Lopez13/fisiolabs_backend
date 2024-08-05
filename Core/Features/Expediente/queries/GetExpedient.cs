﻿using Core.Domain.Exceptions;
using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Features.Pacientes.queries;

public record GetExpedient : IRequest<GetExpedientResponse>
{
    public string PacienteId { get; set; }
}

public class GetExpedientHandler : IRequestHandler<GetExpedient, GetExpedientResponse>
{
    private readonly FisioContext _context;

    public GetExpedientHandler(FisioContext context)
    {
        _context = context;
    }
    
    public async Task<GetExpedientResponse> Handle(GetExpedient request, CancellationToken cancellationToken)
    {
        //Buscamos si el usuario cuenta ya con un expediente
        var expedient = await _context.Expedientes
            .AsNoTracking()
            .Include(x => x.Diagnosticos)
            .Include(x => x.GinecoObstetrico)
            .Include(x => x.HeredoFamiliar)
            .Include(x => x.NoPatologico)
            .FirstOrDefaultAsync(x => x.PacienteId == request.PacienteId.HashIdInt());
        
        if(expedient == null)
            throw new NotFoundException("No se encontro el expediente");

        //Buscamos sus datos
        /*var antecedents = await _context.NoPatologicos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ExpedienteId == expedient.ExpedienteId);
        
        var familyHistory = await _context.HeredoFamiliars
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ExpedienteId == expedient.ExpedienteId);
        
        var gineco = await _context.GinecoObstetricos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ExpedienteId == expedient.ExpedienteId);*/
        
        var response = new GetExpedientResponse()
        {
            //ExpedienteId = expedient.ExpedienteId.HashId(),
            TipoInterrogatorio = expedient.TipoInterrogatorio,
            Responsable = expedient.Responsable,
            Diagnosticos = expedient.Diagnosticos.Select(x => new DiagnosticGet()
            {
                Diagnostico = x.Descripcion,
                DiagnosticoId = x.DiagnosticoId.HashId(),
                Status = x.Estatus
            }).ToList(),
            HeredoFamiliar = new FamilyHistoryGet()
            {
                Padres = expedient.HeredoFamiliar.Padres,
                PadresVivos = expedient.HeredoFamiliar.PadresVivos,
                PadresCausaMuerte = expedient.HeredoFamiliar?.PadresCausaMuerte ?? "Sin registro",
                Hermanos = expedient.HeredoFamiliar.Hermanos,
                HermanosVivos = expedient.HeredoFamiliar.HermanosVivos,
                HermanosCausaMuerte = expedient.HeredoFamiliar.HermanosCausaMuerte ?? "Sin registro",
                Hijos = expedient.HeredoFamiliar.Hijos,
                HijosVivos = expedient.HeredoFamiliar.HijosVivos,
                HijosCausaMuerte = expedient.HeredoFamiliar.HijosCausaMuerte ?? "Sin registro",
                Dm = expedient.HeredoFamiliar.Dm ?? "Sin registro",
                Hta = expedient.HeredoFamiliar.Hta ?? "Sin registro",
                Cancer = expedient.HeredoFamiliar.Cancer ?? "Sin registro",
                Alcoholismo = expedient.HeredoFamiliar.Alcoholismo ?? "Sin registro",
                Tabaquismo = expedient.HeredoFamiliar.Tabaquismo ?? "Sin registro",
                Drogas = expedient.HeredoFamiliar.Drogas ?? "Sin registro"
            },
            Antecedente = new AntecedentsGet()
            {
                AntecedentesPatologicos = expedient.AntecedentesPatologicos,
                MedioLaboral = expedient.NoPatologico.MedioLaboral,
                MedioSociocultural = expedient.NoPatologico.MedioSociocultural,
                MedioFisicoambiental = expedient.NoPatologico.MedioFisicoambiental
            },
            Ginecobstetricos = new GinecobstetricoGet()
            {
                Fum = expedient.GinecoObstetrico == null ? "" : expedient.GinecoObstetrico?.Fum ?? "Sin registro",
                Fpp = expedient.GinecoObstetrico == null ? "" : expedient.GinecoObstetrico.Fpp ?? "Sin registro",
                EdadGestional = expedient.GinecoObstetrico == null ? "" : expedient.GinecoObstetrico.EdadGestional.ToString() ?? "Sin registro",
                Semanas = expedient.GinecoObstetrico == null ? "" : expedient.GinecoObstetrico.Semanas.ToString() ?? "Sin registro",
                Menarca = expedient.GinecoObstetrico == null ? "" : expedient.GinecoObstetrico.Menarca ?? "Sin registro",
                Ritmo = expedient.GinecoObstetrico == null ? "" : expedient.GinecoObstetrico.Ritmo ?? "Sin registro",
                Gestas = expedient.GinecoObstetrico == null ? "" : expedient.GinecoObstetrico.Gestas.ToString() ?? "Sin registro",
                Partos = expedient.GinecoObstetrico == null ? "" : expedient.GinecoObstetrico.Partos.ToString() ?? "Sin registro",
                Cesareas = expedient.GinecoObstetrico == null ? "" : expedient.GinecoObstetrico.Cesareas.ToString() ?? "Sin registro",
                Abortos = expedient.GinecoObstetrico == null ? "" : expedient.GinecoObstetrico.Abortos.ToString() ?? "Sin registro",
                Cirugias = expedient.GinecoObstetrico == null ? "" : expedient.GinecoObstetrico.Cirugias ?? "Sin registro",
                FlujoVaginalId = expedient.GinecoObstetrico == null ? 0 : expedient.GinecoObstetrico.FlujoVaginalId,
                TipoAnticonceptivoId = expedient.GinecoObstetrico == null ? 0 : expedient.GinecoObstetrico.TipoAnticonceptivoId
            }
        };

        return response;
    }
}

public record GetExpedientResponse
{
    public string ExpedienteId { get; set; }
    
    public bool TipoInterrogatorio { get; set; }
    
    public string Responsable { get; set; }
    
    public FamilyHistoryGet HeredoFamiliar { get; set; }
    public AntecedentsGet Antecedente { get; set; }
    public GinecobstetricoGet Ginecobstetricos { get; set; }
    
    public List<DiagnosticGet> Diagnosticos { get; set; }
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

public record DiagnosticGet
{
    public string Diagnostico { get; set; }
    public bool Status { get; set; }
    public string? DiagnosticoId { get; set; } 
}