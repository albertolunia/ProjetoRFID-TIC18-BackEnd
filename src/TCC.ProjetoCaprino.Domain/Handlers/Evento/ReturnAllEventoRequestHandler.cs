using TCC.ProjetoCaprino.Shared.Requests.Evento;
using TCC.ProjetoCaprino.Shared.Responses.Evento;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Evento;

public class ReturnAllEventoRequestHandler : IRequestHandler<ReturnAllEventoRequest, Result<List<ReturnAllEventoResponse>>>
{
    private readonly ILogger<ReturnAllEventoRequestHandler> _logger;
    private readonly IEventoRepository _eventoRepository;

    public ReturnAllEventoRequestHandler(IEventoRepository eventoRepository, ILogger<ReturnAllEventoRequestHandler> logger)
    {
        _eventoRepository = eventoRepository;
        _logger = logger;
    }

    public async Task<Result<List<ReturnAllEventoResponse>>> Handle(ReturnAllEventoRequest request, CancellationToken cancellationToken)
    {
        var eventos = await _eventoRepository.ReturnAllEventoAsync();
        if (eventos == null)
        {
            //return Result.Error<List<ReturnAllEventoResponse>>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.EventoNaoEncontrado));
        }

        var response = new List<ReturnAllEventoResponse>();
        foreach (var evento in eventos)
        {
            response.Add(new ReturnAllEventoResponse(
                evento.Id,
                evento.TipoDeEvento
            ));
        }
        return Result.Success(response);
    }
}
