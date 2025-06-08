//using TCC.ProjetoCaprino.Domain.Entities;
//using TCC.ProjetoCaprino.Shared.Requests.Category;
//using TCC.ProjetoCaprino.Shared.Responses.Category;
//using TCC.ProjetoCaprino.Shared.Enums;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using OperationResult;
//using TCC.ProjetoCaprino.Domain.Repositories;

//namespace TCC.ProjetoCaprino.Domain.Handlers.Category
//{
//    public class ReturnAllActiveCategoriesRequestHandler : IRequestHandler<ReturnAllActiveCategoriesRequest, Result<List<ReturnAllActiveCategoriesResponse>>>
//    {
//        private readonly ILogger<ReturnAllActiveCategoriesRequestHandler> _logger;
//        private readonly ICategoryRepository _categoryRepository;

//        public ReturnAllActiveCategoriesRequestHandler(ICategoryRepository categoryRepository, ILogger<ReturnAllActiveCategoriesRequestHandler> logger)
//        {
//            _categoryRepository = categoryRepository;
//            _logger = logger;
//        }

//        public async Task<Result<List<ReturnAllActiveCategoriesResponse>>> Handle(ReturnAllActiveCategoriesRequest request, CancellationToken cancellationToken)
//        {
//            var categories = await _categoryRepository.ReturnAllActiveCategoriesAsync();
//            if (categories == null)
//            {
//                return Result.Error<List<ReturnAllActiveCategoriesResponse>>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.CategoryListEmpty));
//            }

//            var response = new List<ReturnAllActiveCategoriesResponse>();
//            foreach (var category in categories)
//            {
//                response.Add(new ReturnAllActiveCategoriesResponse(category.Id,
//                                                            category.Name,
//                                                            category.Origin,
//                                                            category.Color));
//            }
//            return Result.Success(response);
//        }
//    }
//}
