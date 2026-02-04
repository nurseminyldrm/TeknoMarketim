
using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Abstract;

public interface IProductRepository:IGenericRepository<Product>
{
    List<Product> GetProductByCategory(string category, int page, int pageSize);
    Product GetProductDetails(int productId);
    int GetProductsByCategory(string categoryName);
    Product GetByIdWithCategories(int id);
    void Update(Product entity, int[] categoryIds);

}
