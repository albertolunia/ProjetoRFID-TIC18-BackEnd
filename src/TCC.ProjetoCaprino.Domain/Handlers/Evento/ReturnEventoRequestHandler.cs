using TCC.ProjetoCaprino.Shared.Requests.Evento;
using TCC.ProjetoCaprino.Shared.Responses.Evento;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Evento;

public class ReturnEventoRequestHandler : IRequestHandler<ReturnEventoRequest, Result<ReturnEventoResponse>>
{
    private readonly ILogger<ReturnEventoRequestHandler> _logger;
    private readonly IEventoRepository _eventoRepository;

    public ReturnEventoRequestHandler(IEventoRepository eventoRepository, ILogger<ReturnEventoRequestHandler> logger)
    {
        _eventoRepository = eventoRepository;
        _logger = logger;
    }

    public async Task<Result<ReturnEventoResponse>> Handle(ReturnEventoRequest request, CancellationToken cancellationToken)
    {
        var evento = await _eventoRepository.ReturnEventoAsync(request.Id);
        if (evento == null)
        {
            //return Result.Error<ReturnEventoResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdEventoInvalido));
        }

        await _eventoRepository.ReturnEventoAsync(evento.Id);

        var response = new ReturnEventoResponse(evento.Id, evento.TipoDeEvento);

        return Result.Success(response);
    }
}
