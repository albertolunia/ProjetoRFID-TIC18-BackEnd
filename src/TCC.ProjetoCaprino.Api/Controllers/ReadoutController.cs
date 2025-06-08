using TCC.ProjetoCaprino.Shared.Exceptions;
using TCC.ProjetoCaprino.Shared.Requests.Readout;
using TCC.ProjetoCaprino.Shared.Responses.Readout;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TCC.ProjetoCaprino.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReadoutController : BaseController
{
    private readonly ILogger<ReadoutController> _logger;
    private readonly IMediator _mediator;
    public ReadoutController(ILogger<ReadoutController> logger, IMediator mediator) : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ReturnAllReadoutsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ReturnAllReadoutsResponse>>> ReturnAllReadoutsAsync()
        => await SendCommand(new ReturnAllReadoutsRequest());

    [HttpPost]
    [ProducesResponseType(typeof(CreateReadoutResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateReadoutResponse>> CreateReadoutAsync(
        [FromBody] CreateReadoutRequest request) => await SendCommand(request);


    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(ReturnReadoutResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReturnReadoutResponse>> ReturnReadoutAsync(
        [FromRoute] ReturnReadoutRequest request) => await SendCommand(request);
}