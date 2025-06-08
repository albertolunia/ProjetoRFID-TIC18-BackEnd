using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Category;


namespace TCC.ProjetoCaprino.Shared.Requests.Category;

public class ReturnAllCategoriesRequest : IRequest<Result<List<ReturnAllCategoriesResponse>>>
{

}
