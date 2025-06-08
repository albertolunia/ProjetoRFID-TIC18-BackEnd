using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared;
using TCC.ProjetoCaprino.Shared.Responses.RfidTag;

namespace TCC.ProjetoCaprino.Shared.Requests.RfidTag;

public class DeleteRfidTagRequest : IRequest<Result<DeleteRfidTagResponse>>, IValida
{
    public Guid Id { get; set; }
}
