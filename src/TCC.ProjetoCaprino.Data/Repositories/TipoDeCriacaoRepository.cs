using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TCC.ProjetoCaprino.Data.Repositories;

public class TipoDeCriacaoRepository : ITipoDeCriacaoRepository
{
    private readonly ApplicationDbContext _context;

    public TipoDeCriacaoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<TipoDeCriacaoEntity> ReturnTipoDeCriacaoAsync(Guid id)
    {
        return await
            _context.TipoDeCriacao.Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<TipoDeCriacaoEntity>> ReturnAllTipoDeCriacaoAsync()
    {
        return await _context.Set<TipoDeCriacaoEntity>().ToListAsync();
    }
}
