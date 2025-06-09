//using TCC.ProjetoCaprino.Domain.Entities;
//using TCC.ProjetoCaprino.Shared.Requests.Category;
//using TCC.ProjetoCaprino.Shared.Responses.Category;
//using TCC.ProjetoCaprino.Shared.Enums;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using OperationResult;
//using TCC.ProjetoCaprino.Domain.Repositories;

//namespace TCC.ProjetoCaprino.Domain.Handlers.Category;
//public class UpdateCaprinoRequestHandler
//    : IRequestHandler<UpdateCategoryRequest, Result<UpdateCategoryResponse>>
//{
//    private readonly ILogger<UpdateCaprinoRequestHandler> _logger;
//    private readonly ICategoryRepository _categoryRepository;

//    public UpdateCaprinoRequestHandler(ICategoryRepository categoryRepository, ILogger<UpdateCaprinoRequestHandler> logger)
//    {
//        _categoryRepository = categoryRepository;
//        _logger = logger;
//    }

//    public async Task<Result<UpdateCategoryResponse>> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
//    {
//        var category = await _categoryRepository.ReturnCategoryAsync(request.Id);
//        if (category == null)
//        {
//            return Result.Error<UpdateCategoryResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdCategoryInvalid));
//        }

//        category.Update(request.Name, request.Origin, request.Color);

//        await _categoryRepository.UpdateCategoryAsync(category);

//        var response = new UpdateCategoryResponse(category.Id,
//                                                category.Name,
//                                                category.Origin,
//                                                category.Color);
//        return Result.Success(response);
//    }
//}
