using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Supplier;

namespace TCC.ProjetoCaprino.Shared.Requests.Supplier;


public class CreateSupplierRequest : IRequest<Result<CreateSupplierResponse>>, IValida
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string PhoneNumber { get; set; }
}
