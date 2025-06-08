using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Product;
using TCC.ProjetoCaprino.Shared.Responses.Product;
using TCC.ProjetoCaprino.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Product;
public class ReturnAllActiveProductsRequestHandler
    : IRequestHandler<ReturnAllActiveProductsRequest, Result<List<ReturnAllActiveProductsResponse>>>
{
    private readonly ILogger<ReturnAllActiveProductsRequestHandler> _logger;
    private readonly IProductRepository _productRepository;

    public ReturnAllActiveProductsRequestHandler(IProductRepository productRepository, ILogger<ReturnAllActiveProductsRequestHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Result<List<ReturnAllActiveProductsResponse>>> Handle(ReturnAllActiveProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.ReturnAllActiveProductsAsync();
        if (products == null)
        {
            return Result.Error<List<ReturnAllActiveProductsResponse>>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.ProductListEmpty));
        }

        var response = new List<ReturnAllActiveProductsResponse>();
        foreach (var product in products)
        {
            response.Add(new ReturnAllActiveProductsResponse(product.Id,
                                                product.IdCategory,
                                                product.IdSupplier,
                                                product.IdPackaging,
                                                product.Name,
                                                product.RfidTag,
                                                product.Description,
                                                product.Weight,
                                                product.ManufacDate,
                                                product.DueDate,
                                                product.UnitMeasurement,
                                                product.BatchNumber,
                                                product.Quantity,
                                                product.Price,
                                                product.IdReadout,
                                                product.Height,
                                                product.Width,
                                                product.Length,
                                                product.Volume,
                                                product.ImageObjectName
                                                ));

        }
        return Result.Success(response);
    }
}
