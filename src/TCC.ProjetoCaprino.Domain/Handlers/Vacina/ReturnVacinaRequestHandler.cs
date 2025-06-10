using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Supplier;
using TCC.ProjetoCaprino.Shared.Responses.Supplier;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;
using TCC.ProjetoCaprino.Shared.Responses.Vacina;

namespace TCC.ProjetoCaprino.Domain.Handlers.Supplier;
public class ReturnVacinaRequestHandler
    : IRequestHandler<ReturnVacinaRequest, Result<ReturnVacinaResponse>>
{
    private readonly ILogger<ReturnVacinaRequestHandler> _logger;
    private readonly IVacinaRepository _vacinaRepository;

    public ReturnVacinaRequestHandler(IVacinaRepository vacinaRepository, ILogger<ReturnVacinaRequestHandler> logger)
    {
        _vacinaRepository = vacinaRepository;
        _logger = logger;
    }

    public async Task<Result<ReturnVacinaResponse>> Handle(ReturnVacinaRequest request, CancellationToken cancellationToken)
    {
        var vacina = await _vacinaRepository.ReturnVacinaAsync(request.Id);
        if (vacina == null)
        {
            return Result.Error<ReturnVacinaResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdVacinaInvalid));
        }

        await _vacinaRepository.ReturnVacinaAsync(vacina.Id);

        var response = new ReturnVacinaResponse(
            vacina.Id,
            vacina.TipoDeVacina
        );
        return Result.Success(response);
    }
}
