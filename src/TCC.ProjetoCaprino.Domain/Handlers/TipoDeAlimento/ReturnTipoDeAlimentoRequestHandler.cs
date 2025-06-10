using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Readout;
using TCC.ProjetoCaprino.Shared.Responses.Readout;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;
using TCC.ProjetoCaprino.Shared.Responses.TipoDeAlimento;
using TCC.ProjetoCaprino.Shared.Requests.TipoDeAlimento;

namespace TCC.ProjetoCaprino.Domain.Handlers.Readout;
public class ReturnTipoDeAlimentoRequestHandler
    : IRequestHandler<ReturnTipoDeAlimentoRequest, Result<ReturnTipoDeAlimentoResponse>>
{
    private readonly ILogger<ReturnTipoDeAlimentoRequestHandler> _logger;
    private readonly ITipoDeAlimentoRepository _tipoDeAlimentoRepository;

    public ReturnTipoDeAlimentoRequestHandler(ITipoDeAlimentoRepository tipoDeAlimentoRepository, ILogger<ReturnTipoDeAlimentoRequestHandler> logger)
    {
        _tipoDeAlimentoRepository = tipoDeAlimentoRepository;
        _logger = logger;
    }

    public async Task<Result<ReturnTipoDeAlimentoResponse>> Handle(ReturnTipoDeAlimentoRequest request, CancellationToken cancellationToken)
    {
        var tipoDeAlimento = await _tipoDeAlimentoRepository.ReturnTipoDeAlimentoAsync(request.Id);
        if (tipoDeAlimento == null)
        {
            return Result.Error<ReturnTipoDeAlimentoResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdTipoDeAlimentoInvalid));
        }

        var response = new ReturnTipoDeAlimentoResponse(
            tipoDeAlimento.Id,
            tipoDeAlimento.TipoDeAlimento
        );
        return Result.Success(response);
    }
}