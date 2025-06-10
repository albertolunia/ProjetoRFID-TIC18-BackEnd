using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Caprino;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Caprino;
public class CreateHistoricoDoCaprinoRequestHandler
    : IRequestHandler<CreateHistoricoDoCaprinoRequest, Result<CreateHistoricoDoCaprinoResponse>>
{
    private readonly ILogger<CreateHistoricoDoCaprinoRequestHandler> _logger;
    private readonly ICaprinoRepository _caprinoRepository;

    public CreateHistoricoDoCaprinoRequestHandler(ICaprinoRepository caprinoRepository, ILogger<CreateHistoricoDoCaprinoRequestHandler> logger)
    {
        _caprinoRepository = caprinoRepository;
        _logger = logger;
    }

    public async Task<Result<CreateHistoricoDoCaprinoResponse>> Handle(CreateHistoricoDoCaprinoRequest request, CancellationToken cancellationToken)
    {
        var historico = new HistoricoDoCaprinoEntity()
        {
            CaprinoId = request.CaprinoId,
            Peso = request.Peso,
            QuantidadeDeLeite = request.QuantidadeDeLeite,
            TipoDeAlimentoId = request.TipoDeAlimentoId,
            QuantidadeDeAlimento = request.QuantidadeDeAlimento,
            EventoId = request.EventoId,
            VacinaId = request.VacinaId,
            Observacoes = request.Observacoes
        };

        await _caprinoRepository.CreateHistoricoDoCaprinoAsync(historico);

        var response = new CreateHistoricoDoCaprinoResponse(
            historico.Id
        );

        return Result.Success(response);
    }
}
