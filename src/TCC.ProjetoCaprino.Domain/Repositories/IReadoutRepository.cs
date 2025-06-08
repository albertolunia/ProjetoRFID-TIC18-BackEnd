using TCC.ProjetoCaprino.Domain.Entities;
namespace TCC.ProjetoCaprino.Domain.Repositories;

public interface IReadoutRepository
{
    Task<ReadoutEntity> CreateReadoutAsync(ReadoutEntity readout);
    Task<ReadoutEntity> ReturnReadoutAsync(Guid id);
    Task<List<ReadoutEntity>> ReturnAllReadoutsAsync();
}
