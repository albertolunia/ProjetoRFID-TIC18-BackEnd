using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Vacina;

namespace TCC.ProjetoCaprino.Shared.Requests.Vacina;


public class ReturnAllVacinaRequest : IRequest<Result<List<ReturnAllVacinaResponse>>>, IValida
{

}
