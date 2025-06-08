using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared;
using TCC.ProjetoCaprino.Shared.Responses.Readout;

namespace TCC.ProjetoCaprino.Shared.Requests.Readout;

public class ReturnReadoutRequest : IRequest<Result<ReturnReadoutResponse>>, IValida
{
    public Guid Id { get; set; }
}
