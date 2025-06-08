using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Packaging;

namespace TCC.ProjetoCaprino.Shared.Requests.Packaging
{
    public class CreatePackagingRequest : IRequest<Result<CreatePackagingResponse>>, IValida
    {
        public required string Name { get; set; }
    }
}
