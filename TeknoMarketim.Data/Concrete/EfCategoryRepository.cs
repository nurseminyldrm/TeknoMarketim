using Microsoft.EntityFrameworkCore;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Data.Context;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Concrete
{
    public class EfCategoryRepository(AppDbContext _context) : EfGenericRepositoryBase<Category, AppDbContext>(_context), ICategoryRepository
    {
        private readonly AppDbContext _context = _context;


        public Category GetByIdWithProducts(int id)
        {
            
                return _context.Categories.Include(c => c.ProductCategories)
                    .ThenInclude(pc => pc.Product).SingleOrDefault(c => c.Id == id);
            
        }
    }
}
