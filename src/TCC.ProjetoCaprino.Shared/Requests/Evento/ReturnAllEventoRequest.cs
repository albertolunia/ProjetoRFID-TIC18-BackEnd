using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared;
using TCC.ProjetoCaprino.Shared.Responses.Evento;

namespace TCC.ProjetoCaprino.Shared.Requests.Evento;

public class ReturnAllEventoRequest : IRequest<Result<List<ReturnAllEventoResponse>>>, IValida
{

}
