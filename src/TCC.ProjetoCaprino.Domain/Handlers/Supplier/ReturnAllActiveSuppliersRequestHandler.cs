//using TCC.ProjetoCaprino.Domain.Entities;
//using TCC.ProjetoCaprino.Shared.Requests.Supplier;
//using TCC.ProjetoCaprino.Shared.Responses.Supplier;
//using TCC.ProjetoCaprino.Shared.Enums;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using OperationResult;
//using TCC.ProjetoCaprino.Domain.Repositories;

//namespace TCC.ProjetoCaprino.Domain.Handlers.Supplier;
//public class ReturnAllActiveSuppliersRequestHandler
//    : IRequestHandler<ReturnAllActiveSuppliersRequest, Result<List<ReturnAllActiveSuppliersResponse>>>
//{
//    private readonly ILogger<ReturnAllActiveSuppliersRequestHandler> _logger;
//    private readonly ISupplierRepository _supplierRepository;

//    public ReturnAllActiveSuppliersRequestHandler(ISupplierRepository supplierRepository, ILogger<ReturnAllActiveSuppliersRequestHandler> logger)
//    {
//        _supplierRepository = supplierRepository;
//        _logger = logger;
//    }

//    public async Task<Result<List<ReturnAllActiveSuppliersResponse>>> Handle(ReturnAllActiveSuppliersRequest request, CancellationToken cancellationToken)
//    {
//        var suppliers = await _supplierRepository.ReturnAllActiveSuppliersAsync();
//        if (suppliers == null)
//        {
//            return Result.Error<List<ReturnAllActiveSuppliersResponse>>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.SupplierListEmpty));
//        }

//        var response = new List<ReturnAllActiveSuppliersResponse>();
//        foreach (var supplier in suppliers)
//        {
//            response.Add(new ReturnAllActiveSuppliersResponse(supplier.Id,
//                                                        supplier.Name,
//                                                        supplier.Description,
//                                                        supplier.PhoneNumber));
//        }
//        return Result.Success(response);
//    }
//}
