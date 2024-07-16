using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities;
using Core.Domain.Exceptions;
using Core.Domain.Helpers;
using Core.Infraestructure.Persistance;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Core.Features.Pacientes.Command;

public record FamilyHistoryPost
{
    [Required(ErrorMessage = "El campo Padres es obligatorio")]
    public int Padres { get; set; }

    [Required(ErrorMessage = "El campo PadresVivos es obligatorio")]
    public int PadresVivos { get; set; }

    public string? PadresCausaMuerte { get; set; }

    [Required(ErrorMessage = "El campo Hermanos es obligatorio")]
    public int Hermanos { get; set; }

    [Required(ErrorMessage = "El campo HermanosVivos es obligatorio")]
    public int HermanosVivos { get; set; }

    public string? HermanosCausaMuerte { get; set; }

    [Required(ErrorMessage = "El campo Hijos es obligatorio")]
    public int Hijos { get; set; }

    [Required(ErrorMessage = "El campo HijosVivos es obligatorio")]
    public int HijosVivos { get; set; }

    public string? HijosCausaMuerte { get; set; }

    public string? Dm { get; set; }

    public string? Hta { get; set; }

    public string? Cancer { get; set; }

    public string? Alcoholismo { get; set; }

    public string? Tabaquismo { get; set; }

    public string? Drogas { get; set; }
}

public record AntecedentsPost
{
    [Required(ErrorMessage = "El campo AntecedentesPatologicos es obligatorio")]
    public string AntecedentesPatologicos { get; set; }

    [Required(ErrorMessage = "El campo MedioLaboral es obligatorio")]
    public string MedioLaboral { get; set; }

    [Required(ErrorMessage = "El campo MedioSociocultural es obligatorio")]
    public string MedioSociocultural { get; set; }

    [Required(ErrorMessage = "El campo MedioFisicoambiental es obligatorio")]
    public string MedioFisicoambiental { get; set; }
}

public record GinecobstetricoPost
{
    public string? Fum { get; set; }

    public string? Fpp { get; set; }

    public int? EdadGestional { get; set; }

    public int? Semanas { get; set; }

    public string? Menarca { get; set; }

    public string? Ritmo { get; set; }

    public int? Gestas { get; set; }

    public int? Partos { get; set; }

    public int? Cesareas { get; set; }

    public int? Abortos { get; set; }

    public string? Cirugias { get; set; }

    public int? FlujoVaginalId { get; set; }

    [Required(ErrorMessage = "El campo TipoAnticonceptivoId es obligatorio")]
    public int TipoAnticonceptivoId { get; set; }
}

public record PostExpedient : IRequest
{
    [Required(ErrorMessage = "El campo PacienteId es obligatorio")]
    public string PacienteId { get; set; }
    
    [Required(ErrorMessage = "El campo TipoInterrogatorio es obligatorio")]
    public bool TipoInterrogatorio { get; set; }
    
    public string? Responsable { get; set; }
    
    public FamilyHistoryPost HeredoFamiliar { get; set; }
    public AntecedentsPost Antecedente { get; set; }
    public GinecobstetricoPost? Ginecobstetricos { get; set; }
};

public class PostExpedientHandler : IRequestHandler<PostExpedient>
{
    private readonly FisiolabsSofwaredbContext _context;

    public PostExpedientHandler(FisiolabsSofwaredbContext context)
    {
        _context = context;
    }

    public async Task Handle(PostExpedient request, CancellationToken cancellationToken)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                /* Creamos primero el expediente */
                var expedient = new Expediente()
                {
                    TipoInterrogatorio = request.TipoInterrogatorio,
                    Responsable = request.Responsable,
                    AntecedentesPatologicos = request.Antecedente.AntecedentesPatologicos,
                    PacienteId = request.PacienteId.HashIdInt()
                };

                await _context.Expedientes.AddAsync(expedient);
                await _context.SaveChangesAsync();

                /* Creamos los datos no Patologicos */
                var noPatologico = new NoPatologico()
                {
                    MedioLaboral = request.Antecedente.MedioLaboral,
                    MedioSociocultural = request.Antecedente.MedioSociocultural,
                    MedioFisicoambiental = request.Antecedente.MedioFisicoambiental,
                    ExpedienteId = expedient.ExpedienteId,
                };

                await _context.NoPatologicos.AddAsync(noPatologico);
                await _context.SaveChangesAsync();

                var heredoFamiliar = new HeredoFamiliar()
                {
                    Padres = request.HeredoFamiliar.Padres,
                    PadresVivos = request.HeredoFamiliar.PadresVivos,
                    PadresCausaMuerte = request.HeredoFamiliar.PadresCausaMuerte,
                    Hermanos = request.HeredoFamiliar.Hermanos,
                    HermanosVivos = request.HeredoFamiliar.HermanosVivos,
                    HermanosCausaMuerte = request.HeredoFamiliar.HermanosCausaMuerte,
                    Hijos = request.HeredoFamiliar.Hijos,
                    HijosVivos = request.HeredoFamiliar.HijosVivos,
                    HijosCausaMuerte = request.HeredoFamiliar.HijosCausaMuerte,
                    Dm = request.HeredoFamiliar.Dm,
                    Hta = request.HeredoFamiliar.Hta,
                    Cancer = request.HeredoFamiliar.Cancer,
                    Alcoholismo = request.HeredoFamiliar.Alcoholismo,
                    Tabaquismo = request.HeredoFamiliar.Tabaquismo,
                    Drogas = request.HeredoFamiliar.Drogas,
                    ExpedienteId = expedient.ExpedienteId
                };
                
                await _context.HeredoFamiliars.AddAsync(heredoFamiliar);
                await _context.SaveChangesAsync();
                
                //Buscamos si el paciente es hombre o mujer
                var paciente = await _context.Pacientes.FindAsync(request.PacienteId.HashIdInt());

                if (paciente.Sexo == false)
                {
                    var ginecobtetrico = new GinecoObstetrico()
                    {
                        Fum = request.Ginecobstetricos.Fum,
                        Fpp = request.Ginecobstetricos.Fpp,
                        EdadGestional = request.Ginecobstetricos.EdadGestional,
                        Semanas = request.Ginecobstetricos.Semanas,
                        Menarca = request.Ginecobstetricos.Menarca,
                        Ritmo = request.Ginecobstetricos.Ritmo,
                        Gestas = request.Ginecobstetricos.Gestas,
                        Partos = request.Ginecobstetricos.Partos,
                        Cesareas = request.Ginecobstetricos.Cesareas,
                        Abortos = request.Ginecobstetricos.Abortos,
                        Cirugias = request.Ginecobstetricos.Cirugias,
                        FlujoVaginalId = request.Ginecobstetricos.FlujoVaginalId,
                        TipoAnticonceptivoId = request.Ginecobstetricos.TipoAnticonceptivoId,
                        ExpedienteId = expedient.ExpedienteId
                    };
                    
                    await _context.GinecoObstetricos.AddAsync(ginecobtetrico);
                    await _context.SaveChangesAsync();
                }
                
                //Si todo sale bien commitiar 
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // Si ocurre un error, revertir la transacción
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exRollback)
                {
                    Console.WriteLine("Error al revertir la transacción: " + exRollback.Message);
                }
                
                throw new BadRequestException("Error al procesar los datos");
            }
        }
    }
}