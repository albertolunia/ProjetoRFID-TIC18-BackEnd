using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared;
using TCC.ProjetoCaprino.Shared.Responses.RfidTag;

namespace TCC.ProjetoCaprino.Shared.Requests.RfidTag;

public class UpdateRfidTagRequest : IRequest<Result<UpdateRfidTagResponse>>, IValida
{
    public Guid Id { get; set; }
    public string? RfidTag { get; set; }
}
