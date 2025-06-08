//using TCC.ProjetoCaprino.Domain.Entities;
//using TCC.ProjetoCaprino.Domain.Repositories;
//using Microsoft.EntityFrameworkCore;

//namespace TCC.ProjetoCaprino.Data.Repositories;

//public class ProductRepository : IProductRepository
//{
//    private readonly ApplicationDbContext _context;

//    public ProductRepository(ApplicationDbContext context)
//    {
//        _context = context;
//    }
//    public async Task<TipoDeCriacaoEntity> UpdateProductAsync(TipoDeCriacaoEntity product)
//    {
//        _context.Product.Update(product);

//        await _context.SaveChangesAsync();

//        return product;
//    }

//    public async Task<TipoDeCriacaoEntity> CreateProductAsync(TipoDeCriacaoEntity product)
//    {
//        _context.Product.Add(product);

//        await _context.SaveChangesAsync();

//        return product;
//    }

//    public async Task<TipoDeCriacaoEntity> ReturnProductAsync(Guid id)
//    {
//        return await
//            _context.Product.Where(e => e.Id == id).FirstOrDefaultAsync();
//    }

//    public async Task<List<TipoDeCriacaoEntity>> ReturnAllProductsAsync()
//    {
//        return await _context.Set<TipoDeCriacaoEntity>().ToListAsync();
//    }

//    public async Task<List<TipoDeCriacaoEntity>> ReturnAllActiveProductsAsync()
//    {
//        return await _context.Product.Where(e => e.IsDeleted == false).ToListAsync();
//    }

//    public async Task<TipoDeCriacaoEntity> DeleteProductAsync(Guid id)
//    {
//        var productEntity = await ReturnProductAsync(id);

//        if (productEntity == null)
//        {
//            return null;
//        }

//        await _context.SaveChangesAsync();

//        return productEntity;
//    }

//    public async Task<List<TipoDeCriacaoEntity>> GetProductsByRfidsAsync(List<string> rfids)
//    {
//        return await _context.Product
//            .Where(p => p.IsDeleted == false)
//            .Where(p => rfids.Contains(p.RfidTag))
//            .ToListAsync();
//    }

//    public async Task<TipoDeCriacaoEntity> GetProductByRfidAsync(string rfid)
//    {
//        return await _context.Product
//            .Where(p => p.RfidTag == rfid)
//            .FirstOrDefaultAsync();
//    }
//}
