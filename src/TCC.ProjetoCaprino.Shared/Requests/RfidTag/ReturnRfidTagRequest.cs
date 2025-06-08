using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared;
using TCC.ProjetoCaprino.Shared.Responses.RfidTag;

namespace TCC.ProjetoCaprino.Shared.Requests.RfidTag;

public class ReturnRfidTagRequest : IRequest<Result<ReturnRfidTagResponse>>, IValida
{
    public Guid Id { get; set; }
}
