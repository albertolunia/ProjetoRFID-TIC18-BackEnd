using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared;
using TCC.ProjetoCaprino.Shared.Responses.Supplier;

namespace TCC.ProjetoCaprino.Shared.Requests.Supplier;


public class DeleteSupplierRequest : IRequest<Result<DeleteSupplierResponse>>, IValida
{
    public Guid Id { get; set; }
}