using TCC.ProjetoCaprino.Shared.Exceptions;
using TCC.ProjetoCaprino.Shared.Requests.Evento;
using TCC.ProjetoCaprino.Shared.Responses.Evento;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TCC.ProjetoCaprino.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RfidController : BaseController
    {
        private readonly ILogger<RfidController> _logger;

        private readonly IMediator _mediator;

        public RfidController(ILogger<RfidController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ReturnAllEventoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ReturnAllEventoResponse>>> ReturnAllRfidTagsAsync()
            => await SendCommand(new ReturnAllEventoRequest());

        [HttpPost]
        [ProducesResponseType(typeof(CreateRfidTagResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateRfidTagResponse>> CreateRfidTagAsync(
            [FromBody] CreateRfidTagRequest request) => await SendCommand(request);

        [HttpPut]
        [ProducesResponseType(typeof(UpdateRfidTagResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
        public async Task<ActionResult<UpdateRfidTagResponse>> UpdateRfidTagAsync(
            [FromBody] UpdateRfidTagRequest request) => await SendCommand(request);

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(ReturnEventoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReturnEventoResponse>> ReturnRfidTagAsync(
            [FromRoute] ReturnEventoRequest request) => await SendCommand(request);

        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(DeleteRfidTagResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
        public async Task<ActionResult<DeleteRfidTagResponse>> DeleteRfidTagAsync(
            [FromRoute] DeleteRfidTagRequest request) => await SendCommand(request);
    }

}
