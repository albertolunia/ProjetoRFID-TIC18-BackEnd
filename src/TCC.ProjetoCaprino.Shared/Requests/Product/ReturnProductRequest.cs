using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Product;

namespace TCC.ProjetoCaprino.Shared.Requests.Product;

public class ReturnProductRequest : IRequest<Result<ReturnProductResponse>>, IValida
{
    public Guid Id { get; set; }
}
