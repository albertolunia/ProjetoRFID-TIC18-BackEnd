using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;

namespace TCC.ProjetoCaprino.Shared.Requests.Caprino;

public class ReturnCaprinoRequest : IRequest<Result<ReturnCaprinoResponse>>, IValida
{
    public Guid Id { get; set; }
}
