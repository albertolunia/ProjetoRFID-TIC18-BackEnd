﻿using TCC.ProjetoCaprino.Domain.Entities;
namespace TCC.ProjetoCaprino.Domain.Repositories;

public interface IProductRepository
{
    Task<ProductEntity> CreateProductAsync(ProductEntity product);
    Task<ProductEntity> ReturnProductAsync(Guid id);
    Task<List<ProductEntity>> ReturnAllProductsAsync();
    Task<List<ProductEntity>> ReturnAllActiveProductsAsync();
    Task<ProductEntity> UpdateProductAsync(ProductEntity product);
    Task<ProductEntity> DeleteProductAsync(Guid id);
    Task<List<ProductEntity>> GetProductsByRfidsAsync(List<string> rfids);
    Task<ProductEntity> GetProductByRfidAsync(string rfid);
}
