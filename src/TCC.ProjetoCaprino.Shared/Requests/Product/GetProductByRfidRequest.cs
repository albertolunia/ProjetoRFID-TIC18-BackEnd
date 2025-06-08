using System;
using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Product;

namespace TCC.ProjetoCaprino.Shared.Requests.Product;

public class GetProductByRfidRequest : IRequest<Result<GetProductByRfidResponse>>
{
    public string RfidTag { get; set; }
}
