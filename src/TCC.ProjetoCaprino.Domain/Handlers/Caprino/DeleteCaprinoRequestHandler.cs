using TCC.ProjetoCaprino.Shared.Requests.Caprino;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Category;
public class DeleteCaprinoRequestHandler
    : IRequestHandler<DeleteCaprinoRequest, Result<DeleteCaprinoResponse>>
{
    private readonly ILogger<DeleteCaprinoRequestHandler> _logger;
    private readonly ICaprinoRepository _caprinoRepository;

    public DeleteCaprinoRequestHandler(ICaprinoRepository caprinoRepository, ILogger<DeleteCaprinoRequestHandler> logger)
    {
        _caprinoRepository = caprinoRepository;
        _logger = logger;
    }

    public async Task<Result<DeleteCaprinoResponse>> Handle(DeleteCaprinoRequest request, CancellationToken cancellationToken)
    {
        var caprino = await _caprinoRepository.ReturnCaprinoAsync(request.Id);
        if (caprino == null)
        {
            return Result.Error<DeleteCaprinoResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdCaprinoInvalid));
        }

        caprino.Delete();

        await _caprinoRepository.DeleteCaprinoAsync(caprino.Id);

        var response = new DeleteCaprinoResponse(
            caprino.Id
        );
        return Result.Success(response);
    }
}
