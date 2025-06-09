using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using TCC.ProjetoCaprino.Data;

namespace TCC.ProjetoCaprino.Data.Repositories;

public class VacinaRepository : IVacinaRepository
{
    private readonly ApplicationDbContext _context;

    public VacinaRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<VacinaEntity> ReturnVacinaAsync(Guid id)
    {
        return await
            _context.Vacina.Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<VacinaEntity>> ReturnAllVacinaAsync()
    {
        return await _context.Set<VacinaEntity>().ToListAsync();
    }
}
