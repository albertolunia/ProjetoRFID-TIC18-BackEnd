using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Category;
using TCC.ProjetoCaprino.Shared.Responses.Category;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Category;
public class CreateCaprinoRequestHandler
    : IRequestHandler<CreateCaprinoRequest, Result<CreateCaprinoResponse>>
{
    private readonly ILogger<CreateCaprinoRequestHandler> _logger;
    private readonly ICaprinoRepository _categoryRepository;

    public CreateCaprinoRequestHandler(ICaprinoRepository categoryRepository, ILogger<CreateCaprinoRequestHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public async Task<Result<CreateCaprinoResponse>> Handle(CreateCaprinoRequest request, CancellationToken cancellationToken)
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
