using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Category;
using TCC.ProjetoCaprino.Shared.Responses.Category;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Category;
public class CreateCategoryRequestHandler
    : IRequestHandler<CreateCategoryRequest, Result<CreateCategoryResponse>>
{
    private readonly ILogger<CreateCategoryRequestHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryRequestHandler(ICategoryRepository categoryRepository, ILogger<CreateCategoryRequestHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public async Task<Result<CreateCategoryResponse>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = new CaprinoEntity()
        {
            Name = request.Name,
            Origin = request.Origin,
            Color = request.Color,

        };

        await _categoryRepository.CreateCategoryAsync(category);


        var response = new CreateCategoryResponse(category.Id,
                                                category.Name,
                                                category.Origin,
                                                category.Color);
        return Result.Success(response);
    }
}
