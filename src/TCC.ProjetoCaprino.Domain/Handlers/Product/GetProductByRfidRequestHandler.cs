using System;
using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Shared.Requests.Product;
using TCC.ProjetoCaprino.Shared.Responses.Product;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using TCC.ProjetoCaprino.Domain.Repositories;

namespace TCC.ProjetoCaprino.Domain.Handlers.Product;

public class GetProductByRfidRequestHandler : IRequestHandler<GetProductByRfidRequest, Result<GetProductByRfidResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<GetProductByRfidRequestHandler> _logger;

    public GetProductByRfidRequestHandler(IProductRepository productRepository, ILogger<GetProductByRfidRequestHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Result<GetProductByRfidResponse>> Handle(GetProductByRfidRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductByRfidAsync(request.RfidTag);

        if (product == null)
        {
            //return Result.Error<GetProductByRfidResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.RfidTagInvalid));
        }

        var response = new GetProductByRfidResponse(product.Id,
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
                                                    product.IsDeleted,
                                                    product.ImageObjectName
                                                    );
        return Result.Success(response);
    }
}
