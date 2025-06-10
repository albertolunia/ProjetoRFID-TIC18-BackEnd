using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Caprino;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Category;
public class ReturnCaprinoRequestHandler
    : IRequestHandler<ReturnCaprinoRequest, Result<ReturnCaprinoResponse>>
{
    private readonly ILogger<ReturnCaprinoRequestHandler> _logger;
    private readonly ICaprinoRepository _caprinoRepository;

    public ReturnCaprinoRequestHandler(ICaprinoRepository caprinoRepository, ILogger<ReturnCaprinoRequestHandler> logger)
    {
        _caprinoRepository = caprinoRepository;
        _logger = logger;
    }

    public async Task<Result<ReturnCaprinoResponse>> Handle(ReturnCaprinoRequest request, CancellationToken cancellationToken)
    {
        var caprino = await _caprinoRepository.ReturnCaprinoAsync(request.Id);
        if (caprino == null)
        {
            return Result.Error<ReturnCaprinoResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdCaprinoInvalid));
        }

        var response = new ReturnCaprinoResponse(
            caprino.Id,
            caprino.Brinco,
            caprino.PesoAtual,
            caprino.Sexo,
            caprino.DataNascimento,
            caprino.RacaId,
            caprino.TipoDeCricaoId,
            caprino.Observacoes,
            caprino.CreatedAt,
            caprino.IsDeleted
        );
        return Result.Success(response);
    }
}
