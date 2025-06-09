using Microsoft.EntityFrameworkCore;
using TCC.ProjetoCaprino.Domain.Repositories;
using TCC.ProjetoCaprino.Domain.Entities;

namespace TCC.ProjetoCaprino.Data.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly ApplicationDbContext _context;

    public EventoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EventoEntity> ReturnEventoAsync(Guid id)
    {
        return await _context.Evento.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<EventoEntity>> ReturnAllEventoAsync()
    {
        return await _context.Set<EventoEntity>().ToListAsync();
    }
}
