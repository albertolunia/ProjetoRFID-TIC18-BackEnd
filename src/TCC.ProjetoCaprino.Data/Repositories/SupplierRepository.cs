//using TCC.ProjetoCaprino.Domain.Entities;
//using TCC.ProjetoCaprino.Domain.Repositories;
//using Microsoft.EntityFrameworkCore;
//using TCC.ProjetoCaprino.Data;

//namespace TCC.ProjetoCaprino.Data.Repositories;

//public class SupplierRepository : ISupplierRepository
//{
//    private readonly ApplicationDbContext _context;

//    public SupplierRepository(ApplicationDbContext context)
//    {
//        _context = context;
//    }
//    public async Task<VacinaEntity> UpdateSupplierAsync(VacinaEntity name)
//    {
//        _context.Supplier.Update(name);

//        await _context.SaveChangesAsync();

//        return name;
//    }

//    public async Task<VacinaEntity> CreateSupplierAsync(VacinaEntity name)
//    {
//        _context.Supplier.Add(name);

//        await _context.SaveChangesAsync();

//        return name;
//    }

//    public async Task<VacinaEntity> ReturnSupplierAsync(Guid id)
//    {
//        return await
//            _context.Supplier.Where(e => e.Id == id).FirstOrDefaultAsync();
//    }

//    public async Task<List<VacinaEntity>> ReturnAllSuppliersAsync()
//    {
//        return await _context.Set<VacinaEntity>().ToListAsync();
//    }

//    public async Task<List<VacinaEntity>> ReturnAllActiveSuppliersAsync()
//    {
//        return await _context.Supplier.Where(e => e.IsDeleted == false).ToListAsync();
//    }

//    public async Task<TipoDeCriacaoEntity> ReturnProductSupplierAsync(Guid id)
//    {
//        return await
//            _context.Product.Where(e => e.Id == id).FirstOrDefaultAsync();
//    }
//    public async Task<VacinaEntity> DeleteSupplierAsync(Guid id)
//    {
//        var supplierEntity = await ReturnSupplierAsync(id);

//        if (supplierEntity == null)
//        {
//            return null;
//        }

//        await _context.SaveChangesAsync();

//        return supplierEntity;
//    }
//}
