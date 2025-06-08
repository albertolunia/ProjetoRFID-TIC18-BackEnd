//using TCC.ProjetoCaprino.Shared.Enums;
//using TCC.ProjetoCaprino.Shared.Exceptions;
//using TCC.ProjetoCaprino.Shared.Requests.Packaging;
//using TCC.ProjetoCaprino.Shared.Responses.Packaging;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using OperationResult;
//using TCC.ProjetoCaprino.Domain.Repositories;

//namespace TCC.ProjetoCaprino.Domain.Handlers.Packaging
//{
//    public class ReturnActivePackagingByIdRequestHandler
//        : IRequestHandler<ReturnActivePackagingByIdRequest, Result<ReturnPackagingResponse>>
//    {
//        private readonly IPackagingRepository _packagingRepository;
//        private readonly ILogger<ReturnActivePackagingByIdRequestHandler> _logger;

//        public ReturnActivePackagingByIdRequestHandler(IPackagingRepository packagingRepository, ILogger<ReturnActivePackagingByIdRequestHandler> logger)
//        {
//            _packagingRepository = packagingRepository;
//            _logger = logger;
//        }


//        public async Task<Result<ReturnPackagingResponse>> Handle(ReturnActivePackagingByIdRequest request, CancellationToken cancellationToken)
//        {
//            var packaging = await _packagingRepository.ReturnActivePackagingByIdAsync(request.PackagingId);

//            return packaging is null
//               ? Result.Error<ReturnPackagingResponse>(new ExceptionApplication(RegisteredErrors.IdPackagingInvalid))
//               : Result.Success(new ReturnPackagingResponse(packaging.Id, packaging.Name, packaging.IsDeleted));
//        }
//    }
//}
