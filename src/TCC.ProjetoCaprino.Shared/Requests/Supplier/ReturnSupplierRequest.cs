using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Supplier;

namespace TCC.ProjetoCaprino.Shared.Requests.Supplier;


public class ReturnSupplierRequest : IRequest<Result<ReturnSupplierResponse>>, IValida
{
    public Guid Id { get; set; }
}
