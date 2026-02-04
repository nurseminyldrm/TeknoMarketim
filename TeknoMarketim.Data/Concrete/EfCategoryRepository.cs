using Microsoft.EntityFrameworkCore;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Data.Context;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Concrete
{
    public class EfCategoryRepository : EfGenericRepositoryBase<Category, AppDbContext>, ICategoryRepository
    {
        public Category GetByIdWithProducts(int id)
        {
            using(var context = new AppDbContext())
            {
                return context.Categories.Where(x => x.Id == id).Include(x => x.ProductCategories)
                    .ThenInclude(x => x.Product).FirstOrDefault();
            }
        }
    }
}
