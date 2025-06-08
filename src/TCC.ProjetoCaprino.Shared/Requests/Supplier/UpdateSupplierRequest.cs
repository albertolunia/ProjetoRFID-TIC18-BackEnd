using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Supplier;

namespace TCC.ProjetoCaprino.Shared.Requests.Supplier;


public class UpdateSupplierRequest : IRequest<Result<UpdateSupplierResponse>>, IValida
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
}
