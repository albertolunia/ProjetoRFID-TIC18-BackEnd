using TCC.ProjetoCaprino.Domain.Entities;
namespace TCC.ProjetoCaprino.Domain.Repositories;

public interface ITipoDeAlimentoRepository
{
    Task<TipoDeAlimentoEntity> ReturnTipoDeAlimentoAsync(Guid id);
    Task<List<TipoDeAlimentoEntity>> ReturnAllTipoDeAlimentoAsync();
}
