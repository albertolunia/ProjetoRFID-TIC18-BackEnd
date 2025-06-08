using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Packaging;

namespace TCC.ProjetoCaprino.Shared.Requests.Packaging
{
    public class ReturnAllActivePackagesRequest : IRequest<Result<List<ReturnPackagingResponse>>>
    {
    }
}
