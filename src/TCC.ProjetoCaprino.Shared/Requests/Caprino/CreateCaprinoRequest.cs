using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Category;

namespace TCC.ProjetoCaprino.Shared.Requests.Category;

public class CreateCaprinoRequest : IRequest<Result<CreateCaprinoResponse>>, IValida
{
    public required string Name { get; set; }
    public required string Origin { get; set; }
    public required string Color { get; set; }
}
