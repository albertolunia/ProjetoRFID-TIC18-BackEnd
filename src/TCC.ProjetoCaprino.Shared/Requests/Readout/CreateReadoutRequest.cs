//using Cepedi.ProjetoRFID.Domain.Entities;
using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared;
using TCC.ProjetoCaprino.Shared.Responses.Readout;

namespace TCC.ProjetoCaprino.Shared.Requests.Readout;

public class CreateReadoutRequest : IRequest<Result<CreateReadoutResponse>>, IValida
{
    public required DateTime ReadoutDate { get; set; }
    public required List<string> Tags { get; set; }
}
