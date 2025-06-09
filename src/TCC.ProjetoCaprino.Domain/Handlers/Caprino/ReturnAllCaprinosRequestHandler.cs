using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Category;
using TCC.ProjetoCaprino.Shared.Responses.Category;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Category;
public class ReturnAllCaprinosRequestHandler
    : IRequestHandler<ReturnAllCategoriesRequest, Result<List<ReturnAllCaprinoResponse>>>
{
    private readonly ILogger<ReturnAllCaprinosRequestHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public ReturnAllCaprinosRequestHandler(ICategoryRepository categoryRepository, ILogger<ReturnAllCaprinosRequestHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public async Task<Result<List<ReturnAllCaprinoResponse>>> Handle(ReturnAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.ReturnAllCategoriesAsync();
        if (categories == null)
        {
            return Result.Error<List<ReturnAllCaprinoResponse>>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.CategoryListEmpty));
        }

        var response = new List<ReturnAllCaprinoResponse>();
        foreach (var category in categories)
        {
            response.Add(new ReturnAllCategoriesResponse(category.Id,
                                                        category.Name,
                                                        category.Origin,
                                                        category.Color,
                                                        category.IsDeleted));
        }
        return Result.Success(response);
    }
}
