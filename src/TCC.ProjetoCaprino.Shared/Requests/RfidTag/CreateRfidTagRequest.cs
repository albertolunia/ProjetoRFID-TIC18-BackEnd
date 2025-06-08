using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared;
using TCC.ProjetoCaprino.Shared.Responses.RfidTag;

namespace TCC.ProjetoCaprino.Shared.Requests.RfidTag;

public class CreateRfidTagRequest : IRequest<Result<CreateRfidTagResponse>>, IValida
{
    public required string RfidTag { get; set; }
}
