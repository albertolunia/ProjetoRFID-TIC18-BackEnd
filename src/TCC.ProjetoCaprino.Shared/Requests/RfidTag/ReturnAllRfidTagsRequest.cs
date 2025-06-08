using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared;
using TCC.ProjetoCaprino.Shared.Responses.RfidTag;

namespace TCC.ProjetoCaprino.Shared.Requests.RfidTag;

public class ReturnAllRfidTagsRequest : IRequest<Result<List<ReturnAllRfidTagsResponse>>>, IValida
{

}
