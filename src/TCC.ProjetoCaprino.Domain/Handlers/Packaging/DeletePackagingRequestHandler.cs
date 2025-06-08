using TCC.ProjetoCaprino.Shared.Enums;
using TCC.ProjetoCaprino.Shared.Exceptions;
using TCC.ProjetoCaprino.Shared.Requests.Packaging;
using TCC.ProjetoCaprino.Shared.Responses.Packaging;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Packaging
{
    public class DeletePackagingRequestHandler : IRequestHandler<DeletePackagingRequest, Result<DeletePackagingResponse>>
    {
        private readonly IPackagingRepository _packagingRepository;
        private readonly ILogger<DeletePackagingRequestHandler> _logger;

        public DeletePackagingRequestHandler(IPackagingRepository packagingRepository, ILogger<DeletePackagingRequestHandler> logger)
        {
            _packagingRepository = packagingRepository;
            _logger = logger;
        }

        public async Task<Result<DeletePackagingResponse>> Handle(DeletePackagingRequest request, CancellationToken cancellationToken)
        {
            var packaging = await _packagingRepository.ReturnActivePackagingByIdAsync(request.PackagingId);

            if (packaging == null)
            {
                return Result.Error<DeletePackagingResponse>(new ExceptionApplication(RegisteredErrors.IdPackagingInvalid));
            }

            await _packagingRepository.DeletePackagingAsync(request.PackagingId);

            return Result.Success(new DeletePackagingResponse(packaging.Id, packaging.Name, packaging.IsDeleted));
        }
    }
}
