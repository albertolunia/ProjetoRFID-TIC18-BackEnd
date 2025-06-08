using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Readout;
using TCC.ProjetoCaprino.Shared.Responses.Readout;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Readout;
public class ReturnReadoutRequestHandler
    : IRequestHandler<ReturnReadoutRequest, Result<ReturnReadoutResponse>>
{
    private readonly ILogger<ReturnReadoutRequestHandler> _logger;
    private readonly IReadoutRepository _readoutRepository;

    public ReturnReadoutRequestHandler(IReadoutRepository readoutRepository, ILogger<ReturnReadoutRequestHandler> logger)
    {
        _readoutRepository = readoutRepository;
        _logger = logger;
    }

    public async Task<Result<ReturnReadoutResponse>> Handle(ReturnReadoutRequest request, CancellationToken cancellationToken)
    {
        var readout = await _readoutRepository.ReturnReadoutAsync(request.Id);
        if (readout == null)
        {
            return Result.Error<ReturnReadoutResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdReadoutInvalid));
        }
        await _readoutRepository.ReturnReadoutAsync(readout.Id);

        var response = new ReturnReadoutResponse(readout.Id,
                                                readout.ReadoutDate,
                                                readout.Tags);
        return Result.Success(response);
    }
}