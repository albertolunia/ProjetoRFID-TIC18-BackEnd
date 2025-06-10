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
public class ReturnAllVacinaRequestHandler
    : IRequestHandler<ReturnAllVacinaRequest, Result<List<ReturnAllVacinaResponse>>>
{
    private readonly ILogger<ReturnAllVacinaRequestHandler> _logger;
    private readonly IVacinaRepository _vacinaRepository;

    public ReturnAllVacinaRequestHandler(IVacinaRepository vacinaRepository, ILogger<ReturnAllVacinaRequestHandler> logger)
    {
        _vacinaRepository = vacinaRepository;
        _logger = logger;
    }

    public async Task<Result<List<ReturnAllVacinaResponse>>> Handle(ReturnAllVacinaRequest request, CancellationToken cancellationToken)
    {
        var vacinas = await _vacinaRepository.ReturnAllVacinaAsync();
        if (vacinas == null)
        {
            return Result.Error<List<ReturnAllVacinaResponse>>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.VacinaListEmpty));
        }

        var response = new List<ReturnAllVacinaResponse>();
        foreach (var vacina in vacinas)
        {
            response.Add(new ReturnAllVacinaResponse(
                vacina.Id,
                vacina.TipoDeVacina
            ));
        }
        return Result.Success(response);
    }
}
