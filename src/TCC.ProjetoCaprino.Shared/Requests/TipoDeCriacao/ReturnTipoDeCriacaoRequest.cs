using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.TipoDeCriacao;

namespace TCC.ProjetoCaprino.Shared.Requests.TipoDeCriacao;

public class ReturnTipoDeCriacaoRequest : IRequest<Result<ReturnTipoDeCriacaoResponse>>, IValida
{
    public Guid Id { get; set; }
}
