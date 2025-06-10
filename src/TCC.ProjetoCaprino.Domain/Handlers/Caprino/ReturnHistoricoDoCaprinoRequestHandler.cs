using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Caprino;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Caprino;
public class ReturnHistoricoDoCaprinoRequestHandler
    : IRequestHandler<ReturnHistoricoDoCaprinoRequest, Result<ReturnHistoricoDoCaprinoResponse>>
{
    private readonly ILogger<ReturnHistoricoDoCaprinoRequestHandler> _logger;
    private readonly ICaprinoRepository _caprinoRepository;

    public ReturnHistoricoDoCaprinoRequestHandler(ICaprinoRepository caprinoRepository, ILogger<ReturnHistoricoDoCaprinoRequestHandler> logger)
    {
        _caprinoRepository = caprinoRepository;
        _logger = logger;
    }

    public async Task<Result<ReturnHistoricoDoCaprinoResponse>> Handle(ReturnHistoricoDoCaprinoRequest request, CancellationToken cancellationToken)
    {
        var historico = await _caprinoRepository.ReturnHistoricoDoCaprinoAsync(request.Id);
        if (historico == null)
        {
            return Result.Error<ReturnHistoricoDoCaprinoResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdCaprinoInvalid));
        }

        var response = new ReturnHistoricoDoCaprinoResponse(
            historico.Id,
            historico.CaprinoId,
            historico.Peso,
            historico.QuantidadeDeLeite,
            historico.TipoDeAlimentoId,
            historico.QuantidadeDeAlimento,
            historico.EventoId,
            historico.VacinaId,
            historico.Observacoes,
            historico.CreatedAt
        );

        return Result.Success(response);
    }
}
