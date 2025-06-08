//using TCC.ProjetoCaprino.Domain.Entities;
//using TCC.ProjetoCaprino.Domain.Repositories;
//using Microsoft.EntityFrameworkCore;
//using TCC.ProjetoCaprino.Data;

//namespace TCC.ProjetoCaprino.Data.Repositories;

//public class CategoryRepository : ICategoryRepository
//{
//    private readonly ApplicationDbContext _context;

//    public CategoryRepository(ApplicationDbContext context)
//    {
//        _context = context;
//    }
//    public async Task<CaprinoEntity> UpdateCategoryAsync(CaprinoEntity name)
//    {
//        _context.Category.Update(name);

//        await _context.SaveChangesAsync();

//        return name;
//    }

//    public async Task<CaprinoEntity> CreateCategoryAsync(CaprinoEntity name)
//    {
//        _context.Category.Add(name);

//        await _context.SaveChangesAsync();

//        return name;
//    }

//    public async Task<CaprinoEntity> ReturnCategoryAsync(Guid id)
//    {
//        return await
//            _context.Category.Where(e => e.Id == id).FirstOrDefaultAsync();
//    }

//    public async Task<List<CaprinoEntity>> ReturnAllCategoriesAsync()
//    {
//        return await _context.Set<CaprinoEntity>().ToListAsync();
//    }

//    public async Task<List<CaprinoEntity>> ReturnAllActiveCategoriesAsync()
//    {
//        return await _context.Category.Where(e => e.IsDeleted == false).ToListAsync();
//    }

//    public async Task<TipoDeCriacaoEntity> ReturnProductCategoryAsync(Guid id)
//    {
//        return await
//            _context.Product.Where(e => e.Id == id).FirstOrDefaultAsync();
//    }

//    public async Task<CaprinoEntity> DeleteCategoryAsync(Guid id)
//    {
//        var categoryEntity = await ReturnCategoryAsync(id);

//        if (categoryEntity == null)
//        {
//            return null;
//        }

//        await _context.SaveChangesAsync();

//        return categoryEntity;
//    }
//}
