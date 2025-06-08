using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Supplier;

namespace TCC.ProjetoCaprino.Shared.Requests.Supplier;


public class ReturnAllSuppliersRequest : IRequest<Result<List<ReturnAllSuppliersResponse>>>, IValida
{

}
