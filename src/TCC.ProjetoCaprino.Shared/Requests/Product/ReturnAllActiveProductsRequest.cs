using MediatR;
using OperationResult;
using System.Collections.Generic;
using TCC.ProjetoCaprino.Shared.Responses.Product;


namespace TCC.ProjetoCaprino.Shared.Requests.Product;

public class ReturnAllActiveProductsRequest : IRequest<Result<List<ReturnAllActiveProductsResponse>>>
{

}
