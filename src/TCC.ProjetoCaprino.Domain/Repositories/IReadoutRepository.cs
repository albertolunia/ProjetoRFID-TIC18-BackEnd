using TCC.ProjetoCaprino.Domain.Entities;
namespace TCC.ProjetoCaprino.Domain.Repositories;

public interface IReadoutRepository
{
    Task<TipoDeAlimentoEntity> CreateReadoutAsync(TipoDeAlimentoEntity readout);
    Task<TipoDeAlimentoEntity> ReturnReadoutAsync(Guid id);
    Task<List<TipoDeAlimentoEntity>> ReturnAllReadoutsAsync();
}
