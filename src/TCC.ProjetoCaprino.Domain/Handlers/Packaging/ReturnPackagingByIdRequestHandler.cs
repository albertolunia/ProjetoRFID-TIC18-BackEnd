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
    public class ReturnPackagingByIdRequestHandler : IRequestHandler<ReturnPackagingByIdRequest, Result<ReturnPackagingResponse>>
    {
        private readonly IPackagingRepository _packagingRepository;
        private readonly ILogger<ReturnPackagingByIdRequestHandler> _logger;

        public ReturnPackagingByIdRequestHandler(ILogger<ReturnPackagingByIdRequestHandler> logger, IPackagingRepository packagingRepository)
        {
            _logger = logger;
            _packagingRepository = packagingRepository;
        }

        public async Task<Result<ReturnPackagingResponse>> Handle(ReturnPackagingByIdRequest request, CancellationToken cancellationToken)
        {
            var packaging = await _packagingRepository.ReturnPackagingByIdAsync(request.PackagingId);

            return packaging is null
                ? Result.Error<ReturnPackagingResponse>(new ExceptionApplication(RegisteredErrors.IdPackagingInvalid))
                : Result.Success(new ReturnPackagingResponse(packaging.Id, packaging.Name, packaging.IsDeleted));
        }
    }
}
