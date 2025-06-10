using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared;
using TCC.ProjetoCaprino.Shared.Responses.TipoDeAlimento;

namespace TCC.ProjetoCaprino.Shared.Requests.TipoDeAlimento;

public class ReturnTipoDeAlimentoRequest : IRequest<Result<ReturnTipoDeAlimentoResponse>>, IValida
{
    public Guid Id { get; set; }
}
