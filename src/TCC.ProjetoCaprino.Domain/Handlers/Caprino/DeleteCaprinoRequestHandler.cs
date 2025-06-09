using TCC.ProjetoCaprino.Shared.Requests.Category;
using TCC.ProjetoCaprino.Shared.Responses.Category;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Category;
public class DeleteCaprinoRequestHandler
    : IRequestHandler<DeleteCategoryRequest, Result<DeleteCaprinoResponse>>
{
    private readonly ILogger<DeleteCaprinoRequestHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCaprinoRequestHandler(ICategoryRepository categoryRepository, ILogger<DeleteCaprinoRequestHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public async Task<Result<DeleteCaprinoResponse>> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.ReturnCategoryAsync(request.Id);
        if (category == null)
        {
            return Result.Error<DeleteCaprinoResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdCategoryInvalid));
        }

        category.Delete();

        await _categoryRepository.DeleteCategoryAsync(category.Id);


        var response = new DeleteCategoryResponse(category.Id,
                                                category.Name,
                                                category.Origin,
                                                category.Color);
        return Result.Success(response);
    }
}
