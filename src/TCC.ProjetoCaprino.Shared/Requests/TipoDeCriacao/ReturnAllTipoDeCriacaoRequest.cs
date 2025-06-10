using MediatR;
using OperationResult;
using System.Collections.Generic;
using TCC.ProjetoCaprino.Shared.Responses.TipoDeCriacao;


namespace TCC.ProjetoCaprino.Shared.Requests.TipoDeCriacao;

public class ReturnAllTipoDeCriacaoRequest : IRequest<Result<List<ReturnAllTipoDeCriacaoResponse>>>
{

}
