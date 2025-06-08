using Microsoft.EntityFrameworkCore;
using TCC.ProjetoCaprino.Domain.Repositories;
using TCC.ProjetoCaprino.Domain.Entities;

namespace TCC.ProjetoCaprino.Data.Repositories;

public class RfidTagRepository : IRfidTagRepository
{
    private readonly ApplicationDbContext _context;

    public RfidTagRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EventoEntity> CreateRfidTagAsync(EventoEntity rfidTag)
    {
        await _context.RfidTag.AddAsync(rfidTag);
        await _context.SaveChangesAsync();
        return rfidTag;
    }

    public async Task<EventoEntity> ReturnRfidTagAsync(Guid id)
    {
        return await _context.RfidTag.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<EventoEntity>> ReturnAllRfidTagsAsync()
    {
        return await _context.Set<EventoEntity>().ToListAsync();
    }

    public async Task<EventoEntity> UpdateRfidTagAsync(EventoEntity rfidTag)
    {
        _context.RfidTag.Update(rfidTag);
        await _context.SaveChangesAsync();
        return rfidTag;
    }

    public async Task<EventoEntity> DeleteRfidTagAsync(Guid id)
    {
        var rfidTag = await ReturnRfidTagAsync(id);
        if (rfidTag == null)
        {
            return null;
        }

        _context.RfidTag.Remove(rfidTag);
        await _context.SaveChangesAsync();
        return rfidTag;
    }
}
