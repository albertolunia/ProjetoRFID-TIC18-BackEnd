using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;

namespace TCC.ProjetoCaprino.Shared.Requests.Caprino;

public class DeleteCaprinoRequest : IRequest<Result<DeleteCaprinoResponse>>, IValida
{
    public Guid Id { get; set; }
}
