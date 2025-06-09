using TCC.ProjetoCaprino.Domain.Entities;
namespace TCC.ProjetoCaprino.Domain.Repositories;

public interface ITipoDeCriacaoRepository
{
    Task<TipoDeCriacaoEntity> ReturnTipoDeCriacaoAsync(Guid id);
    Task<List<TipoDeCriacaoEntity>> ReturnAllTipoDeCriacaoAsync();
}
