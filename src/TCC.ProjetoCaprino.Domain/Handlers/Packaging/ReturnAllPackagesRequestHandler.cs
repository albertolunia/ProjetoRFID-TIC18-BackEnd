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
//    public class ReturnAllPackagesRequestHandler : IRequestHandler<ReturnAllPackagesRequest, Result<List<ReturnPackagingResponse>>>
//    {
//        private readonly IPackagingRepository _packagingRepository;
//        private readonly ILogger<ReturnAllPackagesRequestHandler> _logger;

//        public ReturnAllPackagesRequestHandler(IPackagingRepository packagingRepository, ILogger<ReturnAllPackagesRequestHandler> logger)
//        {
//            _packagingRepository = packagingRepository;
//            _logger = logger;
//        }

//        public async Task<Result<List<ReturnPackagingResponse>>> Handle(ReturnAllPackagesRequest request, CancellationToken cancellationToken)
//        {
//            var packaging = await _packagingRepository.ReturnAllPackagesAsync();

//            if (packaging == null)
//            {
//                return Result.Error<List<ReturnPackagingResponse>>(new ExceptionApplication(RegisteredErrors.PackagingListEmpty));
//            }

//            var response = new List<ReturnPackagingResponse>();

//            foreach(var packagingItem in packaging)
//            {
//                response.Add(new ReturnPackagingResponse(packagingItem.Id, packagingItem.Name, packagingItem.IsDeleted));
//            }

//            return Result.Success(response);
//        }
//    }
//}
