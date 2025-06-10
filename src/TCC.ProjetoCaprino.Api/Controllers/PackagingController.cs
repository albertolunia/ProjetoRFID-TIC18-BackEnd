using MediatR;
using Microsoft.AspNetCore.Mvc;
using TCC.ProjetoCaprino.Shared.Exceptions;
using TCC.ProjetoCaprino.Shared.Requests.Raca;
using TCC.ProjetoCaprino.Shared.Responses.Raca;

namespace TCC.ProjetoCaprino.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PackagingController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PackagingController> _logger;

        public PackagingController(IMediator mediator, ILogger<PackagingController> logger) : base(mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ReturnRacaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ReturnRacaResponse>>> ReturnAllPackagingAsync()
            => await SendCommand(new ReturnAllRacaRequest());

        [HttpGet("active")]
        [ProducesResponseType(typeof(List<ReturnRacaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ReturnRacaResponse>>> ReturnAllActivePackagingAsync()
            => await SendCommand(new ReturnAllActivePackagesRequest());

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(ReturnRacaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReturnRacaResponse>> GetPackagingById(
            [FromRoute] ReturnRacaRequest request)
                => await SendCommand(request);

        [HttpPost]
        [ProducesResponseType(typeof(CreatePackagingResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreatePackagingResponse>> CreatePackagingAsync(
            [FromBody] CreatePackagingRequest request)
                => await SendCommand(request);

        [HttpPut]
        [ProducesResponseType(typeof(ReturnAllRacaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
        public async Task<ActionResult<ReturnAllRacaResponse>> UpdatePackagingAsync(
            [FromBody] UpdatePackagingRequest request)
                => await SendCommand(request);

        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(DeletePackagingResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status204NoContent)]
        public async Task<ActionResult<DeletePackagingResponse>> DeletePackagingAsync(
            [FromRoute] DeletePackagingRequest request)
                => await SendCommand(request);

    }
}
