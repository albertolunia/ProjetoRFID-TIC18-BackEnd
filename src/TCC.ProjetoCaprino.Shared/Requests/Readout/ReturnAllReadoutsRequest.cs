using MediatR;
using OperationResult;
using System.Collections.Generic;
using TCC.ProjetoCaprino.Shared.Responses.Readout;


namespace TCC.ProjetoCaprino.Shared.Requests.Readout;

public class ReturnAllReadoutsRequest : IRequest<Result<List<ReturnAllReadoutsResponse>>>
{

}
