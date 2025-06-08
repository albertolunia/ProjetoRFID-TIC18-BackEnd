using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Packaging;

namespace TCC.ProjetoCaprino.Shared.Requests.Packaging
{
    public class ReturnPackagingByIdRequest : IRequest<Result<ReturnPackagingResponse>>
    {
        public Guid PackagingId { get; set; }
    }
}
