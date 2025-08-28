using MediatR;
using Microsoft.AspNetCore.Mvc;
using TCC.ProjetoCaprino.Shared.Exceptions;
using TCC.ProjetoCaprino.Shared.Requests.Caprino;
using TCC.ProjetoCaprino.Shared.Responses.Caprino;

namespace TCC.ProjetoCaprino.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CaprinoController : BaseController
{
    private readonly ILogger<CaprinoController> _logger;
    private readonly IMediator _mediator;
    public CaprinoController(ILogger<CaprinoController> logger, IMediator mediator) : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ReturnAllCaprinoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ReturnAllCaprinoResponse>>> ReturnAllCaprinoAsync()
        => await SendCommand(new ReturnAllCaprinoRequest());

    [HttpPost]
    [ProducesResponseType(typeof(CreateCaprinoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateCaprinoResponse>> CreateCaprinoAsync(
        [FromBody] CreateCaprinoRequest request) => await SendCommand(request);

    [HttpPost("{id}/historico")]
    [ProducesResponseType(typeof(CreateHistoricoDoCaprinoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateHistoricoDoCaprinoResponse>> CreateHistoricoDoCaprinoAsync(
    [FromRoute] Guid id,
    [FromBody] CreateHistoricoDoCaprinoRequest request)
    {
        request.CaprinoId = id;
        return await SendCommand(request);
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(ReturnCaprinoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReturnCaprinoResponse>> ReturnCaprinoAsync(
        [FromRoute] ReturnCaprinoRequest request) => await SendCommand(request);

    [HttpDelete("{Id}")]
    [ProducesResponseType(typeof(DeleteCaprinoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<DeleteCaprinoResponse>> DeleteCaprinoAsync(
        [FromRoute] DeleteCaprinoRequest request) => await SendCommand(request);

    [HttpGet("{id}/historico")]
    [ProducesResponseType(typeof(List<ReturnAllHistoricoDoCaprinoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ReturnAllHistoricoDoCaprinoResponse>>> ReturnAllHistoricoDoCaprinoAsync(
        [FromRoute] Guid id)
    {
        var request = new ReturnAllHistoricoDoCaprinoRequest { Id = id };
        return await SendCommand(request);
    }

    [HttpGet("/all-historico")]
    [ProducesResponseType(typeof(ReturnHistoricoDoCaprinoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReturnHistoricoDoCaprinoResponse>> ReturnHistoricoDoCaprinoAsync(
        [FromRoute] Guid id)
    {
        var request = new ReturnHistoricoDoCaprinoRequest { Id = id };
        return await SendCommand(request);
    }

    [HttpPost("gerar-relatorio")] // Exemplo de rota para gerar relatórios
    [ProducesResponseType(typeof(GenerateCaprinoReportResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Para erros na geração do PDF
    public async Task<ActionResult<GenerateCaprinoReportResponse>> GerarRelatorioCaprinoAsync(
        [FromBody] GenerateCaprinoReportRequest request)
    {
        var result = await SendCommand(request);
        return result;
    }
}
