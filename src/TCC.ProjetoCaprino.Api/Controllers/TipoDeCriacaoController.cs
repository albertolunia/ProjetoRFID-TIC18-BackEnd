using TCC.ProjetoCaprino.Shared.Exceptions;
using TCC.ProjetoCaprino.Shared.Requests.TipoDeCriacao;
using TCC.ProjetoCaprino.Shared.Responses.TipoDeCriacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TCC.ProjetoCaprino.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TipoDeCriacaoController : BaseController
{
    private readonly ILogger<TipoDeCriacaoController> _logger;
    private readonly IMediator _mediator;
    public TipoDeCriacaoController(ILogger<TipoDeCriacaoController> logger, IMediator mediator) : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ReturnAllTipoDeCriacaoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ReturnAllTipoDeCriacaoResponse>>> ReturnAllTipoDeCriacaoAsync()
        => await SendCommand(new ReturnAllTipoDeCriacaoRequest());

    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(ReturnTipoDeCriacaoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReturnTipoDeCriacaoResponse>> ReturnTipoDeCriacaoAsync(
        [FromRoute] ReturnTipoDeCriacaoRequest request) => await SendCommand(request);
}
