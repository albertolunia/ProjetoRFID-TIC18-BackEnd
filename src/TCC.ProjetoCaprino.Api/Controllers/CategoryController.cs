using MediatR;
using Microsoft.AspNetCore.Mvc;
using TCC.ProjetoCaprino.Shared.Exceptions;
using TCC.ProjetoCaprino.Shared.Requests.Category;
using TCC.ProjetoCaprino.Shared.Responses.Category;

namespace TCC.ProjetoCaprino.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : BaseController
{
    private readonly ILogger<CategoryController> _logger;
    private readonly IMediator _mediator;
    public CategoryController(ILogger<CategoryController> logger, IMediator mediator) : base(mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ReturnAllCaprinoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ReturnAllCaprinoResponse>>> ReturnAllCategorysAsync()
        => await SendCommand(new ReturnAllCategoriesRequest());

    [HttpGet("active")]
    [ProducesResponseType(typeof(List<ReturnAllActiveCategoriesResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ReturnAllActiveCategoriesResponse>>>
        ReturnAllActiveCategoriesAsync() => await SendCommand(new ReturnAllActiveCategoriesRequest());

    [HttpPost]
    [ProducesResponseType(typeof(CreateCaprinoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateCaprinoResponse>> CreateCategoryAsync(
        [FromBody] CreateCaprinoRequest request) => await SendCommand(request);

    [HttpPut]
    [ProducesResponseType(typeof(UpdateCaprinoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<UpdateCaprinoResponse>> UpdateCategoryAsync(
        [FromBody] UpdateCategoryRequest request) => await SendCommand(request);

    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(ReturnCaprinoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ReturnCaprinoResponse>> ReturnCategoryAsync(
        [FromRoute] ReturnCategoryRequest request) => await SendCommand(request);

    [HttpDelete("{Id}")]
    [ProducesResponseType(typeof(DeleteCaprinoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
    public async Task<ActionResult<DeleteCaprinoResponse>> DeleteCategoryAsync(
        [FromRoute] DeleteCategoryRequest request) => await SendCommand(request);
}
