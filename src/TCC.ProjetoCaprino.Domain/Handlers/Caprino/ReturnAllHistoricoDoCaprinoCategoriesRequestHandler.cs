using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Caprino;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Category
{
    public class ReturnAllHistoricoDoCaprinoCategoriesRequestHandler : IRequestHandler<ReturnAllHistoricoDoCaprinoRequest, Result<List<ReturnAllHistoricoDoCaprinoResponse>>>
    {
        private readonly ILogger<ReturnAllHistoricoDoCaprinoCategoriesRequestHandler> _logger;
        private readonly ICaprinoRepository _historicoCaprinoRepository;

        public ReturnAllHistoricoDoCaprinoCategoriesRequestHandler(ICaprinoRepository historicoCaprinoRepository, ILogger<ReturnAllHistoricoDoCaprinoCategoriesRequestHandler> logger)
        {
            _historicoCaprinoRepository = historicoCaprinoRepository;
            _logger = logger;
        }

        public async Task<Result<List<ReturnAllHistoricoDoCaprinoResponse>>> Handle(ReturnAllHistoricoDoCaprinoRequest request, CancellationToken cancellationToken)
        {
            var historicos = await _historicoCaprinoRepository.ReturnAllHistoricoDoCaprinoAsync(request.Id);
            if (historicos == null || !historicos.Any())
            {
                return Result.Error<List<ReturnAllHistoricoDoCaprinoResponse>>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.HistoricoCaprinoListEmpty));
            }

            var response = historicos.Select(h => new ReturnAllHistoricoDoCaprinoResponse(
                h.Id,
                h.CaprinoId,
                h.Peso,
                h.QuantidadeDeLeite,
                h.TipoDeAlimentoId,
                h.QuantidadeDeAlimento,
                h.EventoId,
                h.VacinaId,
                h.Observacoes,
                h.CreatedAt
            )).ToList();

            return Result.Success(response);
        }
    }
}
