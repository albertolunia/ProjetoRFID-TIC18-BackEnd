using Microsoft.EntityFrameworkCore;
using TCC.ProjetoCaprino.Application.MLModels;
using TCC.ProjetoCaprino.Data;

namespace TCC.ProjetoCaprino.Application.Services;

public class CaprinoDataService
{
    private readonly ApplicationDbContext _context;

    public CaprinoDataService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CaprinoPesoData>> GetHistoricDataForTrainingAsync()
    {
        var historicData = await _context.HistoricoDoCaprino
            .Include(h => h.Caprino)
            .Include(h => h.Caprino.Raca)
            .Include(h => h.TipoDeAlimento)
            .Where(h => h.Peso > 0)
            .ToListAsync();

        var trainingData = historicData.Select(h => new CaprinoPesoData
        {
            Peso = (float)h.Peso,

            IdadeEmDias = (float)(DateTime.UtcNow - h.Caprino.DataNascimento).TotalDays,
            Raca = h.Caprino.Raca.Raca,
            TipoDeAlimento = h.TipoDeAlimento.TipoDeAlimento,
            QuantidadeDeAlimento = (float)h.QuantidadeDeAlimento
        }).ToList();

        return trainingData;
    }
}