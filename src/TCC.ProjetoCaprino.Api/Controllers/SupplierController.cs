using TCC.ProjetoCaprino.Shared.Exceptions;
using TCC.ProjetoCaprino.Shared.Requests.Supplier;
using TCC.ProjetoCaprino.Shared.Responses.Supplier;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TCC.ProjetoCaprino.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SupplierController : BaseController
{
    private readonly ILogger<SupplierController> _logger;
    private readonly IMediator _mediator;
    public SupplierController(ILogger<SupplierController> logger, IMediator mediator) : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ReturnAllSuppliersResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ReturnAllSuppliersResponse>>> ReturnAllSuppliersAsync()
        => await SendCommand(new ReturnAllSuppliersRequest());

    [HttpGet("active")]
    [ProducesResponseType(typeof(List<ReturnAllActiveSuppliersResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ReturnAllActiveSuppliersResponse>>>
        ReturnAllActiveSuppliersAsync() => await SendCommand(new ReturnAllActiveSuppliersRequest());

    [HttpPost]
    [ProducesResponseType(typeof(CreateSupplierResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateSupplierResponse>> CreateSupplierAsync(
        [FromBody] CreateSupplierRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(UpdateSupplierResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<UpdateSupplierResponse>> UpdateSupplierAsync(
        [FromBody] UpdateSupplierRequest request) => await SendCommand(request);

    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(ReturnSupplierResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReturnSupplierResponse>> ReturnSupplierAsync(
        [FromRoute] ReturnSupplierRequest request) => await SendCommand(request);

    [HttpDelete("{Id}")]
    [ProducesResponseType(typeof(DeleteSupplierResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<DeleteSupplierResponse>> DeleteSupplierAsync(
        [FromRoute] DeleteSupplierRequest request) => await SendCommand(request);
}
