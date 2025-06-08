using MediatR;
using OperationResult;
using System.Collections.Generic;
using TCC.ProjetoCaprino.Shared.Responses.Product;


namespace TCC.ProjetoCaprino.Shared.Requests.Product;

public class ReturnAllProductsRequest : IRequest<Result<List<ReturnAllProductsResponse>>>
{

}
