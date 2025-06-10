using TCC.ProjetoCaprino.Shared.Exceptions;
using TCC.ProjetoCaprino.Shared.Requests.TipoDeCriacao;
using TCC.ProjetoCaprino.Shared.Responses.TipoDeCriacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TCC.ProjetoCaprino.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : BaseController
{
    private readonly ILogger<ProductController> _logger;
    private readonly IMediator _mediator;
    public ProductController(ILogger<ProductController> logger, IMediator mediator) : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ReturnAllTipoDeCriacaoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ReturnAllTipoDeCriacaoResponse>>> ReturnAllProductsAsync()
        => await SendCommand(new ReturnAllTipoDeCriacaoRequest());

    [HttpGet("active")]
    [ProducesResponseType(typeof(List<ReturnAllActiveProductsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ReturnAllActiveProductsResponse>>>
        ReturnAllActiveProductsAsync() => await SendCommand(new ReturnAllActiveProductsRequest());

    [HttpPost]
    [ProducesResponseType(typeof(CreateProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateProductResponse>> CreateProductAsync(
        [FromBody] CreateProductRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(UpdateProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<UpdateProductResponse>> UpdateProductAsync(
        [FromBody] UpdateProductRequest request) => await SendCommand(request);

    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(ReturnTipoDeCriacaoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReturnTipoDeCriacaoResponse>> ReturnProductAsync(
        [FromRoute] ReturnTipoDeCriacaoRequest request) => await SendCommand(request);

    [HttpDelete("{Id}")]
    [ProducesResponseType(typeof(DeleteProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<DeleteProductResponse>> DeleteProductAsync(
        [FromRoute] DeleteProductRequest request) => await SendCommand(request);

    [HttpGet("get-products-by-rfids")]
    [ProducesResponseType(typeof(CombinedProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CombinedProductResponse>> GetProductsByRfidsAsync()
    {
        var request = new GetProductsByRfidsRequest(new List<string>());
        var result = await _mediator.Send(request);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        else
        {
            return Ok(result.Value);
        }
    }

    [HttpGet("get-product-by-rfid")]
    [ProducesResponseType(typeof(GetProductByRfidResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetProductByRfidResponse>> GetProductByRfidAsync(
        [FromQuery] GetProductByRfidRequest request)
    {
        var result = await _mediator.Send(request);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        else
        {
            return Ok(result.Value);
        }
    }

    [HttpGet("image-url/{ObjectName}")]
    [ProducesResponseType(typeof(GetProductImageUrlResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetProductImageUrlResponse>> GetProductImageUrlAsync(
        [FromRoute] GetProductImageUrlRequest request)
        => await SendCommand(request);
}
