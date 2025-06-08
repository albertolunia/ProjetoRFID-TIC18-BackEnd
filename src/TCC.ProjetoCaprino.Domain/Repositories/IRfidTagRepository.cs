using TCC.ProjetoCaprino.Domain.Entities;

namespace TCC.ProjetoCaprino.Domain.Repositories;

public interface IRfidTagRepository
{
    Task<EventoEntity> CreateRfidTagAsync(EventoEntity rfidTag);
    Task<EventoEntity> ReturnRfidTagAsync(Guid id);
    Task<List<EventoEntity>> ReturnAllRfidTagsAsync();
    Task<EventoEntity> UpdateRfidTagAsync(EventoEntity rfidTag);
    Task<EventoEntity> DeleteRfidTagAsync(Guid id);
}
