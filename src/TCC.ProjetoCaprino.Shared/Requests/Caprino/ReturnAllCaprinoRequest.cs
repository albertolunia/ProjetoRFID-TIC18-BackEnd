using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;


namespace TCC.ProjetoCaprino.Shared.Requests.Caprino;

public class ReturnAllCaprinoRequest : IRequest<Result<List<ReturnAllCaprinoResponse>>>
{

}
