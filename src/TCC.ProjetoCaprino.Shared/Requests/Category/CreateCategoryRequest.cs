using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Category;

namespace TCC.ProjetoCaprino.Shared.Requests.Category;

public class CreateCategoryRequest : IRequest<Result<CreateCategoryResponse>>, IValida
{
    public required string Name { get; set; }
    public required string Origin { get; set; }
    public required string Color { get; set; }
}
