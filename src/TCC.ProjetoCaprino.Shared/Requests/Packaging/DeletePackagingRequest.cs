using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Packaging;

namespace TCC.ProjetoCaprino.Shared.Requests.Packaging
{
    public class DeletePackagingRequest : IRequest<Result<DeletePackagingResponse>>
    {
        public Guid PackagingId { get; set; }
    }
}
