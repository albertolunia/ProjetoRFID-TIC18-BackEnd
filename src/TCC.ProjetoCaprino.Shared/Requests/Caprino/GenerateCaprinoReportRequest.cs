using MediatR;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;

namespace TCC.ProjetoCaprino.Shared.Requests.Caprino;

public class GenerateCaprinoReportRequest : IRequest<Result<GenerateCaprinoReportResponse>>
{
    public bool IsIndividualReport { get; set; }
    public string? Brinco { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public string? Sexo { get; set; }
    public Guid? RacaId { get; set; }
    public Guid? TipoDeCriacaoId { get; set; }
    public Guid? TipoDeAlimentacaoId { get; set; }
    public string? TipoDeEvento { get; set; }
    public string? TipoDeVacina { get; set; }
}
