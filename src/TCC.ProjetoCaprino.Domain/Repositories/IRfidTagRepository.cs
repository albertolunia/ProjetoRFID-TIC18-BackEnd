using TCC.ProjetoCaprino.Domain.Entities;

namespace TCC.ProjetoCaprino.Domain.Repositories;

public interface IRfidTagRepository
{
    Task<RfidTagEntity> CreateRfidTagAsync(RfidTagEntity rfidTag);
    Task<RfidTagEntity> ReturnRfidTagAsync(Guid id);
    Task<List<RfidTagEntity>> ReturnAllRfidTagsAsync();
    Task<RfidTagEntity> UpdateRfidTagAsync(RfidTagEntity rfidTag);
    Task<RfidTagEntity> DeleteRfidTagAsync(Guid id);
}
