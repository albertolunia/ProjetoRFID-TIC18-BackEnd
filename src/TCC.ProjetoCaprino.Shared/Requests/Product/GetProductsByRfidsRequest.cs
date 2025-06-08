using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Product;

namespace TCC.ProjetoCaprino.Shared.Requests.Product;

public class GetProductsByRfidsRequest : IRequest<Result<CombinedProductResponse>>
{
    public List<string> Rfids { get; set; }

    public GetProductsByRfidsRequest(List<string> rfids)
    {
        Rfids = rfids;
    }
}
