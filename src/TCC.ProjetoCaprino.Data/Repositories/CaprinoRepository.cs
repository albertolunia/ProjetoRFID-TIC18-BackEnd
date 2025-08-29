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

    public async Task<HistoricoDoCaprinoEntity> ReturnHistoricoDoCaprinoAsync(Guid caprinoId)
    {
        return await _context.HistoricoDoCaprino
            .Where(h => h.CaprinoId == caprinoId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<HistoricoDoCaprinoEntity>> ReturnAllHistoricoDoCaprinoAsync(Guid caprinoId)
    {
        return await _context.HistoricoDoCaprino
            .Where(h => h.CaprinoId == caprinoId)
            .ToListAsync();
    }

    public async Task<List<CaprinoEntity>> GetCaprinosFilteredAsync(bool isIndividualReport, string? brinco, Guid? racaId, Guid? tipoDeCriacaoId, string? sexo, Guid? tipoDeAlimentacaoId)
    {
        var query = _context.Caprino
                            .Include(c => c.Raca)
                            .Include(c => c.TipoDeCricao)
                            .Where(c => !c.IsDeleted);

        if (isIndividualReport && !string.IsNullOrWhiteSpace(brinco))
            query = query.Where(c => c.Brinco == brinco);

        if (racaId.HasValue)
            query = query.Where(c => c.RacaId == racaId.Value);

        if (!string.IsNullOrWhiteSpace(sexo))
        {
            bool isMale = sexo.Equals("Macho", StringComparison.OrdinalIgnoreCase);
            query = query.Where(c => c.Sexo == isMale);
        }

        return await query.ToListAsync();
    }

    public async Task<List<HistoricoDoCaprinoEntity>> GetHistoricoFilteredAsync(Guid? caprinoId, DateTime? dataInicio, DateTime? dataFim, string? tipoDeEvento, string? tipoDeVacina)
    {
        var query = _context.HistoricoDoCaprino
                            .Include(h => h.Caprino)
                            .AsQueryable();

        if (caprinoId.HasValue)
            query = query.Where(h => h.CaprinoId == caprinoId.Value);

        if (dataInicio.HasValue)
            query = query.Where(h => h.CreatedAt >= dataInicio.Value);

        if (dataFim.HasValue)
            query = query.Where(h => h.CreatedAt <= dataFim.Value);

        return await query.ToListAsync();
    }

    public async Task UpdatePesoAtualAsync(Guid caprinoId, decimal novoPeso)
    {
        var caprino = await _context.Caprino.FindAsync(caprinoId);
        if (caprino == null) return;

        caprino.PesoAtual = novoPeso;
        _context.Caprino.Update(caprino);
        await _context.SaveChangesAsync();
    }
}
