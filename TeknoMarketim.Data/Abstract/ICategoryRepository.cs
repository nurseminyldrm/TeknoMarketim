

using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Abstract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Category GetByIdWithProducts(int id);

    }
}
