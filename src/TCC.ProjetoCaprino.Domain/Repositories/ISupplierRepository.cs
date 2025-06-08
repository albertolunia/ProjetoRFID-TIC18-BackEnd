using TCC.ProjetoCaprino.Domain.Entities;
namespace TCC.ProjetoCaprino.Domain.Repositories;

public interface ISupplierRepository
{
    Task<VacinaEntity> CreateSupplierAsync(VacinaEntity Name);
    Task<VacinaEntity> ReturnSupplierAsync(Guid id);
    Task<List<VacinaEntity>> ReturnAllSuppliersAsync();
    Task<List<VacinaEntity>> ReturnAllActiveSuppliersAsync();
    Task<VacinaEntity> UpdateSupplierAsync(VacinaEntity Name);
    Task<TipoDeCriacaoEntity> ReturnProductSupplierAsync(Guid id);
    Task<VacinaEntity> DeleteSupplierAsync(Guid id);
}
