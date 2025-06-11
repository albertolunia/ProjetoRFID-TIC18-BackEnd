using TCC.ProjetoCaprino.Shared.Exceptions;
using TCC.ProjetoCaprino.Shared.Requests.Vacina;
using TCC.ProjetoCaprino.Shared.Responses.Vacina;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TCC.ProjetoCaprino.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class VacinaController : BaseController
{
    private readonly ILogger<VacinaController> _logger;
    private readonly IMediator _mediator;
    public VacinaController(ILogger<VacinaController> logger, IMediator mediator) : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ReturnAllVacinaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ReturnAllVacinaResponse>>> ReturnAllVacinaAsync()
        => await SendCommand(new ReturnAllVacinaRequest());

    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(ReturnVacinaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReturnVacinaResponse>> ReturnVacinaAsync(
        [FromRoute] ReturnVacinaRequest request) => await SendCommand(request);
}
