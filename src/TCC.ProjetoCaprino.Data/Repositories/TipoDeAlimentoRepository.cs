using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using TCC.ProjetoCaprino.Data;

namespace TCC.ProjetoCaprino.Data.Repositories;

public class TipoDeAlimentoRepository : ITipoDeAlimentoRepository
{
    private readonly ApplicationDbContext _context;

    public TipoDeAlimentoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TipoDeAlimentoEntity> ReturnTipoDeAlimentoAsync(Guid id)
    {
        return await
            _context.TipoDeAlimento.Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<TipoDeAlimentoEntity>> ReturnAllTipoDeAlimentoAsync()
    {
        return await _context.Set<TipoDeAlimentoEntity>().ToListAsync();
    }
}
