using TCC.ProjetoCaprino.Domain.Entities;
namespace TCC.ProjetoCaprino.Domain.Repositories;

public interface IProductRepository
{
    Task<TipoDeCriacaoEntity> CreateProductAsync(TipoDeCriacaoEntity product);
    Task<TipoDeCriacaoEntity> ReturnProductAsync(Guid id);
    Task<List<TipoDeCriacaoEntity>> ReturnAllProductsAsync();
    Task<List<TipoDeCriacaoEntity>> ReturnAllActiveProductsAsync();
    Task<TipoDeCriacaoEntity> UpdateProductAsync(TipoDeCriacaoEntity product);
    Task<TipoDeCriacaoEntity> DeleteProductAsync(Guid id);
    Task<List<TipoDeCriacaoEntity>> GetProductsByRfidsAsync(List<string> rfids);
    Task<TipoDeCriacaoEntity> GetProductByRfidAsync(string rfid);
}
