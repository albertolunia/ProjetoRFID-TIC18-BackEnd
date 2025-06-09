using TCC.ProjetoCaprino.Domain.Entities;

namespace TCC.ProjetoCaprino.Domain.Repositories
{
    public interface IRacaRepository
    {
        Task<List<RacaEntity>> ReturnAllRacaAsync();
        Task<RacaEntity> ReturnRacaByIdAsync(Guid id);
    }
}
