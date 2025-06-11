using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;
using TCC.ProjetoCaprino.Shared.Requests.TipoDeCriacao;
using TCC.ProjetoCaprino.Shared.Responses.TipoDeCriacao;

namespace TCC.ProjetoCaprino.Domain.Handlers.TipoDeCriacao;
public class ReturnTipoDeCriacaoRequestHandler
    : IRequestHandler<ReturnTipoDeCriacaoRequest, Result<ReturnTipoDeCriacaoResponse>>
{
    private readonly ILogger<ReturnTipoDeCriacaoRequestHandler> _logger;
    private readonly ITipoDeCriacaoRepository _tipoDeCriacaoRepository;

    public ReturnTipoDeCriacaoRequestHandler(ITipoDeCriacaoRepository tipoDeCriacaoRepository, ILogger<ReturnTipoDeCriacaoRequestHandler> logger)
    {
        _tipoDeCriacaoRepository = tipoDeCriacaoRepository;
        _logger = logger;
    }

    public async Task<Result<ReturnTipoDeCriacaoResponse>> Handle(ReturnTipoDeCriacaoRequest request, CancellationToken cancellationToken)
    {
        var tipoDeCriacao = await _tipoDeCriacaoRepository.ReturnTipoDeCriacaoAsync(request.Id);
        if (tipoDeCriacao == null)
        {
            return Result.Error<ReturnTipoDeCriacaoResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdTipoDeCriacaoInvalid));
        }

        await _tipoDeCriacaoRepository.ReturnTipoDeCriacaoAsync(tipoDeCriacao.Id);

        var response = new ReturnTipoDeCriacaoResponse(
            tipoDeCriacao.Id,
            tipoDeCriacao.TipoDeCriacao
        );
        return Result.Success(response);
    }
}
