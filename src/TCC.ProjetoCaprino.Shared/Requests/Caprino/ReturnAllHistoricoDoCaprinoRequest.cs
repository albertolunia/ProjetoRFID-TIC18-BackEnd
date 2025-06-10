using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;

namespace TCC.ProjetoCaprino.Shared.Requests.Caprino;

public class ReturnAllHistoricoDoCaprinoRequest : IRequest<Result<List<ReturnAllHistoricoDoCaprinoResponse>>>, IValida
{
    public Guid Id { get; set; }
}
