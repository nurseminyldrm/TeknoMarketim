

using Microsoft.EntityFrameworkCore;
using TeknoMarketim.Data.Abstract;
using TeknoMarketim.Data.Context;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Concrete;

public class EfProductRepository : EfGenericRepositoryBase<Product, AppDbContext>, IProductRepository
{
    //protected readonly AppContext _context;

    //private readonly DbSet<Product> _dbSet;
    //public EfProductRepository(AppContext context, DbSet<Product> dbSet)
    //{
    //    _context = context;
    //    _dbSet = dbSet;
    //}


    public Product GetByIdWithCategories(int id)
    {
        using (var context = new AppDbContext())
        {
            return context.Products.Where(x => x.Id.Equals(id)).Include(x => x.ProductCategories).
                ThenInclude(x => x.Category).FirstOrDefault();

        }
    }

    public List<Product> GetProductByCategory(string categoryName, int page, int pageSize)
    {
        using (var context = new AppDbContext())
        {
            var products = context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(categoryName))
            {
                products = products.Include(x => x.ProductCategories).ThenInclude(x => x.Category)
                    .Where(x => x.ProductCategories.Any(z => z.Category.Name.ToLower() == categoryName.ToLower()));

            }
            return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }

    public Product GetProductDetails(int productId)
    {
        using (var context = new AppDbContext())
        {
            return context.Products.Where(x => x.Id == productId).Include(x => x.ProductCategories)
                .ThenInclude(x => x.Category).FirstOrDefault();
        }
    }

    public int GetProductsByCategory(string categoryName)
    {
        using (var context = new AppDbContext())
        {
            var products = context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(categoryName))
            {
                products = products.Include(x=>x.ProductCategories).ThenInclude(x => x.Category)
                    .Where(x => x.ProductCategories.Any(z=>z.Category.Name.ToLower() == categoryName.ToLower()));
            }
            return products.Count();
        }
    }

    public void Update(Product entity, int[] categoryIds)
    {
        using(var context = new AppDbContext())
        {
            var product = context.Products.Include(x => x.ProductCategories).FirstOrDefault(x=>x.Id == entity.Id);
            if(product != null)
            {
                product.Name = entity.Name;
                product.Brand = entity.Brand;
                product.Description = entity.Description;
                product.StockQuantity = entity.StockQuantity;
                product.ImageUrl = entity.ImageUrl; 
                product.Price = entity.Price;
                product.DiscountedPrice = entity.DiscountedPrice;

                product.ProductCategories = categoryIds.Select(catId => new ProductCategory()
                {
                    CategoryId = catId,
                    ProductId = entity.Id,
                }).ToList();

                context.SaveChanges();

            }
        }
    }
}
