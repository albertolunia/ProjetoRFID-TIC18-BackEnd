//using TCC.ProjetoCaprino.Domain.Entities;
//using TCC.ProjetoCaprino.Shared.Requests.Supplier;
//using TCC.ProjetoCaprino.Shared.Responses.Supplier;
//using TCC.ProjetoCaprino.Shared.Enums;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using OperationResult;
//using TCC.ProjetoCaprino.Domain.Repositories;

//namespace TCC.ProjetoCaprino.Domain.Handlers.Supplier;
//public class ReturnAllSuppliersRequestHandler
//    : IRequestHandler<ReturnAllSuppliersRequest, Result<List<ReturnAllSuppliersResponse>>>
//{
//    private readonly ILogger<ReturnAllSuppliersRequestHandler> _logger;
//    private readonly ISupplierRepository _supplierRepository;

//    public ReturnAllSuppliersRequestHandler(ISupplierRepository supplierRepository, ILogger<ReturnAllSuppliersRequestHandler> logger)
//    {
//        _supplierRepository = supplierRepository;
//        _logger = logger;
//    }

//    public async Task<Result<List<ReturnAllSuppliersResponse>>> Handle(ReturnAllSuppliersRequest request, CancellationToken cancellationToken)
//    {
//        var suppliers = await _supplierRepository.ReturnAllSuppliersAsync();
//        if (suppliers == null)
//        {
//            return Result.Error<List<ReturnAllSuppliersResponse>>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.SupplierListEmpty));
//        }

//        var response = new List<ReturnAllSuppliersResponse>();
//        foreach (var supplier in suppliers)
//        {
//            response.Add(new ReturnAllSuppliersResponse(supplier.Id,
//                                                        supplier.Name,
//                                                        supplier.Description,
//                                                        supplier.PhoneNumber,
//                                                        supplier.IsDeleted));
//        }
//        return Result.Success(response);
//    }
//}
