//using System.Globalization;
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
//    public class UpdatePackagingRequestHandler : IRequestHandler<UpdatePackagingRequest, Result<UpdatePackagingResponse>>
//    {
//        private readonly IPackagingRepository _packagingRepository;
//        private readonly ILogger<UpdatePackagingRequestHandler> _logger;

//        public UpdatePackagingRequestHandler(IPackagingRepository packagingRepository, ILogger<UpdatePackagingRequestHandler> logger)
//        {
//            _packagingRepository = packagingRepository;
//            _logger = logger;
//        }

//        public async Task<Result<UpdatePackagingResponse>> Handle(UpdatePackagingRequest request, CancellationToken cancellationToken)
//        {
//            var packaging = await _packagingRepository.ReturnActivePackagingByIdAsync(request.Id);

//            if(packaging == null)
//            {
//                return Result.Error<UpdatePackagingResponse>(new ExceptionApplication(RegisteredErrors.IdPackagingInvalid));
//            }

//			var existingPackagingWithName = await _packagingRepository.ReturnActivePackagingByNameAsync(request.Name);

//            if(existingPackagingWithName is not null
//                && existingPackagingWithName.Id != request.Id)
//            {
//				return Result.Error<UpdatePackagingResponse>(new ExceptionApplication(RegisteredErrors.PackageNameAlreadyExists));
//            }


//			packaging.Update(request.Name);

//            await _packagingRepository.UpdatePackagingAsync(packaging);

//            return Result.Success(new UpdatePackagingResponse(packaging.Id, packaging.Name, packaging.IsDeleted));
//        }
//    }
//}
