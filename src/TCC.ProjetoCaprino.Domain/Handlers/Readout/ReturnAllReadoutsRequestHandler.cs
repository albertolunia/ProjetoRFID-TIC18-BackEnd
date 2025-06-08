using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Enums;
using TCC.ProjetoCaprino.Shared.Exceptions;
using TCC.ProjetoCaprino.Shared.Requests.Readout;
using TCC.ProjetoCaprino.Shared.Responses.Readout;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Readout;

public class ReturnAllReadoutsRequestHandler
    : IRequestHandler<ReturnAllReadoutsRequest, Result<List<ReturnAllReadoutsResponse>>>
{
    private readonly ILogger<ReturnAllReadoutsRequestHandler> _logger;
    private readonly IReadoutRepository _readoutRepository;

    public ReturnAllReadoutsRequestHandler(IReadoutRepository readoutRepository, ILogger<ReturnAllReadoutsRequestHandler> logger)
    {
        _readoutRepository = readoutRepository;
        _logger = logger;
    }

    public async Task<Result<List<ReturnAllReadoutsResponse>>> Handle(ReturnAllReadoutsRequest request, CancellationToken cancellationToken)
    {
        var readouts = await _readoutRepository.ReturnAllReadoutsAsync();
        if (readouts == null)
        {
            return Result.Error<List<ReturnAllReadoutsResponse>>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.ReadoutListEmpty));

        }
        var response = new List<ReturnAllReadoutsResponse>();
        foreach (var readout in readouts)
        {
            response.Add(new ReturnAllReadoutsResponse(readout.Id,
                                                        readout.ReadoutDate,
                                                        readout.Tags));
        }
        return Result.Success(response);
    }
}
