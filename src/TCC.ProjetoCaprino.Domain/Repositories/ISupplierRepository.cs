using TCC.ProjetoCaprino.Domain.Entities;
namespace TCC.ProjetoCaprino.Domain.Repositories;

public interface ISupplierRepository
{
    Task<SupplierEntity> CreateSupplierAsync(SupplierEntity Name);
    Task<SupplierEntity> ReturnSupplierAsync(Guid id);
    Task<List<SupplierEntity>> ReturnAllSuppliersAsync();
    Task<List<SupplierEntity>> ReturnAllActiveSuppliersAsync();
    Task<SupplierEntity> UpdateSupplierAsync(SupplierEntity Name);
    Task<ProductEntity> ReturnProductSupplierAsync(Guid id);
    Task<SupplierEntity> DeleteSupplierAsync(Guid id);
}
