using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Supplier;
using TCC.ProjetoCaprino.Shared.Responses.Supplier;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Supplier;
public class CreateSupplierRequestHandler
    : IRequestHandler<CreateSupplierRequest, Result<CreateSupplierResponse>>
{
    private readonly ILogger<CreateSupplierRequestHandler> _logger;
    private readonly ISupplierRepository _supplierRepository;

    public CreateSupplierRequestHandler(ISupplierRepository supplierRepository, ILogger<CreateSupplierRequestHandler> logger)
    {
        _supplierRepository = supplierRepository;
        _logger = logger;
    }

    public async Task<Result<CreateSupplierResponse>> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
    {
        var supplier = new SupplierEntity()
        {
            Name = request.Name,
            Description = request.Description,
            PhoneNumber = request.PhoneNumber,

        };

        await _supplierRepository.CreateSupplierAsync(supplier);


        var response = new CreateSupplierResponse(supplier.Id,
                                                supplier.Name,
                                                supplier.Description,
                                                supplier.PhoneNumber);
        return Result.Success(response);
    }
}
