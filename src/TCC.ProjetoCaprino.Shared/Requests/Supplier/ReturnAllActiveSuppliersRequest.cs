using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Supplier;

namespace TCC.ProjetoCaprino.Shared.Requests.Supplier;


public class ReturnAllActiveSuppliersRequest : IRequest<Result<List<ReturnAllActiveSuppliersResponse>>>, IValida
{

}
