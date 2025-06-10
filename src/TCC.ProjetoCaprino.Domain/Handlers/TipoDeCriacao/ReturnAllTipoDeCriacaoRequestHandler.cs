using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Product;
using TCC.ProjetoCaprino.Shared.Responses.Product;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;
using TCC.ProjetoCaprino.Shared.Responses.TipoDeCriacao;
using TCC.ProjetoCaprino.Shared.Requests.TipoDeCriacao;

namespace TCC.ProjetoCaprino.Domain.Handlers.Product;
public class ReturnAllTipoDeCriacaoRequestHandler
    : IRequestHandler<ReturnAllTipoDeCriacaoRequest, Result<List<ReturnAllTipoDeCriacaoResponse>>>
{
    private readonly ILogger<ReturnAllTipoDeCriacaoRequestHandler> _logger;
    private readonly ITipoDeCriacaoRepository _tipoDeCriacaoRepository;

    public ReturnAllTipoDeCriacaoRequestHandler(ITipoDeCriacaoRepository tipoDeCriacaoRepository, ILogger<ReturnAllTipoDeCriacaoRequestHandler> logger)
    {
        _tipoDeCriacaoRepository = tipoDeCriacaoRepository;
        _logger = logger;
    }

    public async Task<Result<List<ReturnAllTipoDeCriacaoResponse>>> Handle(ReturnAllTipoDeCriacaoRequest request, CancellationToken cancellationToken)
    {
        var tipos = await _tipoDeCriacaoRepository.ReturnAllTipoDeCriacaoAsync();
        if (tipos == null || !tipos.Any())
        {
            return Result.Error<List<ReturnAllTipoDeCriacaoResponse>>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.TipoDeCriacaoListEmpty));
        }

        var response = new List<ReturnAllTipoDeCriacaoResponse>();
        foreach (var tipo in tipos)
        {
            response.Add(new ReturnAllTipoDeCriacaoResponse(
                tipo.Id,
                tipo.TipoDeCriacao
            ));
        }
        return Result.Success(response);
    }
}
