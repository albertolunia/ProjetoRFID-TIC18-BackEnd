using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Caprino;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Category;
public class ReturnAllCaprinosRequestHandler
    : IRequestHandler<ReturnAllCaprinoRequest, Result<List<ReturnAllCaprinoResponse>>>
{
    private readonly ILogger<ReturnAllCaprinosRequestHandler> _logger;
    private readonly ICaprinoRepository _caprinoRepository;

    public ReturnAllCaprinosRequestHandler(ICaprinoRepository caprinoRepository, ILogger<ReturnAllCaprinosRequestHandler> logger)
    {
        _caprinoRepository = caprinoRepository;
        _logger = logger;
    }

    public async Task<Result<List<ReturnAllCaprinoResponse>>> Handle(ReturnAllCaprinoRequest request, CancellationToken cancellationToken)
    {
        var caprinos = await _caprinoRepository.ReturnAllCaprinosAsync();
        if (caprinos == null || !caprinos.Any())
        {
            return Result.Error<List<ReturnAllCaprinoResponse>>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.CaprinoListEmpty));
        }

        var response = new List<ReturnAllCaprinoResponse>();
        foreach (var caprino in caprinos)
        {
            response.Add(new ReturnAllCaprinoResponse(
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
            ));
        }
        return Result.Success(response);
    }
}
