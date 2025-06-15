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
    Task<List<CaprinoEntity>> GetCaprinosFilteredAsync(
        bool isIndividualReport,
        string? brinco,
        Guid? racaId,
        Guid? tipoDeCriacaoId,
        string? sexo,
        Guid? tipoDeAlimentacaoId
    );
    Task<List<HistoricoDoCaprinoEntity>> GetHistoricoFilteredAsync(
        Guid? caprinoId,
        DateTime? dataInicio,
        DateTime? dataFim,
        string? tipoDeEvento,
        string? tipoDeVacina
    );
}
