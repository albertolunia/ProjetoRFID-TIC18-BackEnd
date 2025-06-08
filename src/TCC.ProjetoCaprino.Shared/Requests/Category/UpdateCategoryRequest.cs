using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Category;

namespace TCC.ProjetoCaprino.Shared.Requests.Category;

public class UpdateCategoryRequest : IRequest<Result<UpdateCategoryResponse>>, IValida
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Origin { get; set; }
    public string? Color { get; set; }
}
