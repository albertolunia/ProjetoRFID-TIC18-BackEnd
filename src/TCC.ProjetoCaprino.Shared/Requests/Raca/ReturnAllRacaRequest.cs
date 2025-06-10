using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Raca;

namespace TCC.ProjetoCaprino.Shared.Requests.Raca;

public class ReturnAllRacaRequest : IRequest<Result<List<ReturnRacaResponse>>>
{
}
