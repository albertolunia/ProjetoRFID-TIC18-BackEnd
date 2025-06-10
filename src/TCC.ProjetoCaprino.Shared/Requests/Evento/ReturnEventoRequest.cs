using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared;
using TCC.ProjetoCaprino.Shared.Responses.Evento;

namespace TCC.ProjetoCaprino.Shared.Requests.Evento;

public class ReturnEventoRequest : IRequest<Result<ReturnEventoResponse>>, IValida
{
    public Guid Id { get; set; }
}
