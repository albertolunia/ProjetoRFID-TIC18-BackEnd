using TCC.ProjetoCaprino.Domain.Entities;
namespace TCC.ProjetoCaprino.Domain.Repositories;

public interface IVacinaRepository
{
    Task<VacinaEntity> ReturnVacinaAsync(Guid id);
    Task<List<VacinaEntity>> ReturnAllVacinaAsync();
}
