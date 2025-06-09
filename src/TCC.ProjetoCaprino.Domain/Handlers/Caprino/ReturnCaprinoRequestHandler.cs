using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Category;
using TCC.ProjetoCaprino.Shared.Responses.Category;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Category;
public class ReturnCaprinoRequestHandler
    : IRequestHandler<ReturnCategoryRequest, Result<ReturnCaprinoResponse>>
{
    private readonly ILogger<ReturnCaprinoRequestHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public ReturnCaprinoRequestHandler(ICategoryRepository categoryRepository, ILogger<ReturnCaprinoRequestHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public async Task<Result<ReturnCaprinoResponse>> Handle(ReturnCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.ReturnCategoryAsync(request.Id);
        if (category == null)
        {
            return Result.Error<ReturnCaprinoResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdCategoryInvalid));
        }

        await _categoryRepository.ReturnCategoryAsync(category.Id);


        var response = new ReturnCategoryResponse(category.Id,
                                                category.Name,
                                                category.Origin,
                                                category.Color);
        return Result.Success(response);
    }
}
