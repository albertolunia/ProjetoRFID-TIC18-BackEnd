using TCC.ProjetoCaprino.Domain.Entities;
namespace TCC.ProjetoCaprino.Domain.Repositories;

public interface ICategoryRepository
{
    Task<CaprinoEntity> CreateCategoryAsync(CaprinoEntity category);
    Task<CaprinoEntity> ReturnCategoryAsync(Guid id);
    Task<List<CaprinoEntity>> ReturnAllCategoriesAsync();
    Task<List<CaprinoEntity>> ReturnAllActiveCategoriesAsync();
    Task<CaprinoEntity> UpdateCategoryAsync(CaprinoEntity category);
    Task<ProductEntity> ReturnProductCategoryAsync(Guid id);
    Task<CaprinoEntity> DeleteCategoryAsync(Guid id);
}
