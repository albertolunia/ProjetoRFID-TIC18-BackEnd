using MediatR;
using Microsoft.AspNetCore.Mvc;
using TCC.ProjetoCaprino.Shared.Exceptions;
using TCC.ProjetoCaprino.Shared.Requests.Raca;
using TCC.ProjetoCaprino.Shared.Responses.Raca;

namespace TCC.ProjetoCaprino.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RacaController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RacaController> _logger;

        public RacaController(IMediator mediator, ILogger<RacaController> logger) : base(mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ReturnAllRacaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ReturnAllRacaResponse>>> ReturnAllRacaAsync()
            => await SendCommand(new ReturnAllRacaRequest());

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(ReturnRacaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReturnRacaResponse>> ReturnRacaByIdAsync(
            [FromRoute] ReturnRacaRequest request)
                => await SendCommand(request);

    }
}
