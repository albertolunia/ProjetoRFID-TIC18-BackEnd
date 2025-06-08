using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Product;

namespace TCC.ProjetoCaprino.Shared.Requests.Product
{
	public class GetProductImageUrlRequest : IRequest<Result<GetProductImageUrlResponse>>
	{
        public string? ObjectName { get; set; }
    }
}
