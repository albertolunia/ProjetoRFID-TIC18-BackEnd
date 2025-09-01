using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Caprino;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;
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
    private readonly ICaprinoRepository _caprinoRepository;

    public CreateCaprinoRequestHandler(ICaprinoRepository caprinoRepository, ILogger<CreateCaprinoRequestHandler> logger)
    {
        _caprinoRepository = caprinoRepository;
        _logger = logger;
    }

    public async Task<Result<CreateCaprinoResponse>> Handle(CreateCaprinoRequest request, CancellationToken cancellationToken)
    {
        var existingCaprino = await _caprinoRepository.GetByBrincoAsync(request.Brinco);
        if (existingCaprino != null)
        {
            return Result.Error<CreateCaprinoResponse>(
                new Shared.Exceptions.ExceptionApplication(RegisteredErrors.CaprinoAlreadyExist)
            );
        }

        var caprino = new CaprinoEntity()
        {
            Brinco = request.Brinco,
            PesoAtual = request.PesoAtual,
            Sexo = request.Sexo,
            DataNascimento = request.DataNascimento,
            RacaId = request.RacaId,
            TipoDeCricaoId = request.TipoDeCriacaoId,
            Observacoes = request.Observacoes
        };

        await _caprinoRepository.CreateCaprinoAsync(caprino);

        var response = new CreateCaprinoResponse(
            caprino.Id
        );

        return Result.Success(response);
    }
}
