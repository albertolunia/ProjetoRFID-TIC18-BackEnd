using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Supplier;
using TCC.ProjetoCaprino.Shared.Responses.Supplier;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Supplier;
public class UpdateSupplierRequestHandler
    : IRequestHandler<UpdateSupplierRequest, Result<UpdateSupplierResponse>>
{
    private readonly ILogger<UpdateSupplierRequestHandler> _logger;
    private readonly ISupplierRepository _supplierRepository;

    public UpdateSupplierRequestHandler(ISupplierRepository supplierRepository, ILogger<UpdateSupplierRequestHandler> logger)
    {
        _supplierRepository = supplierRepository;
        _logger = logger;
    }

    public async Task<Result<UpdateSupplierResponse>> Handle(UpdateSupplierRequest request, CancellationToken cancellationToken)
    {
        var supplier = await _supplierRepository.ReturnSupplierAsync(request.Id);
        if (supplier == null)
        {
            return Result.Error<UpdateSupplierResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdSupplierInvalid));
        }

        supplier.Update(request.Name, request.Description, request.PhoneNumber);

        await _supplierRepository.UpdateSupplierAsync(supplier);

        var response = new UpdateSupplierResponse(supplier.Id,
                                                supplier.Name,
                                                supplier.Description,
                                                supplier.PhoneNumber);
        return Result.Success(response);
    }
}
