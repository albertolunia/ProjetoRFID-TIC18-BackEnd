using TCC.ProjetoCaprino.Domain.Entities;

namespace TCC.ProjetoCaprino.Domain.Repositories
{
    public interface IPackagingRepository
    {
        Task<RacaEntity> CreatePackagingAsync(RacaEntity entity);
        Task<List<RacaEntity>> ReturnAllPackagesAsync();
        Task<List<RacaEntity>> ReturnAllActivePackagesAsync();
        Task<RacaEntity> ReturnPackagingByIdAsync(Guid id);
        Task<RacaEntity> ReturnActivePackagingByIdAsync(Guid id);
        Task<RacaEntity> ReturnActivePackagingByNameAsync(string name);
		Task<RacaEntity> UpdatePackagingAsync(RacaEntity entity);
        Task<RacaEntity> DeletePackagingAsync(Guid id);
    }
}
