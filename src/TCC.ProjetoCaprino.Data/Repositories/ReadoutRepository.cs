//using TCC.ProjetoCaprino.Domain.Entities;
//using TCC.ProjetoCaprino.Domain.Repositories;
//using Microsoft.EntityFrameworkCore;
//using TCC.ProjetoCaprino.Data;

//namespace TCC.ProjetoCaprino.Data.Repositories;

//public class ReadoutRepository : IReadoutRepository
//{
//    private readonly ApplicationDbContext _context;

//    public ReadoutRepository(ApplicationDbContext context)
//    {
//        _context = context;
//    }
    
//    public async Task<TipoDeAlimentoEntity> CreateReadoutAsync(TipoDeAlimentoEntity readout)
//    {
//        _context.Readout.Add(readout);

//        await _context.SaveChangesAsync();

//        return readout;
//    }

//    public async Task<TipoDeAlimentoEntity> ReturnReadoutAsync(Guid id)
//    {
//        return await
//            _context.Readout.Where(e => e.Id == id).FirstOrDefaultAsync();
//    }

//    public async Task<List<TipoDeAlimentoEntity>> ReturnAllReadoutsAsync()
//    {
//        return await _context.Set<TipoDeAlimentoEntity>().ToListAsync();
//    }
//}
