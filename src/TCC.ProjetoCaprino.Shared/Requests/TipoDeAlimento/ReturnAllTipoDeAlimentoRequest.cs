using MediatR;
using OperationResult;
using System.Collections.Generic;
using TCC.ProjetoCaprino.Shared.Responses.TipoDeAlimento;


namespace TCC.ProjetoCaprino.Shared.Requests.TipoDeAlimento;

public class ReturnAllTipoDeAlimentoRequest : IRequest<Result<List<ReturnAllTipoDeAlimentoResponse>>>
{

}
