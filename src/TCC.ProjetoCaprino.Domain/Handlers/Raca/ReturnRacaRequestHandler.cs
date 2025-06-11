using TCC.ProjetoCaprino.Shared.Enums;
using TCC.ProjetoCaprino.Shared.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;
using TCC.ProjetoCaprino.Shared.Responses.Raca;
using TCC.ProjetoCaprino.Shared.Requests.Raca;

namespace TCC.ProjetoCaprino.Domain.Handlers.Packaging
{
    public class ReturnRacaRequestHandler : IRequestHandler<ReturnRacaRequest, Result<ReturnRacaResponse>>
    {
        private readonly IRacaRepository _racaRepository;
        private readonly ILogger<ReturnRacaRequestHandler> _logger;

        public ReturnRacaRequestHandler(IRacaRepository racaRepository, ILogger<ReturnRacaRequestHandler> logger)
        {
            _racaRepository = racaRepository;
            _logger = logger;
        }

        public async Task<Result<ReturnRacaResponse>> Handle(ReturnRacaRequest request, CancellationToken cancellationToken)
        {

            var raca = await _racaRepository.ReturnRacaByIdAsync(request.Id);
            if (raca == null)
            {
                return Result.Error<ReturnRacaResponse>(new ExceptionApplication(RegisteredErrors.RacaListEmpty));
            }

            var response = new ReturnRacaResponse(raca.Id, raca.Raca);

            return Result.Success(response);
        }
    }
}
