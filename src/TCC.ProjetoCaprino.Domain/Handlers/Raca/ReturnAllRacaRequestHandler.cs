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
        public class ReturnAllRacaRequestHandler : IRequestHandler<ReturnAllRacaRequest, Result<List<ReturnAllRacaResponse>>>
        {
            private readonly IRacaRepository _racaRepository;
            private readonly ILogger<ReturnAllRacaRequestHandler> _logger;

            public ReturnAllRacaRequestHandler(IRacaRepository racaRepository, ILogger<ReturnAllRacaRequestHandler> logger)
            {
                _racaRepository = racaRepository;
                _logger = logger;
            }

            public async Task<Result<List<ReturnAllRacaResponse>>> Handle(ReturnAllRacaRequest request, CancellationToken cancellationToken)
            {
                var racas = await _racaRepository.ReturnAllRacaAsync();

                if (racas == null || !racas.Any())
                {
                    return Result.Error<List<ReturnAllRacaResponse>>(new ExceptionApplication(RegisteredErrors.RacaListEmpty));
                }

                var response = new List<ReturnAllRacaResponse>();

                foreach (var raca in racas)
                {
                    response.Add(new ReturnAllRacaResponse(raca.Id, raca.Raca));
                }

                return Result.Success(response);
            }
        }
    }
