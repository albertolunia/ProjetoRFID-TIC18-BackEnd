//using System.Globalization;
//using TCC.ProjetoCaprino.Domain.Entities;
//using TCC.ProjetoCaprino.Shared.Enums;
//using TCC.ProjetoCaprino.Shared.Exceptions;
//using TCC.ProjetoCaprino.Shared.Requests.Packaging;
//using TCC.ProjetoCaprino.Shared.Responses.Packaging;
//using TCC.ProjetoCaprino.Shared.Utils;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using OperationResult;
//using TCC.ProjetoCaprino.Domain.Repositories;

//namespace TCC.ProjetoCaprino.Domain.Handlers.Packaging
//{
//    public class CreatePackagingRequestHandler : IRequestHandler<CreatePackagingRequest, Result<CreatePackagingResponse>>
//    {
//        private readonly IPackagingRepository _packagingRepository;
//        private readonly ILogger<CreatePackagingRequestHandler> _logger;

//        public CreatePackagingRequestHandler(ILogger<CreatePackagingRequestHandler> logger, IPackagingRepository packagingRepository)
//        {
//            _logger = logger;
//            _packagingRepository = packagingRepository;
//        }

//        public async Task<Result<CreatePackagingResponse>> Handle(CreatePackagingRequest request, CancellationToken cancellationToken)
//        {
//            var existingPackaging = await _packagingRepository.ReturnActivePackagingByNameAsync(request.Name);

//            if(existingPackaging is not null) 
//            {
//                return Result.Error<CreatePackagingResponse>(new ExceptionApplication(RegisteredErrors.PackageNameAlreadyExists));
//            }
            
//            var packaging = new RacaEntity()
//            {
//                Name = char.ToUpper(request.Name[0]) + request.Name.Substring(1).ToLower()
//			};

//            await _packagingRepository.CreatePackagingAsync(packaging);

//            var response = new CreatePackagingResponse(packaging.Id, packaging.Name, packaging.IsDeleted);

//            return Result.Success(response);
//        }
//    }
//}
