using TCC.ProjetoCaprino.Shared.Enums;
using TCC.ProjetoCaprino.Shared.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;
using TCC.ProjetoCaprino.Shared.Responses.TipoDeAlimento;
using TCC.ProjetoCaprino.Shared.Requests.TipoDeAlimento;

namespace TCC.ProjetoCaprino.Domain.Handlers.TipoDeAlimento;

public class ReturnAllTipoDeAlimentoRequestHandler
    : IRequestHandler<ReturnAllTipoDeAlimentoRequest, Result<List<ReturnAllTipoDeAlimentoResponse>>>
{
    private readonly ILogger<ReturnAllTipoDeAlimentoRequestHandler> _logger;
    private readonly ITipoDeAlimentoRepository _tipoDeAlimentoRepository;

    public ReturnAllTipoDeAlimentoRequestHandler(ITipoDeAlimentoRepository tipoDeAlimentoRepository, ILogger<ReturnAllTipoDeAlimentoRequestHandler> logger)
    {
        _tipoDeAlimentoRepository = tipoDeAlimentoRepository;
        _logger = logger;
    }

    public async Task<Result<List<ReturnAllTipoDeAlimentoResponse>>> Handle(ReturnAllTipoDeAlimentoRequest request, CancellationToken cancellationToken)
    {
        var tiposDeAlimento = await _tipoDeAlimentoRepository.ReturnAllTipoDeAlimentoAsync();
        if (tiposDeAlimento == null || !tiposDeAlimento.Any())
        {
            return Result.Error<List<ReturnAllTipoDeAlimentoResponse>>(new ExceptionApplication(RegisteredErrors.TipoDeAlimentoListEmpty));
        }
        var response = new List<ReturnAllTipoDeAlimentoResponse>();
        foreach (var tipo in tiposDeAlimento)
        {
            response.Add(new ReturnAllTipoDeAlimentoResponse(tipo.Id, tipo.TipoDeAlimento));
        }
        return Result.Success(response);
    }
}
