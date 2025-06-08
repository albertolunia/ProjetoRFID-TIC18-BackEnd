//using TCC.ProjetoCaprino.Domain.Entities;
//using TCC.ProjetoCaprino.Domain.Repositories;
//using TCC.ProjetoCaprino.Shared.Utils;
//using Microsoft.EntityFrameworkCore;

//namespace TCC.ProjetoCaprino.Data.Repositories
//{
//    public class PackagingRepositiory : IPackagingRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public PackagingRepositiory(ApplicationDbContext context) 
//            => _context = context;

//        public async Task<RacaEntity> CreatePackagingAsync(RacaEntity packaging)
//        {
//            _context.Packaging.Add(packaging);

//            await _context.SaveChangesAsync();

//            return packaging;
//        }

//        public async Task<RacaEntity> DeletePackagingAsync(Guid id)
//        {
//            var packaging = await ReturnPackagingByIdAsync(id);

//            if(packaging is not null)
//            {
//                packaging.Delete();

//                _context.Update(packaging);

//                await _context.SaveChangesAsync();
//            }

//            return packaging;
//        }

//        public async Task<List<RacaEntity>> ReturnAllPackagesAsync()
//            => await _context.Set<RacaEntity>().ToListAsync();

//        public async Task<List<RacaEntity>> ReturnAllActivePackagesAsync()
//            => await _context.Set<RacaEntity>().Where(p => !p.IsDeleted).ToListAsync();

//        public async Task<RacaEntity> ReturnPackagingByIdAsync(Guid id) 
//            => await _context.Packaging.Where(p => p.Id == id).FirstOrDefaultAsync();

//        public async Task<RacaEntity> ReturnActivePackagingByIdAsync(Guid id)
//            => await _context.Packaging.Where(p => p.Id == id && !p.IsDeleted).FirstOrDefaultAsync();

//        public async Task<RacaEntity> ReturnActivePackagingByNameAsync(string name)
//        {
//            var pacakgingList = await _context.Packaging
//                                        .Where(p => !p.IsDeleted)
//                                        .ToListAsync();

//            return pacakgingList.FirstOrDefault(p => StringUtils.AreNamesEqual(p.Name, name));
//        }
            

//        public async Task<RacaEntity> UpdatePackagingAsync(RacaEntity packaging)
//        {
//            _context.Update(packaging);

//            await _context.SaveChangesAsync();

//            return packaging;
//        }
//    }
//}
