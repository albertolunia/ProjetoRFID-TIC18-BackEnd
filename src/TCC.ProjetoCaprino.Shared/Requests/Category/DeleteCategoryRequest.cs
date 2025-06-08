using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared;
using TCC.ProjetoCaprino.Shared.Responses.Category;

namespace TCC.ProjetoCaprino.Shared.Requests.Category;

public class DeleteCategoryRequest : IRequest<Result<DeleteCategoryResponse>>, IValida
{
    public Guid Id { get; set; }
}
