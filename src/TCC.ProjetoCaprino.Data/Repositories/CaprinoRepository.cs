using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using TCC.ProjetoCaprino.Data;

namespace TCC.ProjetoCaprino.Data.Repositories;

public class CaprinoRepository : ICaprinoRepository
{
    private readonly ApplicationDbContext _context;

    public CaprinoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CaprinoEntity> CreateCaprinoAsync(CaprinoEntity name)
    {
        _context.Caprino.Add(name);

        await _context.SaveChangesAsync();

        return name;
    }

    public async Task<CaprinoEntity> ReturnCaprinoAsync(Guid id)
    {
        return await
            _context.Caprino.Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<CaprinoEntity>> ReturnAllCaprinosAsync()
    {
        return await _context.Set<CaprinoEntity>().ToListAsync();
    }

    public async Task<CaprinoEntity> DeleteCaprinoAsync(Guid id)
    {
        var categoryEntity = await ReturnCaprinoAsync(id);

        if (categoryEntity == null)
        {
            return null;
        }

        await _context.SaveChangesAsync();

        return categoryEntity;
    }

    public async Task<HistoricoDoCaprinoEntity> CreateHistoricoDoCaprinoAsync(HistoricoDoCaprinoEntity name)
    {
        _context.HistoricoDoCaprino.Add(name);

        await _context.SaveChangesAsync();

        return name;
    }

    public async Task<List<HistoricoDoCaprinoEntity>> ReturnAllHistoricoDoCaprinoAsync(Guid caprinoId)
    {
        return await _context.HistoricoDoCaprino
            .Where(h => h.CaprinoId == caprinoId && !h.IsDeleted)
            .ToListAsync();
    }
}
