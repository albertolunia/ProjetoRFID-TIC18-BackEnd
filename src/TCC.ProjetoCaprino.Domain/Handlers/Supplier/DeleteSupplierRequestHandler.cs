//using TCC.ProjetoCaprino.Shared.Requests.Supplier;
//using TCC.ProjetoCaprino.Shared.Responses.Supplier;
//using TCC.ProjetoCaprino.Shared.Enums;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using OperationResult;
//using TCC.ProjetoCaprino.Domain.Repositories;

//namespace TCC.ProjetoCaprino.Domain.Handlers.Supplier;
//public class DeleteSupplierRequestHandler
//    : IRequestHandler<DeleteSupplierRequest, Result<DeleteSupplierResponse>>
//{
//    private readonly ILogger<DeleteSupplierRequestHandler> _logger;
//    private readonly ISupplierRepository _supplierRepository;

//    public DeleteSupplierRequestHandler(ISupplierRepository supplierRepository, ILogger<DeleteSupplierRequestHandler> logger)
//    {
//        _supplierRepository = supplierRepository;
//        _logger = logger;
//    }

//    public async Task<Result<DeleteSupplierResponse>> Handle(DeleteSupplierRequest request, CancellationToken cancellationToken)
//    {
//        var supplier = await _supplierRepository.ReturnSupplierAsync(request.Id);
//        if (supplier == null)
//        {
//            return Result.Error<DeleteSupplierResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdSupplierInvalid));
//        }

//        supplier.Delete();

//        await _supplierRepository.DeleteSupplierAsync(supplier.Id);

//        var response = new DeleteSupplierResponse(supplier.Id,
//                                                supplier.Name,
//                                                supplier.Description,
//                                                supplier.PhoneNumber);
//        return Result.Success(response);
//    }
//}
