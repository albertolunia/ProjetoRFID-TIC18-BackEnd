using TCC.ProjetoCaprino.Shared.Exceptions;
using TCC.ProjetoCaprino.Shared.Requests.TipoDeAlimento;
using TCC.ProjetoCaprino.Shared.Responses.TipoDeAlimento;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TCC.ProjetoCaprino.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TipoDeAlimentoController : BaseController
{
    private readonly ILogger<TipoDeAlimentoController> _logger;
    private readonly IMediator _mediator;
    public TipoDeAlimentoController(ILogger<TipoDeAlimentoController> logger, IMediator mediator) : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ReturnAllTipoDeAlimentoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ReturnAllTipoDeAlimentoResponse>>> ReturnAllTipoDeAlimentoAsync()
        => await SendCommand(new ReturnAllTipoDeAlimentoRequest());

    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(ReturnTipoDeAlimentoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReturnTipoDeAlimentoResponse>> ReturnTipoDeAlimentoAsync(
        [FromRoute] ReturnTipoDeAlimentoRequest request) => await SendCommand(request);
}