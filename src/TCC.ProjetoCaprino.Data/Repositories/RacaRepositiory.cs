using TCC.ProjetoCaprino.Domain.Entities;
using TCC.ProjetoCaprino.Domain.Repositories;
using TCC.ProjetoCaprino.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace TCC.ProjetoCaprino.Data.Repositories
{
    public class RacaRepositiory : IRacaRepository
    {
        private readonly ApplicationDbContext _context;

        public RacaRepositiory(ApplicationDbContext context) 
            => _context = context;

        public async Task<List<RacaEntity>> ReturnAllRacaAsync()
            => await _context.Set<RacaEntity>().ToListAsync();

        public async Task<RacaEntity> ReturnRacaByIdAsync(Guid id) 
            => await _context.Raca.Where(p => p.Id == id).FirstOrDefaultAsync();

    }
}
