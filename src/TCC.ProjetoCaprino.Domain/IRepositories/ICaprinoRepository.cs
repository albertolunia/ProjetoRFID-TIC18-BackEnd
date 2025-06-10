using TCC.ProjetoCaprino.Domain.Entities;
namespace TCC.ProjetoCaprino.Domain.Repositories;

public interface ICaprinoRepository
{
    Task<CaprinoEntity> CreateCaprinoAsync(CaprinoEntity category);
    Task<CaprinoEntity> ReturnCaprinoAsync(Guid id);
    Task<List<CaprinoEntity>> ReturnAllCaprinosAsync();
    Task<CaprinoEntity> DeleteCaprinoAsync(Guid id);
    Task<HistoricoDoCaprinoEntity> CreateHistoricoDoCaprinoAsync(HistoricoDoCaprinoEntity historicoDoCaprino);
    Task<HistoricoDoCaprinoEntity> ReturnHistoricoDoCaprinoAsync(Guid id);
    Task<List<HistoricoDoCaprinoEntity>> ReturnAllHistoricoDoCaprinoAsync(Guid caprinoId);
}
