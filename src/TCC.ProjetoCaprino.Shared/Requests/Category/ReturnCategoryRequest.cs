using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Category;

namespace TCC.ProjetoCaprino.Shared.Requests.Category;

public class ReturnCategoryRequest : IRequest<Result<ReturnCategoryResponse>>, IValida
{
    public Guid Id { get; set; }
}
