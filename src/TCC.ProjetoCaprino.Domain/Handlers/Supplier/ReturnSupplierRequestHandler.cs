using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Supplier;
using TCC.ProjetoCaprino.Shared.Responses.Supplier;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Supplier;
public class ReturnSupplierRequestHandler
    : IRequestHandler<ReturnSupplierRequest, Result<ReturnSupplierResponse>>
{
    private readonly ILogger<ReturnSupplierRequestHandler> _logger;
    private readonly ISupplierRepository _supplierRepository;

    public ReturnSupplierRequestHandler(ISupplierRepository supplierRepository, ILogger<ReturnSupplierRequestHandler> logger)
    {
        _supplierRepository = supplierRepository;
        _logger = logger;
    }

    public async Task<Result<ReturnSupplierResponse>> Handle(ReturnSupplierRequest request, CancellationToken cancellationToken)
    {
        var supplier = await _supplierRepository.ReturnSupplierAsync(request.Id);
        if (supplier == null)
        {
            return Result.Error<ReturnSupplierResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdSupplierInvalid));
        }

        await _supplierRepository.ReturnSupplierAsync(supplier.Id);


        var response = new ReturnSupplierResponse(supplier.Id,
                                                supplier.Name,
                                                supplier.Description,
                                                supplier.PhoneNumber);
        return Result.Success(response);
    }
}
