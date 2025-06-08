using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Product;

namespace TCC.ProjetoCaprino.Shared.Requests.Product;

public class DeleteProductRequest : IRequest<Result<DeleteProductResponse>>, IValida
{
    public Guid Id { get; set; }
}
