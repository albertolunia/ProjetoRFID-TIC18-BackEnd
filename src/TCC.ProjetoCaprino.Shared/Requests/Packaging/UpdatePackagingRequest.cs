using MediatR;
using OperationResult;
using TCC.ProjetoCaprino.Shared.Responses.Packaging;

namespace TCC.ProjetoCaprino.Shared.Requests.Packaging
{
    public class UpdatePackagingRequest : IRequest<Result<UpdatePackagingResponse>>, IValida
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
