using TCC.ProjetoCaprino.Shared.Exceptions;
using TCC.ProjetoCaprino.Shared.Requests.Evento;
using TCC.ProjetoCaprino.Shared.Responses.Evento;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TCC.ProjetoCaprino.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : BaseController
    {
        private readonly ILogger<EventoController> _logger;

        private readonly IMediator _mediator;

        public EventoController(ILogger<EventoController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ReturnAllEventoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ReturnAllEventoResponse>>> ReturnAllEventoAsync()
            => await SendCommand(new ReturnAllEventoRequest());

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(ReturnEventoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReturnEventoResponse>> ReturnEventoAsync(
            [FromRoute] ReturnEventoRequest request) => await SendCommand(request);
    }

}
