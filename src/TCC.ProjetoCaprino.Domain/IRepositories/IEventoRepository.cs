using TCC.ProjetoCaprino.Domain.Entities;

namespace TCC.ProjetoCaprino.Domain.Repositories;

public interface IEventoRepository
{
    Task<EventoEntity> ReturnEventoAsync(Guid id);
    Task<List<EventoEntity>> ReturnAllEventoAsync();
}
